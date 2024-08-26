namespace BehPatterns.Strategy2
{
    public class ContextClass
    {
        private IBase _strategy;
            
        public ContextClass(IBase strategy)
        {
            _strategy = strategy;
        }

        public void Method()
        {
            _strategy.Method();
        }
    }
    
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