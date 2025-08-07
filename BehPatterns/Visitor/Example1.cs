namespace BehPatterns.Visitor1
{
    public interface IBase
    {
    }
    
    public class DerivedClass1: IBase
    {
        public void Action()
        {
            //должны делать действие разными способами
        }
    }
    
    public class DerivedClass2: IBase
    {
        public void Action()
        {
            //должны делать действие разными способами
        }
    }
}