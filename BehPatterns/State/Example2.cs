using System;

namespace BehPatterns.State2
{
    public class Context
    {
        private IState _state;

        public void SetState(IState state)
        {
            _state = state;
        }

        public void DoA()
        {
            _state.DoA();
            Console.WriteLine($"Выполнено действие A. Cтатус {_state.GetType().Name}");
        }
        
        public void DoB()
        {
            _state.DoB();
            Console.WriteLine($"Выполнено действие B. Cтатус {_state.GetType().Name}");
        }
    }
    
    public interface IState
    {
        public void DoA();
        public void DoB();
    }
    
    public class State1: IState
    {
        private Context _context;

        public State1(Context context)
        {
            _context = context;
        }
        public void DoA()
        {
            //делаем действие A способом 1
            _context.SetState(new State2(_context));
        }
        
        public void DoB()
        {
            //делаем действие B способом 1
        }
    }
    
    public class State2: IState
    {
        private Context _context;

        public State2(Context context)
        {
            _context = context;
        }
        
        public void DoA()
        {
            //делаем действие A способом 2
            _context.SetState(new State1(_context));
        }
        
        public void DoB()
        {
            //делаем действие B способом 2
        }
    }
}