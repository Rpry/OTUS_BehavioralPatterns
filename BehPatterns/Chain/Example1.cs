namespace BehPatterns.Chain1
{
    public interface IBase
    {
        public void Method();
    }
    
    public class Handler1: IBase
    {
        public void Method()
        {
            //делаем действие A
        }
    }
    
    public class Handler2: IBase
    {
        public void Method()
        {
            //делаем действие B
        }
    }
}