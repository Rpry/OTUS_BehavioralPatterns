using System;

namespace BehPatterns.Mediator2
{
    public interface IMediator
    {
        public void Call(BaseClass callingObj, string arg);
        void RegisterClass1(Class1 class1);
        void RegisterClass2(Class2 class2);
        void RegisterClass3(Class3 class3);
    }
    
    public class Mediator: IMediator
    {
        private Class1 _class1;
        private Class2 _class2;
        private Class3 _class3;

        public void RegisterClass1(Class1 class1)
        {
            _class1 = class1;
        }
        
        public void RegisterClass2(Class2 class2)
        {
            _class2 = class2;
        }
        
        public void RegisterClass3(Class3 class3)
        {
            _class3 = class3;
        }
        
        public void Call(BaseClass callingObj, string arg)
        {
            if (callingObj is Class1)
            {
                if (arg == "2")
                {
                    _class2.Action();
                }
            }

            if (callingObj is Class2)
            {
                if (arg == "3")
                {
                    _class3.Action();
                }
            }
        }
    }
    
    public class BaseClass
    {
        protected IMediator _mediator;
    }
    
    public class Class1: BaseClass
    {
        public Class1(IMediator mediator)
        {
            _mediator = mediator;
            _mediator.RegisterClass1(this);
        }

        public void Call(string arg)
        {
            _mediator.Call(this, arg);
        }
        
        public void Action()
        {
            Console.WriteLine("Вызов Action из Class1");
        }
    }
    
    public class Class2: BaseClass
    {
        public Class2(IMediator mediator)
        {
            _mediator = mediator;
            _mediator.RegisterClass2(this);
        }

        public void Call(string arg)
        {
            _mediator.Call(this, arg);
        }
        
        public void Action()
        {
            Console.WriteLine("Вызов Action из Class2");
        }
    }
    
    public class Class3: BaseClass
    {
        public Class3(IMediator mediator)
        {
            _mediator = mediator;
            _mediator.RegisterClass3(this);
        }

        public void Call(string arg)
        {
            _mediator.Call(this, arg);
        }
        
        public void Action()
        {
            Console.WriteLine("Вызов Action из Class3");
        }
    }
}