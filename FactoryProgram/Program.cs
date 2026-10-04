
using System;
public class Employee
{
    public IBonus bonus { get; private set; }
    public Employee(IBonus bonus) {  this.bonus = bonus; } 
    public float calcBonus(float number_hours)
    {
        return bonus.calc(number_hours);
    }
}
class Program
{
    static void Main(string[] args) 
    {
        IFactory l1 = Lec03BLib.getL1(); //присваиваем переменной объект  FactoryL1

        Employee employee1 = new Employee(l1.getA(25)); // 1-a создаем объект, который хранит в себе калькулятор 1го уровня со стоимостью часа 25
        Console.WriteLine(string.Format("Bonus-L1-A = {0}", employee1.calcBonus(4)));

        Employee employee2 = new Employee(l1.getB(25, 1.1f)); // 1-b
        Console.WriteLine(string.Format("Bonus-L1-B = {0}", employee2.calcBonus(4)));

        Employee employee3 = new Employee(l1.getC(25, 1.1f, 5.0f)); // 1-c 
        Console.WriteLine(string.Format("Bonus-L1-C = {0}", employee3.calcBonus(4)));
        
        IFactory l2 = Lec03BLib.getL2(1);

        Employee employee4 = new Employee(l2.getA(25)); // 2-a
        Console.WriteLine(string.Format("Bonus-L2-A = {0}", employee4.calcBonus(4)));

        Employee employee5 = new Employee(l2.getB(25, 1.1f)); // 2-b
        Console.WriteLine(string.Format("Bonus-L2-B = {0}", employee5.calcBonus(4)));

        Employee employee6 = new Employee(l2.getC(25, 1.1f, 5.0f)); // 2-c
        Console.WriteLine(string.Format("Bonus-L2-C = {0}", employee6.calcBonus(4)));

        IFactory l3 = Lec03BLib.getL3(1, 0.5f); 

        Employee employee7 = new Employee(l3.getA(25)); // 3-a
        Console.WriteLine(string.Format("Bonus-L3-A = {0}", employee7.calcBonus(4)));

        Employee employee8 = new Employee(l3.getB(25, 1.1f)); // 3-b
        Console.WriteLine(string.Format("Bonus-L3-B = {0}", employee8.calcBonus(4)));

        Employee employee9 = new Employee(l3.getC(25, 1.1f, 0.5f)); // 3-c
        Console.WriteLine(string.Format("Bonus-L3-C = {0}", employee9.calcBonus(4)));
    }
}