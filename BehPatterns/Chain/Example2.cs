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

        public void Handle()
        {
            if (_next != null)
            {
                _next.Handle();    
            }
        }
    }

    public class Handler1: BaseHandler
    {
        public void Handle()
        {
            //делаем действие A
            base.Handle();
        }
    }
    
    public class Handler2: BaseHandler
    {
        public void Handle()
        {
            //делаем действие B
            base.Handle();
        }
    }
}