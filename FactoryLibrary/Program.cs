
    public interface IBonus
    {
        float cost1hour { get; set; }
        float calc(float number_hours);
    }
    public interface IFactory
    {
        IBonus getA(float cost1hour); 
        IBonus getB(float cost1hour, float x);
        IBonus getC(float cost1hour, float x, float y);
    }
    public static class Lec03BLib 
    {
        public static IFactory getL1() 
    {
            return new FactoryL1();
        }

        public static IFactory getL2(float a)
        {
            return new FactoryL2(a);
        }

        public static IFactory getL3(float a, float b)
        {
            return new FactoryL3(a, b);
        }
    }
    //----
    internal class BonusA_L1 : IBonus
    {
        public float cost1hour { get; set; }
        public BonusA_L1(float cost)
        {
            cost1hour = cost;
        }
        public float calc(float number_hours)
        {
            return number_hours * cost1hour;
        }
    }
    internal class BonusB_L1 : IBonus
    {
        public float cost1hour { get; set; }
        private float x;

        public BonusB_L1(float cost, float x)
        {
            this.x = x;
            cost1hour = cost;
        }
        public float calc(float number_hours)
        {
            return cost1hour * number_hours * x;
        }
    }
    internal class BonusC_L1 : IBonus
    {
        public float cost1hour { get; set; }
        private float x;
        private float y;
        public BonusC_L1(float cost, float x, float y)
        {
            cost1hour = cost;
            this.x = x;
            this.y = y;
        }
        public float calc(float number_house)
        {
            return cost1hour * number_house * x + y;
        }
    }
    internal class BonusA_L2 : IBonus
    {
        public float cost1hour { get; set; }
        private float a;
        public BonusA_L2(float cost, float a)
        {
            cost1hour = cost;
            this.a = a;
        }
        public float calc(float number_house)
        {
            return (number_house + a) * cost1hour;
        }
    }
    internal class BonusB_L2 : IBonus
    {
        public float cost1hour { get; set; }
        private float a;
        private float x;
        public BonusB_L2(float cost, float a, float x)
        {
            cost1hour = cost;
            this.a = a;
            this.x = x;
        }
        public float calc(float number_house)
        {
            return (number_house + a) * x * cost1hour;
        }
    }
    public class BonusC_L2 : IBonus
    {
        public float cost1hour { get; set; }
        private float a;
        private float x;
        private float y;
        public BonusC_L2(float cost, float a, float x, float y)
        {
            cost1hour = cost;
            this.a = a;
            this.x = x;
            this.y = y;
        }
        public float calc(float number_house)
        {
            return (number_house + a) * x * cost1hour + y;
        }
    }
    public class BonusA_L3 : IBonus
    {
        public float cost1hour { get; set; }
        private float a;
        private float b;
        public BonusA_L3(float cost, float a, float b)
        {
            cost1hour = cost;
            this.a = a;
            this.b = b;
        }
        public float calc(float number_house)
        {
            return (number_house + a) * (cost1hour + b);
        }
    }
    public class BonusB_L3 : IBonus
    {
        public float cost1hour { get; set; }
        public float a;
        private float b;
        private float x;
        public BonusB_L3(float cost, float a, float b, float x)
        {
            cost1hour = cost;
            this.a = a;
            this.b = b;
            this.x = x;
        }
        public float calc(float number_house)
        {
            return (number_house + a) * (cost1hour + b) * x;
        }
    }
    public class BonusC_L3 : IBonus
    {
        public float cost1hour { get; set; }
        public float a;
        private float b;
        private float x;
        private float y;
        public BonusC_L3(float cost1hour, float a, float b, float x, float y)
        {
            this.cost1hour = cost1hour;
            this.a = a;
            this.b = b;
            this.x = x;
            this.y = y;
        }
        public float calc(float number_house)
        {
            return (number_house + a) * (cost1hour + b) * x + y;
        }
    }
    //-----
    internal class FactoryL1 : IFactory 
    {
        public IBonus getA(float cost1hour)
        {
            return new BonusA_L1(cost1hour); 
    }
        public IBonus getB(float cost1hour, float x)
        {
            return new BonusB_L1(cost1hour, x);
        }
        public IBonus getC(float cost1hour, float x, float y)
        {
            return new BonusC_L1(cost1hour, x, y);
        }

    } 
    internal class FactoryL2 : IFactory
    {
        private float a;
        public FactoryL2(float a)
        {
            this.a = a;
        }
        public IBonus getA(float cost1hour)
        {
            return new BonusA_L2(cost1hour, a);
        }
        public IBonus getB(float cost1hour, float x)
        {
            return new BonusB_L2(cost1hour, a, x);
        }
        public IBonus getC(float cost1hour, float x, float y)
        {
            return new BonusC_L2(cost1hour, a, x, y);
        }
    }
    internal class FactoryL3 : IFactory
    {
        private float a, b;
        public FactoryL3(float a, float b)
        {
            this.a = a;
            this.b = b;
        }
        public IBonus getA(float cost1hour)
        {
            return new BonusA_L3(cost1hour, a, b);
        }
        public IBonus getB(float cost1hour, float x)
        {
            return new BonusB_L3(cost1hour, a, b, x);
        }
        public IBonus getC(float cost1hour, float x, float y)
        {
            return new BonusC_L3(cost1hour, a, b, x, y);
        }
    }

