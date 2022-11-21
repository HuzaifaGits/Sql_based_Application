

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assign4
{
    public class Customer
    {
        private static string myConn = ConfigurationManager.ConnectionStrings["constring"].ConnectionString;

        public string customerid { get; set; }
        public string companyname { get; set; }
        public string contactname { get; set; }
        public string phone { get; set; }

        /// <summary>
        /// INSERT
        /// </summary>
        private const string InsertQuery = "Insert Into customer(customerid,companyname,contactname,phone) Values(@customerid,@companyname, @contactname, @phone)";
        public bool Insertcustomer(Customer customer)
        {
            int rows;
            using (SqlConnection con = new SqlConnection(myConn))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand(InsertQuery, con))
                {
                    com.Parameters.AddWithValue("@customerid", customer.customerid);
                    com.Parameters.AddWithValue("@companyname", customer.companyname);
                    com.Parameters.AddWithValue("@contactname", customer.contactname);
                    com.Parameters.AddWithValue("@phone", customer.phone);
                    rows = com.ExecuteNonQuery();
                }
            }
            return (rows > 0) ? true : false;
        }

        /// <summary>
        /// UPDATE
        /// </summary>
        private const string UpdateQuery = "Update customer set companyname=@companyname,contactname=@contactname,phone=@phone where customerid=@customerid";
        public bool Updatecustomer(Customer customer)
        {
            int rows;
            using (SqlConnection con = new SqlConnection(myConn))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand(UpdateQuery, con))
                {
                    com.Parameters.AddWithValue("@customerid", customer.customerid);
                    com.Parameters.AddWithValue("@companyname", customer.companyname);
                    com.Parameters.AddWithValue("@contactname", customer.contactname);
                    com.Parameters.AddWithValue("@phone", customer.phone);

                    rows = com.ExecuteNonQuery();
                }
            }
            return (rows > 0) ? true : false;
        }

        /// <summary>
        /// DELETE
        /// </summary>
        private const string DeleteQuery = "Delete from customer where customerid=@customerid";
        public bool Deletecustomer(Customer customer)
        {
            int rows;
            using (SqlConnection con = new SqlConnection(myConn))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand(DeleteQuery, con))
                {
                    com.Parameters.AddWithValue("@customerid", customer.customerid);
                    rows = com.ExecuteNonQuery();
                }
            }
            return (rows > 0) ? true : false;
        }

        /// <summary>
        /// SHOW
        /// </summary>
        private const string ShowQuery = "Select * from customer";
        public DataTable Showcustomer()
        {
            var datatable = new DataTable();
            using (SqlConnection con = new SqlConnection(myConn))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand(ShowQuery, con))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(com))
                    {
                        adapter.Fill(datatable);
                    }
                }
            }
            return datatable;
        }
    }



}