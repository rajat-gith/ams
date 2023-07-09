using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Attendance_Management_System.Models
{
    public class UserModel
    { 
        public int ID { get; set; }
        public int EMP_ID { get; set; }
        public string EMP_NAME { get; set; }
        public DateTime ATTEND_DATE { get; set; }
        public DateTime LOCAL_INTIME { get; set; }
        public DateTime LOCAL_OUTTIME { get; set; }
    }

}

