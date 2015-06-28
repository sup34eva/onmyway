using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnMyWay
{
    class Waiter
    {
        public int id;
        public string firstName;
        public string lastName;
        public bool occupied;

        public Waiter(string firstName, string lastName, bool occupied)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.occupied = occupied;
        }
    }
}
