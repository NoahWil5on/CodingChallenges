using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_001
{
    class Pair
    {
        //fields
        int begin;
        int end;

        //properties
        public int Begin { get { return begin; } }
        public int End { get { return end; } }

        //constructor
        public Pair(int begin, int end)
        {
            this.begin = begin;
            this.end = end;
        }
    }
}
