namespace BehPatterns.TemplateMethod1
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
            //делаем действие B
            //делаем действие C
        }
    }
    
    public class DerivedClass2: BaseClass
    {
        public override void Method()
        {
            //делаем действие X
            //делаем действие Y
            //делаем действие Z
        }
    }
}