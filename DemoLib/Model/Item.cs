using System;
using System.Text;

namespace DemoLib.Model
{
    public partial class Item
    {
        public Guid? Id { get; set; }
        public string Name { get; set; }
        public int State { get; set; }
        public DateTime Creation { get; set; }
        public DateTime? Complete { get; set; }
    }

    public partial class Group
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

}