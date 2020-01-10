using System;
using System.Collections.Generic;
using System.Text;

namespace TheaterTicketsManagement.Models
{
    class Theater : Base
    {
        public string Name { get; set; }
        public string Director { get; set; }
        public string Address { get; set; }

        public Theater(string name, string director, string address, int id) {
            Name = name;
            Director = director;
            Address = address;
            Id = id;
        }
    }
}
