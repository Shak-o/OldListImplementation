using System;
using System.Collections.Generic;
using System.Text;

namespace midterm_3_recreation
{
    class MyListExceptions : Exception
    {
        public MyListExceptions(string message) : base($"\n we have problem *{message}*")
        {

        }
    }
}
