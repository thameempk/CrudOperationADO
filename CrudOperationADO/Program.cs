using Microsoft.Data.SqlClient;
using System;
using System.Data.SqlClient;
namespace AdoNetConsoleApplication
{
    class Program
    {
        public string connectionString = "data source=DESKTOP-1FVO61D\\SQLEXPRESS; database=student; integrated security=SSPI ;TrustServerCertificate=True";
        static void Main(string[] args)
        {
            new Program().DisplayData();
            new Program().InsertRecord();
            Console.ReadKey();
        }
        public void InsertRecord()
        {
            SqlConnection con = null;
            try
            {
                // Creating Connection  
                con = new SqlConnection(connectionString);
                // writing sql query  
                SqlCommand cm = new SqlCommand("insert into student (id, name, email, join_date) values ('101', 'Ronald Trump', 'ronald@example.com', '1/12/2017')", con);

                // Opening Connection  
                con.Open();
                // Executing the SQL query  
                cm.ExecuteNonQuery();
                // Displaying a message  
                Console.WriteLine("Record Inserted Successfully");
            }
            catch (Exception e)
            {
                Console.WriteLine("OOPs, something went wrong." + e);
            }
            // Closing the connection  
            finally
            {
                con.Close();
            }
        }

        public void DisplayData()
        {
            SqlConnection con = null;
            try
            {
                // Creating Connection  
                con = new SqlConnection(connectionString);
                // writing sql query  
                SqlCommand cm = new SqlCommand("Select * from student", con);
                // Opening Connection  
                con.Open();
                // Executing the SQL query  
                SqlDataReader sdr = cm.ExecuteReader();
                // Iterating Data  
                while (sdr.Read())
                {
                    // Displaying Record  
                    Console.WriteLine(sdr["id"] + " " + sdr["name"] + " " + sdr["email"]);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("OOPs, something went wrong." + e);
            }
            // Closing the connection  
            finally
            {
                con.Close();
            }
        }
    }
}