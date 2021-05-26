using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Async
{
    public class Potato
    {


        public Potato()
        {
            IsPeeled = false;

        }
        public Potato(bool isPeeled)
        {
            IsPeeled = isPeeled;
        }



        public bool IsPeeled { get; set; }
    }
}
