using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC2021.Days
{
    class Location
    {
        public int height { get; set; }
        public int up { get; set; }
        public int down { get; set; }
        public int left { get; set; }
        public int right { get; set; }
        public bool isLowPoint { get; set; }

        private int riskLevel;

        public bool alreadyInBasin { get; set; }

        public int i { get; set; }
        public int o { get; set; }

        public int RiskLevel
        {
            get
            {
                if (isLowPoint)
                {
                    return height + 1;
                }
                else
                {
                    return riskLevel;
                }
            }

            set { riskLevel = value; }
        }

        public void CheckForLowPoint()
        {
            if (height < up && height < down && height < left && height <right)
            {
                isLowPoint = true;
            }
        }

    }

}
