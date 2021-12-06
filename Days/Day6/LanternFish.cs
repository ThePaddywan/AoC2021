using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC2021.Days
{
    class LanternFish
    {
        public LanternFish(int startTimer)
        {
            this.internalTimer = startTimer;
        }

        public LanternFish()
        {
            this.internalTimer = 8;
        }
        public int internalTimer { get; set; }

        public void Reset()
        {
            this.internalTimer = 6;
        }


    }
}
