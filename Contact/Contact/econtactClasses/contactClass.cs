using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact.econtactClasses
{
    public class contactClass
    {
        public int ContactID {  get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ContactNo { get; set; }
        public string Adress { get; set; }
        public string Gender { get; set; }

        static string myConnectionString = ConfigurationManager.ConnectionStrings["connstrgn"].ConnectionString;

        public DataTable Select()
        {
            SqlConnection conn = new SqlConnection(myConnectionString);
            DataTable dt = new DataTable();
            try
            {
                string sql = "SELECT * FROM Contacts";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                conn.Open();
                adapter.Fill(dt);
            }
            catch (Exception ex)
            {

            }
            finally
            {
                conn.Close();
            }
            return dt;
        }
        public bool Insert(contactClass c)
        {
            bool isSuccess = false;
            SqlConnection conn = new SqlConnection(myConnectionString);
            try
            {
                string sql = "INSERT INTO Contacts (FirstName, LastName, ContactNo, Adress, Gender) VALUE(@FirstName, @LastName, @ContactNo, @Adress, @Gender)";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@FirstName", c.FirstName);
                cmd.Parameters.AddWithValue("@LastName", c.LastName);
                cmd.Parameters.AddWithValue("@ContactNo", c.ContactNo);
                cmd.Parameters.AddWithValue("@Adress", c.Adress);
                cmd.Parameters.AddWithValue("@Gender", c.Gender);
                conn.Open();
                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                {
                    isSuccess = true;
                }
                else
                {
                    isSuccess = false;
                }
            }
            catch (Exception ex)
            {
               
            }
            finally
            {
                conn.Close();
            }
            return isSuccess;
        }
        public bool Update(contactClass c)
        {
            bool isSucces = false;
            SqlConnection conn = new SqlConnection(myConnectionString);
            try
            {
                string sql = "UPDATE Contacts SET FirstName = @FirstName, LastName = @LastName, ContactNo = @ContactNo, Adress = @Adress, Gender = @Gender WHERE ContactID = @ContactID";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("FirstName", c.FirstName);
                cmd.Parameters.AddWithValue("LastName", c.LastName);
                cmd.Parameters.AddWithValue("ContactNo", c.ContactNo);
                cmd.Parameters.AddWithValue("Adress", c.Adress);
                cmd.Parameters.AddWithValue("Gender", c.Gender);
                cmd.Parameters.AddWithValue("ContactID", c.ContactID);
                conn.Open();
                int rows = cmd.ExecuteNonQuery();
                if(rows > 0)
                {
                    isSucces = true;
                }
                else
                {
                    isSucces= false;
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                conn.Close();
            }
            return isSucces;
        }
        public bool Delete(contactClass c)
        {
            bool isSucces = false;
            SqlConnection conn = new SqlConnection(myConnectionString);
            try
            {
                string sql = "DELETE FROM Contacts WHERE ContactID = @ContactID";
                SqlCommand  cmd = new SqlCommand (sql, conn);
                cmd.Parameters.AddWithValue("ContactID", c.ContactID);
                conn.Open();
                int rows = cmd.ExecuteNonQuery ();
                if (true)
                {
                    isSucces = true;
                }
                else
                {
                    isSucces = false;
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                conn.Close();
            }
            return isSucces;
        }
    }
}
