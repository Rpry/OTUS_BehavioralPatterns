namespace BehPatterns.TemplateMethod2
{
    public abstract class BaseClass
    {
        public abstract void Method();
    }
    
    public class DerivedClass1: BaseClass
    {
        public override void Method()
        {
            //делаем действие A
            //делаем действие X1
            //делаем действие B
        }
    }
    
    public class DerivedClass2: BaseClass
    {
        public override void Method()
        {
            //делаем действие A
            //делаем действие X2
            //делаем действие B
        }
    }
}