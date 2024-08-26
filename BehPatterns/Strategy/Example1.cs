namespace BehPatterns.Strategy1
{
    public interface IBase
    {
        public void Method();
    }
    
    public class DerivedClass1: IBase
    {
        public void Method()
        {
            //делаем действие A
        }
    }
    
    public class DerivedClass2: IBase
    {
        public void Method()
        {
            //делаем действие B
        }
    }
}