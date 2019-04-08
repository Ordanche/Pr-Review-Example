using System;
using System.Collections.Generic;
using DemoLib.Model;

namespace DemoLib.Dal
{
    public interface DataContext
    {
        Item GetItem(Guid id);

        IList<Item> GetItems(string group);
        
        void Save(Item item);
    }
}