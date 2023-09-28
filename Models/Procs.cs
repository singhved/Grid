using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Grid.Models
{
    public class Procs
    {
        public static string Getconnection
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["Context"].ConnectionString;
            }
        }
        public static DataSet Editcourse(int? Id)
        {
            SqlConnection con = new SqlConnection(Getconnection);
            SqlCommand cmd = new SqlCommand("Editcourse", con);
            cmd.Parameters.AddWithValue("@Id", Id);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sd = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {
                sd.SelectCommand = cmd;
                sd.Fill(ds);
            }
            catch (Exception) { }
            return ds;
        }
        public static DataTable CourseTable()
        {
            SqlConnection con = new SqlConnection(Getconnection);
            SqlCommand cmd = new SqlCommand("CourseTable", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sd = new SqlDataAdapter();
            DataTable dt = new DataTable();
            try
            {
                sd.SelectCommand = cmd;
                sd.Fill(dt);
            }
            catch (Exception) { }
            return dt;
        }
        public static DataTable DeptTable()
        {
            SqlConnection con = new SqlConnection(Getconnection);
            SqlCommand cmd = new SqlCommand("DeptTable", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sd = new SqlDataAdapter();
            DataTable dt = new DataTable();
            try
            {
                sd.SelectCommand = cmd;
                sd.Fill(dt);
            }
            catch (Exception) { }
            return dt;
        }
        public static string DeptDel(int Id)
        {
            SqlConnection con = new SqlConnection(Getconnection);
            SqlCommand cmd = new SqlCommand("DelDept", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", Id);
            string res = "-1";
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                res = "1";
            }
            catch (Exception) { }
            finally { con.Close(); }
            return res;
        }
        public static DataTable FacultyView(int Id)
        {
            SqlConnection con = new SqlConnection(Getconnection);
            SqlCommand cmd = new SqlCommand("FacultyView",con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", Id);
            SqlDataAdapter sd = new SqlDataAdapter();
            DataTable dt = new DataTable();
            
            try
            {
                sd.SelectCommand = cmd;
                sd.Fill(dt);

            }
            catch (Exception) { }
            return dt;
        }
        public static DataTable deptview(int Id)
        {
            SqlConnection con = new SqlConnection(Getconnection);
            SqlCommand cmd = new SqlCommand("deptview", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", Id);
            SqlDataAdapter sd = new SqlDataAdapter();
            DataTable dt = new DataTable();

            try
            {
                sd.SelectCommand = cmd;
                sd.Fill(dt);

            }
            catch (Exception) { }
            return dt;
        }
        public static DataSet Edit(int Id)
        {
            SqlConnection con = new SqlConnection(Getconnection);
            SqlCommand cmd = new SqlCommand("Edit", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", Id);
            SqlDataAdapter sd = new SqlDataAdapter();
            DataSet ds = new DataSet();

            try
            {
                sd.SelectCommand = cmd;
                sd.Fill(ds);

            }
            catch (Exception) { }
            return ds;
        }
    }
}