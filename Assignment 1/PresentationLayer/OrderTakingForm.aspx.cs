using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Assignment_1.PresentationLayer
{
    public partial class OrderTakingForm : System.Web.UI.Page
    {
        SqlConnection sqlConnection = new SqlConnection(@"Data Source=20.200.20.10;Initial Catalog=Northwind-QA;User ID=diyatech;Password=4Islamabad");
        protected Boolean isUpdate = false;

        public string CustomerId => tbCustomerID.Text.Trim();
        
        public void CreateEntry()
        {
            if (sqlConnection.State == ConnectionState.Closed)
                sqlConnection.Open();
            SqlCommand sqlCommand = new SqlCommand("CustomerCreate", sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@CustomerID", tbCustomerID.Text.Trim());
            sqlCommand.Parameters.AddWithValue("@CompanyName", tbCompanyName.Text.Trim());
            sqlCommand.Parameters.AddWithValue("@ContactName", tbName.Text.Trim());
            sqlCommand.Parameters.AddWithValue("@Address", tbAddress.Text.Trim());
            sqlCommand.Parameters.AddWithValue("@ContactTitle", tbContactTitle.Text.Trim());
            sqlCommand.Parameters.AddWithValue("@City", tbCity.Text.Trim());
            sqlCommand.Parameters.AddWithValue("@Region", tbRegion.Text.Trim());
            Console.WriteLine("All Okay");
            sqlCommand.Parameters.AddWithValue("@PostalCode", (tbPostalCode.Text.Trim()));
            Console.WriteLine(tbPostalCode);
            sqlCommand.Parameters.AddWithValue("@Country", tbCountry.Text.Trim());
            sqlCommand.Parameters.AddWithValue("@Phone", tbPhone.Text.Trim());
            sqlCommand.Parameters.AddWithValue("@Fax", ((tbFax.Text.Trim())));
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
        }

        public void UpdateEntry()
        {
            if (sqlConnection.State == ConnectionState.Closed)
                sqlConnection.Open();
            SqlCommand sqlCommand = new SqlCommand("CustomerUpdate", sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@CustomerID", tbCustomerID.Text.Trim());
            sqlCommand.Parameters.AddWithValue("@CompanyName", tbCompanyName.Text.Trim());
            sqlCommand.Parameters.AddWithValue("@ContactName", tbName.Text.Trim());
            sqlCommand.Parameters.AddWithValue("@Address", tbAddress.Text.Trim());
            sqlCommand.Parameters.AddWithValue("@ContactTitle", tbContactTitle.Text.Trim());
            sqlCommand.Parameters.AddWithValue("@City", tbCity.Text.Trim());
            sqlCommand.Parameters.AddWithValue("@Region", tbRegion.Text.Trim());
            sqlCommand.Parameters.AddWithValue("@PostalCode", (tbPostalCode.Text.Trim()));
            sqlCommand.Parameters.AddWithValue("@Country", tbCountry.Text.Trim());
            sqlCommand.Parameters.AddWithValue("@Phone", tbPhone.Text.Trim());
            sqlCommand.Parameters.AddWithValue("@Fax", (tbFax.Text.Trim()));
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
        }

        public void Clear()
        {
            tbCustomerID.Text = tbCompanyName.Text = tbName.Text = tbContactTitle.Text = "";
            tbAddress.Text = tbCity.Text = tbRegion.Text = tbPostalCode.Text = "";
            tbCountry.Text = tbPhone.Text = tbFax.Text = "";

            btnEdit.Enabled = false;
            btnDelete.Enabled = false;

            tbCustomerID.ReadOnly = false;
            tbCompanyName.ReadOnly = false;
            tbName.ReadOnly = false;
            tbContactTitle.ReadOnly = false;
            tbAddress.ReadOnly = false;
            tbCity.ReadOnly = false;
            tbRegion.ReadOnly = false;
            tbPostalCode.ReadOnly = false;
            tbCountry.ReadOnly = false;
            tbPhone.ReadOnly = false;
            tbFax.ReadOnly = false;
        }

        public void FillGridView()
        {

            if (sqlConnection.State == ConnectionState.Closed)
                sqlConnection.Open();

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("CustomerOrderDetails", sqlConnection);
            sqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            sqlDataAdapter.SelectCommand.Parameters.AddWithValue("@CustomerID", tbCustomerID.Text.Trim().ToCharArray());
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            sqlConnection.Close();
            gvOrders.DataSource = dataTable;
            gvOrders.DataBind();

        }

        protected void Page_Load(object sender, EventArgs e)
        {
            btnSave.Enabled = false;

            tbCustomerID.ReadOnly = true;
            tbCompanyName.ReadOnly = true;
            tbName.ReadOnly = true;
            tbContactTitle.ReadOnly = true;
            tbAddress.ReadOnly = true;
            tbCity.ReadOnly = true;
            tbRegion.ReadOnly = true;
            tbPostalCode.ReadOnly = true;
            tbCountry.ReadOnly = true;
            tbPhone.ReadOnly = true;
            tbFax.ReadOnly = true;

            if (sqlConnection.State == ConnectionState.Closed)
                sqlConnection.Open();
            
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("CustomerViewByID",sqlConnection);
            sqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            sqlDataAdapter.SelectCommand.Parameters.AddWithValue("@CustomerID",tbCustomerID.Text.Trim().ToCharArray());
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            sqlConnection.Close();
            tbCustomerID.Text = tbCustomerID.Text.Trim().ToString();
            tbCompanyName.Text = dataTable.Rows[0]["CompanyName"].ToString();
            tbName.Text = dataTable.Rows[0]["ContactName"].ToString();
            tbContactTitle.Text = dataTable.Rows[0]["ContactTitle"].ToString();
            tbAddress.Text = dataTable.Rows[0]["Address"].ToString();
            tbCity.Text = dataTable.Rows[0]["City"].ToString();
            tbRegion.Text = dataTable.Rows[0]["Region"].ToString();
            tbPostalCode.Text = dataTable.Rows[0]["PostalCode"].ToString();
            tbCountry.Text = dataTable.Rows[0]["Country"].ToString();
            tbPhone.Text = dataTable.Rows[0]["Phone"].ToString();
            tbFax.Text = dataTable.Rows[0]["Fax"].ToString();

            FillGridView();

        }

        protected void btnNew_Click(object sender, EventArgs e)
        {
            Clear();
            isUpdate = false;
            btnSave.Enabled = true;
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            isUpdate = true;

            btnNew.Enabled = false;
            btnDelete.Enabled = false;
            btnSave.Enabled = true;
            btnSave.Text = "Update";

            tbCustomerID.ReadOnly = true;
            tbCompanyName.ReadOnly = false;
            tbName.ReadOnly = false;
            tbContactTitle.ReadOnly = false;
            tbAddress.ReadOnly = false;
            tbCity.ReadOnly = false;
            tbRegion.ReadOnly = false;
            tbPostalCode.ReadOnly = false;
            tbCountry.ReadOnly = false;
            tbPhone.ReadOnly = false;
            tbFax.ReadOnly = false;

            isUpdate = false;

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (isUpdate == true)
            {
                UpdateEntry();
                isUpdate = false;
                tbCustomerID.ReadOnly = false;
            }
            else
            {
                CreateEntry();
            }

            btnNew.Enabled = true;
            btnDelete.Enabled = true;
            btnSave.Text = "Save";
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {

        }

        protected void btnLast_Click(object sender, EventArgs e)
        {

        }

        protected void btnNext_Click(object sender, EventArgs e)
        {

        }

        protected void btnPrev_Click(object sender, EventArgs e)
        {

        }

        protected void btnFirst_Click(object sender, EventArgs e)
        {

        }

        protected void btnPlaceOrder_Click(object sender, EventArgs e)
        {

        }
    }
}