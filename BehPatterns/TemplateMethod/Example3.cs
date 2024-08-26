namespace BehPatterns.TemplateMethod3
{
    public abstract class BaseClass
    {
        public void Method()
        {
            ActionA();
            ActionX();
            ActionB();
        }

        public virtual void ActionA()
        {
            //делаем действие A
        }
        
        public virtual void ActionB()
        {
            //делаем действие B
        }

        public abstract void ActionX();
    }
    
    public class DerivedClass1: BaseClass
    {
        public override void ActionX()
        {
            //делаем действие X1
        }
    }
    
    public class DerivedClass2: BaseClass
    {
        public override void ActionX()
        {
            //делаем действие X2
        }
    }
}