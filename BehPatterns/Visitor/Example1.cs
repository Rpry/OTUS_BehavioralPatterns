namespace BehPatterns.Visitor1
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
        
        /*
        public void Action()
        {
            //делаем действие B разными способами
        }
        */
    }
    
    public class DerivedClass2: IBase
    {
        public void Method()
        {
            //делаем действие B
        }
        
        /*
        public void Action()
        {
            //делаем действие B разными способами
        }
        */
    }
}