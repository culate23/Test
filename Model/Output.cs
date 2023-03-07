using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Output
    {
        private string _region;
        private float _total_cost;
        private List<Machines> machines = new List<Machines>();

        public string Region { get => _region; set => _region = value; }
        public float Total_cost { get => _total_cost; set => _total_cost = value; }
        public List<Machines> Machines { get => machines; set => machines = value; }

        public Output() { }
    }
}
