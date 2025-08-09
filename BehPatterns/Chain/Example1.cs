namespace BehPatterns.Chain1
{
    public interface IBase
    {
        public void Handle();
    }
    
    public class Handler1: IBase
    {
        public void Handle()
        {
            //делаем действие A
        }
    }
    
    public class Handler2: IBase
    {
        public void Handle()
        {
            //делаем действие B
        }
    }
}