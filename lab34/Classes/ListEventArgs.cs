using System;
using System.Collections.Generic;
using System.Text;

namespace lab34.Classes
{
    public class ListEventArgs:EventArgs
    {
        public string Message { get; private set; }
        public string Find { get; private set; }
        public ListEventArgs(string e, string find)
        {
            Message = e;
            Find = find;
        }
    }
}
