using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dinner
{
    public class Fork
    {
        public int id { get; private set; }
        public bool isFree { get; private set; }

        public Fork(int id)
        {
            this.id = id;
            isFree = true;
        }

        public void PickUp() => isFree = false;
        public void PutDown() => isFree = true;
    }
}
