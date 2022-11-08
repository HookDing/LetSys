using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mod
{
    public class Mod_HouseInfo
    {
        public int HID { get; set; }

        public int? HCID { get; set; }

        public string HAdd { get; set; }

        public string HNum { get; set; }

        public string HType { get; set; }

        public int? HArea { get; set; }

        public string HDirection { get; set; }

        public decimal? HRent { get; set; }

        public decimal? HNet { get; set; }

        public decimal? HElectric { get; set; }

        public decimal? HWater { get; set; }

        public decimal? HElectricMoney { get; set; }

        public decimal? HWaterMoney { get; set; }

        public string HMark { get; set; }

        public string HCName { get; set; }

        public int? HState { get; set; }
    }
}
