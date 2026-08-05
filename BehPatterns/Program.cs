using System;
using System.Collections;
using System.Collections.Generic;

using BehPatterns.Command.BankAccountOperations;
using BehPatterns.Command.BankAccountOperationsCommand;
using BehPatterns.Iterator1;
using BehPatterns.Mediator2;
using BehPatterns.Memento.DocumentStateSaving;
using BehPatterns.Memento.DocumentStateSavingWithMemento;
using BehPatterns.State2;
using BehPatterns.Strategy;
using BehPatterns.Strategy.Discount;
using BehPatterns.Strategy.DiscountStrategy;
using BehPatterns.Strategy2;
using BehPatterns.Visitor;

using DelegateDemo = BehPatterns.Command.BankAccountOperations.Demo;
using DerivedClass1 = BehPatterns.Strategy1.DerivedClass1;
using DerivedClass2 = BehPatterns.Visitor.DerivedClass2;

namespace BehPatterns
{
    class Program
    {
        private static void Main(string[] args)
        {
            #region Template method

            /*
            var class1 = new BehPatterns.TemplateMethod3.DerivedClass1();
            class1.Method();
            var class2 = new BehPatterns.TemplateMethod3.DerivedClass2();
            class2.Method();
              */              

            #endregion

            #region Visitor 1

            /*
            var obj1 = new Visitor.DerivedClass1();
            //obj1.Action(new ActionVisitorX());
            obj1.Action(new ActionVisitorY());
            var obj2 = new DerivedClass2();
            obj2.Action(new ActionVisitorX());
            obj2.Action(new ActionVisitorY());
            */

            #endregion

            #region Visitor 2

            /*
            var employees = new List<IEmployee>
            {
                new FullTimeEmployee("Иван", 100000m, 5),
                new FullTimeEmployee("Петр", 80000m, 2),
                new ContractorEmployee("Сидор", 500m, 160),
                new InternEmployee("Анна", 30000m, "МГУ")
            };
            
            var calculator = new SalaryCalculator();
            calculator.CalculateAll(employees);
            Console.WriteLine();
*/
            #endregion

            #region Observer

            /*
            var newsPublisher = new Observer1.NewsPublisher();
            newsPublisher.AddNews("Победа на олимпиаде");
            var subscriber = new Observer1.Subscriber(newsPublisher);
            newsPublisher.AddNews("Победа на чемпионате мира");
            */
            /*
            var newsPublisher2 = new Observer2.NewsPublisher();
            newsPublisher2.AddNews("Победа на олимпиаде");
            var person = new Observer2.Subscriber(newsPublisher2);
            newsPublisher2.AddNews("Победа на чемпионате мира");
            */

            #endregion

            #region Mediator

            /*
            Mediator mediator = new Mediator();
            Mediator2.Class1 class1 = new Class1(mediator);
            Mediator2.Class2 class2 = new Class2(mediator);
            Mediator2.Class3 class3 = new Class3(mediator);
            class1.Call("2");
            class2.Call("3");
            */

            #endregion

            #region Strategy

            DiscountDemo.Run();
            DiscountingDemoStrategy.Run();
            

            /*
            var exemplar = new DerivedClass1();
            exemplar.Method();
            var contextClass = new ContextClass(new Strategy2.DerivedClass1());
            contextClass.Method();

            var strategy = new BaseStrategy();
            WithdrawService service = new WithdrawService(strategy);
            service.ValidateAmount(100);
            */

            #endregion

            #region State

            /*
            Context context = new Context();
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

            #endregion

            #region Chain of responsibility

            /*
            var handler1 = new Chain2.Handler1();
            var handler2 = new Chain2.Handler2();
            handler1.SetNext(handler2);
            var handler3 = new Chain2.Handler2();
            handler2.SetNext(handler3);
            handler1.Handle();
            */

            #endregion

            #region Command

            //DirectDemo.Run();
            //DelegateDemo.Run();
            BankingDemo.Run();

            #endregion

            #region Memento
            
            //Demo.Run();
            //MementoDemo.Run();

            #endregion
        }
    }
}
