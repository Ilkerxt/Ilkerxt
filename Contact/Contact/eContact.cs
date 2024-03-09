using Contact.econtactClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Contact
{
    public partial class eContact : Form
    {
        public eContact()
        {
            InitializeComponent();
        }
        contactClass c = new contactClass();

        private void btnAdd_Click(object sender, EventArgs e)
        {
            c.FirstName = txtFirstName.Text;
            c.LastName = txtLastName.Text;
            c.ContactNo = txtContactNo.Text;
            c.Adress = txtAdress.Text;
            c.Gender = cmbGender.Text;

            bool success = c.Insert(c);
            if (success = true)
            {
                MessageBox.Show("New Contact Successfully Inserted!");
                Clear();
            }
            else
            {
                MessageBox.Show("Failed to add new Contact! Please Try Again!");
            }
            DataTable dt = c.Select();
            dgvContactList.DataSource = dt;
        }

        private void eContact_Load(object sender, EventArgs e)
        {
            DataTable dt = c.Select();
            dgvContactList.DataSource = dt;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public void Clear()
        {
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtContactNo.Text = "";
            txtAdress.Text = "";
            cmbGender.Text = "";
            txtContactID.Text = "";
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            c.ContactID = int.Parse(txtContactID.Text);
            c.FirstName = txtFirstName.Text;
            c.LastName = txtLastName.Text;
            c.ContactNo = txtContactNo.Text;
            c.Adress = txtAdress.Text;
            c.Gender = cmbGender.Text;
            bool success = c.Update(c);
            if (success = true)
            {
                MessageBox.Show("Contact has been successfully Updated!");
                DataTable dt = c.Select();
                dgvContactList.DataSource = dt;
                Clear();
            }
            else
            {
                MessageBox.Show("Failed to Update Contact! Please try again!");
            }
        }

        private void dgvContactList_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int rowIndex = e.RowIndex;
            txtContactID.Text = dgvContactList.Rows[rowIndex].Cells[0].Value.ToString();
            txtFirstName.Text = dgvContactList.Rows[rowIndex].Cells[1].Value.ToString();
            txtLastName.Text = dgvContactList.Rows[rowIndex].Cells[2].Value.ToString();
            txtContactNo.Text = dgvContactList.Rows[rowIndex].Cells[3].Value.ToString();
            txtAdress.Text = dgvContactList.Rows[rowIndex].Cells[4].Value.ToString();
            cmbGender.Text = dgvContactList.Rows[rowIndex].Cells[5].Value.ToString();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            c.ContactID = Convert.ToInt32(txtContactID.Text);
            bool success = c.Delete(c);
            if (success = true)
            {
                MessageBox.Show("Contact successfully deleted!");
                DataTable dt = c.Select();
                dgvContactList.DataSource = dt;
                Clear();
            }
            else
            {
                MessageBox.Show("Failed to delete Contact! Please try again!");
            }
        }
        static string myconnstr = ConfigurationManager.ConnectionStrings["connstrgn"].ConnectionString;

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text;
            SqlConnection conn = new SqlConnection(myconnstr);
            SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM tblContact WHERE FirstName LIKE'%"+keyword+"%' OR LastName LIKE '%"+keyword+ "%' OR Adress LIKE '%"+keyword+"%'", conn);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dgvContactList.DataSource = dt;

        }
    }
}
