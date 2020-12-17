using System;
using System.Collections.Generic;
using System.Reflection;

namespace lab34.Classes
{
    public delegate void ListStateHandler(object sender, ListEventArgs e);
    class ListDef
    {
        protected List<string> list;
        public List<string> Val
        {
            get => list;
            private set => list = value;
        }
        protected Type thisType;
        protected event ListStateHandler onAdded;
        protected event ListStateHandler onDeleted;
        protected event ListStateHandler onClear;
        public ListDef(string[] data)
        {
            thisType = GetType();
            Val = new List<string>(data);
        }

        protected void CallEvent(ListEventArgs e, ListStateHandler handler)
        {
            handler?.Invoke(this,e);
        }
        public void Add(string find)
        {
            ListEventArgs e = new ListEventArgs("Added", find);
            CallEvent(e, onAdded);
        }
        public void Delete(string find)
        {
            ListEventArgs e = new ListEventArgs("Deleted", find);
            CallEvent(e, onDeleted);
        }
        public void Clear(string find)
        {
            ListEventArgs e = new ListEventArgs("Clear", find);
            CallEvent(e, onClear);
        }
        public ListDef setField(string field,ListStateHandler handler)
        {
            FieldInfo info = thisType.GetField(field, BindingFlags.NonPublic | BindingFlags.Instance);
            if(handler!=null)
                info.SetValue(this, handler);
            return this;
        }
        public void Reset()
        {
            Val.Clear();
        }

    }
}
