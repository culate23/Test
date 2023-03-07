using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Machines
    {
        private string name;
        private int quantity;

        public string Name { get => name; set => name = value; }
        public int Quantity { get => quantity; set => quantity = value; }

        public Machines() { }
    }
}
