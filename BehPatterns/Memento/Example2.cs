using System;
using System.Collections.Generic;

namespace BehPatterns.Memento2
{
    public class Memento
    {
        public string _data { get; set; }

        public Memento(string data)
        {
            _data = data;
        }

        public string GetState()
        {
            return _data;
        }
    }
    
    public class RollBackedObject
    {
        private string _data;
  
        public Memento SaveState()
        {
            return new Memento(_data);
        }

        public void Restore(Memento memento)
        {
            _data = memento._data;
        }

        public void DoSomeAction()
        {
            _data = (new Random()).Next().ToString();
        }

        public string GetState => _data;
    }
    
    public class MainClass
    {
        public Stack<Memento> Mementoes { get; set; }
        public RollBackedObject RollBackedObject { get; set; }

        public MainClass()
        {
            Mementoes = new Stack<Memento>();
            RollBackedObject = new RollBackedObject();
        }
        
        public void Do()
        {
            var memento = RollBackedObject.SaveState();
            if (memento._data != null)
            {
                Mementoes.Push(memento);    
            } 
            RollBackedObject.DoSomeAction();
        }
        
        public void UnDo()
        {
            var previous = Mementoes.Pop();
            RollBackedObject.Restore(previous);
        }
    }
}