using System.Reflection.Metadata;
using System.Security.Cryptography;
using System.Text;
public interface IWriter
{
    string? Save(string? messeage);

}
public static class Constant
{
    public const char Delimiter = '\uffff';
    public const string FileName = "DP.txt";
}
public class FileWriter: IWriter
{
    string filename = Constant.FileName;
    public string FileName {  get { return this.filename; } }
    public FileWriter(string? filename = null)
    {
        this.filename = filename ?? Constant.FileName;
    }
    public string? Save(string? message)
    {
        File.WriteAllText(this.filename, message);
        return this.filename;
    }
}
public class StrWriter : IWriter
{
    public string? Save(string? message) 
    {
        return message;
    }
}
public class Decorator: IWriter
{
    protected IWriter? writer;//ссылка на след объект в цепочке
    public Decorator(IWriter writer) {  this.writer = writer; }
    public virtual string? Save(string? message)
    {
        return writer?.Save(message);
    }
}
public class DecSHA512 : Decorator
{

    public DecSHA512(IWriter writer):base(writer) { }

    public override string? Save(string? message)
    {
        string original = message ?? string.Empty;
        string hashBase64;

        using (SHA512 sha512 = SHA512.Create())
        {
            byte[] hashBytes = sha512.ComputeHash(Encoding.ASCII.GetBytes(original));//вычисление хэша на основе массива байт полученного из строки
            hashBase64 = Convert.ToBase64String(hashBytes);//преобразовываем двоичные данные в тест 
        }
        string composed = $"{original}{Constant.Delimiter}{hashBase64}";
        return writer?.Save(composed);//а writer содержит ссылку на предыдущую оболочку(ядро)
    }

}
public class DecMD5 : Decorator
{
    public DecMD5(IWriter writer) : base(writer) { }
    public override string? Save(string? message)
    {
        string original = message ?? string.Empty;
        string hashBase64;

        using (MD5 md5 = MD5.Create())
        {
            byte[] hashBytes = md5.ComputeHash(Encoding.ASCII.GetBytes(original));
            hashBase64 = Convert.ToBase64String(hashBytes);
        }
        string composed = $"{original}{Constant.Delimiter}{hashBase64}";
        return writer?.Save(composed);
    }

}
public class DecRSA : Decorator
{
    public DecRSA(IWriter writer) : base(writer) { }

    public override string? Save(string? message)
    {
        string publicKeyXml;
        byte[] encyptedData;

        message = message ?? string.Empty;

        int k1 = message.IndexOf(Constant.Delimiter);
        if (k1 == -1) throw new Exception("delimiter not found");

        string xs = message.Substring(0, k1);
        string xsbhcs = message.Substring(k1 + 1);
        byte[] xsbhc = Convert.FromBase64String(xsbhcs);

        using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
        {
            publicKeyXml = rsa.ToXmlString(true);
            rsa.ImportParameters(rsa.ExportParameters(false));
            encyptedData = rsa.Encrypt(xsbhc, false);
        }

        string result = $"{xs}{Constant.Delimiter}{Convert.ToBase64String(encyptedData)}{Constant.Delimiter}{publicKeyXml}";
        return writer?.Save(result);
    }

}
