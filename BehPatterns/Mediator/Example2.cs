namespace BehPatterns.Mediator2
{
    public interface IMediator
    {
        public void Call(BaseClass callingObj, string arg);
    }
    
    public class Mediator: IMediator
    {
        public void Call(BaseClass callingObj, string arg)
        {
            if (callingObj is Class1)
            {
                if (arg == "On")
                {
                    
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
        public Class1() { _mediator = new Mediator(); }
        public void Action()
        {
            _mediator.Call(this, "On");
        }
    }
    
    public class Class2: BaseClass
    {
        public Class2() { _mediator = new Mediator(); }
        
        public void Action()
        {
            _mediator.Call(this, "Off");
        }
    }
    
    public class Class3: BaseClass
    {
        public Class3() { _mediator = new Mediator(); }

        public void Action()
        {
            _mediator.Call(this, "On");
        }
    }
}