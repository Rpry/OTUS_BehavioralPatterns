using System;
using System.Collections;
using System.Collections.Generic;
using BehPatterns.Command2;
using BehPatterns.Iterator1;
using BehPatterns.Mediator2;
using BehPatterns.Memento2;
using BehPatterns.State2;
using BehPatterns.Strategy2;
using BehPatterns.Visitor2;
using DerivedClass1 = BehPatterns.Strategy1.DerivedClass1;

namespace BehPatterns
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            var class1 = new BehPatterns.TemplateMethod3.DerivedClass1();
            class1.Method();
            var class2 = new BehPatterns.TemplateMethod3.DerivedClass2();
            class2.Method();
            */
            
            /*
            var obj1 = new Visitor2.DerivedClass1();
            obj1.Action(new ActionVisitorX());
            obj1.Action(new ActionVisitorY());
            var obj2 = new Visitor2.DerivedClass2();
            obj2.Action(new ActionVisitorX());
            obj2.Action(new ActionVisitorY());
            */
            
            /*
            var newsPublisher = new Observer1.NewsPublisher();
            newsPublisher.AddNews("Первая новость!");
            var person = new Observer1.Person(newsPublisher);
            newsPublisher.AddNews("Вторая новость!");
            */
            
            /*
            var newsPublisher = new Observer2.NewsPublisher();
            newsPublisher.AddNews("Первая новость!");
            var person = new Observer2.Person(newsPublisher);
            newsPublisher.AddNews("Вторая новость!");
            */
            
            //strategy
            
            //var exemplar = new DerivedClass1();
            //exemplar.Method();
            //var contextClass = new ContextClass(new Strategy2.DerivedClass1());
            //contextClass.Method();
            
            
            //var strategy = new BaseStrategy();
            //WithdrawService service = new WithdrawService(strategy);
            //service.ValidateAmount(100);
            
            /*
            Mediator2.Class1 class1 = new Class1();
            class1.Action();
            */
            
            /*
            State2.Context context = new Context();
            var state1 = new State2.State1(context);
            context.SetState(state1);
            //context.DoA();
            while (true)
            {
                var key = Console.ReadKey();
                if (key.Key == ConsoleKey.A)
                {
                    context.DoA();
                }
                if (key.Key == ConsoleKey.B)
                {
                    context.DoB();
                }
            }
            */

            /*
            var handler1 = new Chain2.Handler1();
            var handler2 = new Chain2.Handler2();
            handler1.SetNext(handler2);
            handler1.Handle();
            */
           
            /* 
            var editor = new Editor();
            editor.DoCopy();
            editor.Button.Click();
            */
           
            /*
            MainClass mainClass = new MainClass();
            mainClass.Do();
            Console.WriteLine(mainClass.RollBackedObject.GetState);
            mainClass.Do();
            Console.WriteLine(mainClass.RollBackedObject.GetState);
            mainClass.UnDo();
            Console.WriteLine(mainClass.RollBackedObject.GetState);
           */
            Console.ReadKey();
        }
    }
}
