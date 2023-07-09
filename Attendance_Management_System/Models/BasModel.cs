using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Attendance_Management_System.Models
{
    public class BasModel
    {
        public int ID { get; set; }
        public int EMP_ID { get; set; }
        public string EMP_NAME { get; set; }    
        public DateTime ATTEND_DATE { get; set; }
        public DateTime BAS_INTIME { get; set; }
        public DateTime BAS_OUTTIME { get; set; }
    }
}