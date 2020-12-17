using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using lab34.Classes;
namespace lab34
{
    class Program
    {
        public static Predicate<string> NumbersMoreThanLetters= NumLet;
        static void Main(string[] args)
        {
            string[] strs = new string[] {
            "abc","defg","klmnoprst"
            };
            ListDef list = new ListDef(strs);
            list.setField("onAdded", onAdded).setField("onDeleted", onDeleted).setField("onClear", onClear);
            NumbersMoreThanLetters = NumLet;
            list.Delete("abc");
        }
        public static bool NumLet(string str)
        {
            Regex letters = new Regex("[a-zA-Z]");
            Regex nums = new Regex("[0-9]");
            return nums.Matches(str).Count > letters.Matches(str).Count;
        }
        public static void onAdded(object o,ListEventArgs e)
        {
            if((o as ListDef) != null)
            {
                (o as ListDef).Val.Add(e.Find);
                Console.WriteLine(e.Message);
            }
        }
        public static void onDeleted(object o,ListEventArgs e)
        {
            if ((o as ListDef) != null)
            {
                (o as ListDef).Val.Remove(e.Find);
                Console.WriteLine(e.Message);
            }
        }
        public static void onClear(object o, ListEventArgs e)
        {
            if ((o as ListDef) != null)
            {
                (o as ListDef).Reset();
                Console.WriteLine(e.Message);
            }
        }

    }
}
