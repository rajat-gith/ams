using System;
using System.Linq;
using Attendance_Management_System.Models;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Collections.Generic;
namespace Attendance_Management_System.Services
{
    public class UserDAL
    {

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
        SqlCommand cmd;
        SqlDataAdapter sda;
        DataTable dt;
        public List<LocalModel> GetReportAUsers()
        {
            cmd = new SqlCommand(" select * from master.dbo.local where DATEDIFF(hour, LOCAL_INTIME, LOCAL_OUTTIME) < 8;", con);
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            List<LocalModel> list = new List<LocalModel>();
            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new LocalModel
                {
                    EMP_ID = Convert.ToInt32(dr["EMP_ID"]),
                    EMP_NAME = dr["EMP_NAME"].ToString(),
                    ATTEND_DATE = Convert.ToDateTime(dr["ATTEND_DATE"]),
                    LOCAL_INTIME = (DateTime)(dr["LOCAL_INTIME"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["LOCAL_INTIME"])),
                    LOCAL_OUTTIME = (DateTime)(dr["LOCAL_OUTTIME"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["LOCAL_OUTTIME"]))
                });
            }
            return list;
        }
        public List<LocalModel> GetLocalData()
        {
            List<LocalModel> localList = new List<LocalModel>();

            cmd = new SqlCommand("SELECT ID, EMP_ID, EMP_NAME, ATTEND_DATE, LOCAL_INTIME, LOCAL_OUTTIME FROM master.dbo.local", con);
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                localList.Add(new LocalModel
                {
                    EMP_ID = Convert.ToInt32(dr["EMP_ID"]),
                    EMP_NAME = dr["EMP_NAME"].ToString(),
                    ATTEND_DATE = Convert.ToDateTime(dr["ATTEND_DATE"]),
                    LOCAL_INTIME = (DateTime)(dr["LOCAL_INTIME"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["LOCAL_INTIME"])),
                    LOCAL_OUTTIME = (DateTime)(dr["LOCAL_OUTTIME"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["LOCAL_OUTTIME"]))
                });
            }
            return localList;
        }
        public List<BasModel> GetBASData()
        {
            List<BasModel> basList = new List<BasModel>();
            cmd = new SqlCommand("SELECT ID, EMP_ID, EMP_NAME, ATTEND_DATE, BAS_INTIME, BAS_OUTTIME FROM master.dbo.BAS", con);
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);

            foreach (DataRow dr in dt.Rows)
            {
                basList.Add(new BasModel
                {
                    EMP_ID = Convert.ToInt32(dr["EMP_ID"]),
                    EMP_NAME = dr["EMP_NAME"].ToString(),
                    ATTEND_DATE = Convert.ToDateTime(dr["ATTEND_DATE"]),
                    BAS_INTIME = (DateTime)(dr["BAS_INTIME"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["BAS_INTIME"])),
                    BAS_OUTTIME = (DateTime)(dr["BAS_OUTTIME"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["BAS_OUTTIME"]))
                });
            }
            return basList;
        }
    }
}
