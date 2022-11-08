using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mod
{
    public class Mod_Lets
    {
        public int LetID { get; set; }

        public int? HID { get; set; }

        public int? CusID { get; set; }

        public int? EmpID { get; set; }

        public DateTime? LetBeginDate { get; set; }

        public DateTime? ExpectEndDate { get; set; }

        public DateTime? LetEndDate { get; set; }

        public decimal? LetRent { get; set; }

        public decimal? LetNet { get; set; }

        public decimal? LetElectric { get; set; }

        public decimal? LetWater { get; set; }

        public decimal? BeginElectric { get; set; }

        public decimal? BeginWater { get; set; }

        public decimal? EndElectric { get; set; }

        public decimal? EndWater { get; set; }

        public decimal? EndMoney { get; set; }

        public DateTime? CurrentNetDate { get; set; }

        public DateTime? CurrentRentDate { get; set; }

        public int? CreateEmp { get; set; }

        public DateTime? CreateDate { get; set; }

        public int? LetState { get; set; }

        public string LetMark { get; set; }

        public string HCName { get; set; }

        public string HNum { get; set; }

        public int? HArea { get; set; }

        public string CusName { get; set; }

        public string EmpName { get; set; }

        public int DiffDay { get; set; }

        public string CusTel { get; set; }

    }
}
