using System;

namespace BehPatterns.Chain2
{
    public interface IBase
    {
        public void SetNext(IBase next);
        
        public void Handle();
    }

    public class BaseHandler : IBase
    {
        private IBase _next;
        
        public void SetNext(IBase next)
        {
            _next = next;
        }

        public virtual void Handle()
        {
            if (_next != null)
            {
                _next.Handle();    
            }
        }
    }

    public class Handler1: BaseHandler
    {
        public override void Handle()
        {
            Console.WriteLine("делаем действие A");
            base.Handle();
        }
    }
    
    public class Handler2: BaseHandler
    {
        public override void Handle()
        {
            Console.WriteLine("делаем действие B");
            base.Handle();
        }
    }
}