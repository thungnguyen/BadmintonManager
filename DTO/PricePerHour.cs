using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadmintonManager.DTO
{
    internal class PricePerHour
    {
        public PricePerHour(int giaSan)
        {
            this.GiaSan = giaSan;
        }
        private int giaSan;
        public int GiaSan
        {
            get { return giaSan; }
            set { giaSan = value; }
        }
    }
}
