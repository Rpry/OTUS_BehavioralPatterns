namespace BehPatterns.State1
{
    public enum State
    {
        StateA,
        StateB
    }
    
    public class Context
    {
        public State State { get; set; }
        
        public void DoA()
        {
            if (State == State.StateA)
            {
                //делаем действие
                State = State.StateB;
            }
            
            else if (State == State.StateB)
            {
                //делаем действие
                State = State.StateA;
            }
        }
        
        public void DoB()
        {
            if (State == State.StateA)
            {
                //делаем действие
                State = State.StateA;
            }
            
            else if (State == State.StateB)
            {
                //делаем действие
                State = State.StateB;
            }
        }
    }
}