namespace BehPatterns.State1
{
    public interface IState
    {
        public void DoA();
        public void DoB();
    }
    
    public class State1: IState
    {
        public void DoA()
        {
            //делаем действие A способом 1
        }
        
        public void DoB()
        {
            //делаем действие B способом 1
        }
    }
    
    public class State2: IState
    {
        public void DoA()
        {
            //делаем действие A способом 2
        }
        
        public void DoB()
        {
            //делаем действие B способом 2
        }
    }
}