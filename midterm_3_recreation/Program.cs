using System;

namespace midterm_3_recreation
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            MyList<string> myList = new MyList<string>();
            myList.AddRange(new string[6] {"a","b","wef","ccc","f","cds"});
            //myList.Remove("b");
            // for (int i = 0; i < myList.Counter; i++)
            // {
            //     if (myList[i] == null)
            //     {
            //         Console.WriteLine("null");
            //     }
            //     else
            //     {
            //         Console.WriteLine(myList[i]);
            //     }
            // }
            //myList.RemoveRange(1,1);
            var test = myList.Where(x => x.Length > 1);
            foreach (var item in test)
            {
                if (item == null) Console.WriteLine("null");
                else Console.WriteLine(item);
            }
        }
    }
}
