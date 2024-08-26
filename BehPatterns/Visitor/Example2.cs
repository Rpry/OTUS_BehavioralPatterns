using System;

namespace BehPatterns.Visitor2
{
    public interface IBase
    {
        public void Method();
    }
    
    public interface IVisited
    {
        public void Action(IActionVisitor actionVisitor);
    }
    
    public class DerivedClass1: IBase, IVisited
    {
        public void Method()
        {
            //делаем действие A
        }
        
        public void Action(IActionVisitor actionVisitor)
        {
            actionVisitor.Action(this);
        }
    }
    
    public class DerivedClass2: IBase, IVisited
    {
        public void Method()
        {
            //делаем действие B
        }
        
        public void Action(IActionVisitor actionVisitor)
        {
            actionVisitor.Action(this);
        }
    }

    public interface IActionVisitor
    {
        public void Action(DerivedClass1 derivedClass);
        public void Action(DerivedClass2 derivedClass);
    }

    public class ActionVisitorX: IActionVisitor
    {
        public void Action(DerivedClass1 derivedClass)
        {
            // Делает действие Х образом
            Console.WriteLine($"Action для DerivedClass1 способом Х");
        }

        public void Action(DerivedClass2 derivedClass)
        {
            // Делает действие Х образом
            Console.WriteLine($"Action для DerivedClass2 способом Х");
        }
    }
    
    public class ActionVisitorY: IActionVisitor
    {
        public void Action(DerivedClass1 derivedClass)
        {
            // Делает действие Y образом
            Console.WriteLine($"Action для DerivedClass1 способом Y");
        }

        public void Action(DerivedClass2 derivedClass)
        {
            // Делает действие Y образом
            Console.WriteLine($"Action для DerivedClass2 способом Y");
        }
    }
}