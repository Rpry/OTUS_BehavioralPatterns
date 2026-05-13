using System;
using System.Collections.Generic;

namespace BehPatterns.Iterator1
{
    public class Example1
    {
        public void Main()
        {
            var collection = new string[2];
            foreach (var obj in collection)
            {
                Console.WriteLine(obj); 
            }
        }

        ///private Array
        //List<string>  df
        //Stack<string>
    }
}