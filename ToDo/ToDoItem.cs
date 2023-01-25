using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo
{
    internal class ToDoItem
    {
        public int Id { get; set; }
        public DateTime Created { get; set; }
        public DateTime Deadline { get; set; }
        public bool IsDone { get; set; }
        public bool IsFavorite { get; set; }
        public string ToDo { get; set; }
        public long Repeat { get; set; }//If Repeat is >0, then Repeat is on.

    }
}
