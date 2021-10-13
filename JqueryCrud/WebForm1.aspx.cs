using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Newtonsoft.Json;
using System.Web.Services;

namespace JqueryCrud
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        //create object of sqlconnection for interacting with database
        //"DBCS" is declared in web.config file
        static SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {

        }
        
        //insert data into the tblEmployee Table.
        [WebMethod]
        public static void InsertData(string name, int age, string address)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_tblEmployee_Insert",con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@EmpName" , name);
            cmd.Parameters.AddWithValue("@EmpAge", age);
            cmd.Parameters.AddWithValue("@EmpAddress", address);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        //fetch data from tblEmployee Table.
        [WebMethod]
        public static string GetEmpData()
        {
            con.Open();
            string _data = "";
            SqlCommand cmd = new SqlCommand("sp_tblEmployee_Select", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            con.Close();
            if (ds.Tables[0].Rows.Count > 0)
            {
                _data = JsonConvert.SerializeObject(ds.Tables[0]);
            }
            return _data;
        }

        //edit data from tblEmployee Table.

        [WebMethod]
        public static string Edit(int Id)
        {
            string _data = "";
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_tblEmployee_Edit", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@empid", Id);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            con.Close();
            if (ds.Tables[0].Rows.Count > 0)
            {
                _data = JsonConvert.SerializeObject(ds.Tables[0]);
            }
            return _data;
        }

        // accept Id, Name, Address, Age values. Based on this Id update data in the tblEmployee Table.
        [WebMethod]
        public static void Update(int ID, string name, int age, string address)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_tblEmployee_Update", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@EmpId", ID);
            cmd.Parameters.AddWithValue("@EmpName", name);
            cmd.Parameters.AddWithValue("@EmpAge", age);
            cmd.Parameters.AddWithValue("@EmpAddress", address);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        //delete data from the tblEmployee Table.
        [WebMethod]
        public static void Delete(int Id) 
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_tblEmployee_Delete", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@EmpId", Id);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        
    }
}