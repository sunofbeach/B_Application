using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;

/*
Banking Application
Sheridan College 2015 by   
Zachary Auld & Yao Wang
*/

namespace Banking_Application
{
    public partial class Form1 : Form
    {
        private enum ControlState { None_Mode, Add_Mode, UpdateRemove_Mode, Transaction_Mode, View_Mode }
        private SqlConnection mConn = null;
        private SqlCommand mCmd = null;
        private string origAcct = "";
        private double origBal = 0d;
        private const string mDatabaseName = "Bank.mdf";
        private string _mConnStr = null;
        private string mConnStr
        {
            get
            {
                if (_mConnStr == null)
                {
                    string stringdataDir = System.AppDomain.CurrentDomain.BaseDirectory;
                    if (stringdataDir.EndsWith(@"\bin\Debug\") || stringdataDir.EndsWith(@"\bin\Release\"))
                    {
                        stringdataDir = System.IO.Directory.GetParent(stringdataDir).Parent.Parent.FullName;
                        System.AppDomain.CurrentDomain.SetData("DataDirectory", stringdataDir);
                    }
                    _mConnStr = "Data Source=(LocalDB)\\v11.0;AttachDbFilename=" + stringdataDir + "\\" + mDatabaseName + ";Integrated Security=True";

                }
                return _mConnStr;
            }
        }
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            //Disable Right-click menu for text fields
            txtAcct.ContextMenu = new System.Windows.Forms.ContextMenu();
            txtClient.ContextMenu = new System.Windows.Forms.ContextMenu();
            txtBalance.ContextMenu = new System.Windows.Forms.ContextMenu();

            //Assigning keypress event handlers
            dataGridView1.Click += dataGridView1_Click;
            getData();
            txtAcct.KeyPress += txtAcct_KeyPress;
            txtClient.KeyPress += txtClient_KeyPress;
            txtBalance.KeyPress += txtBalance_KeyPress;
            dataGridView1.KeyDown += dataGridView1_KeyDown;

            dataGridView1.ClearSelection();
        }
        void dataGridView1_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Down:
                case Keys.Up:
                case Keys.PageUp:
                case Keys.PageDown:
                case Keys.Return:
                    e.Handled = true;
                    break;
            }
        }
        void txtAcct_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Only Allow Numbers to be Entered, and set minimum length(not decided yet)
            int c = e.KeyChar;
            int len = ((TextBox)sender).Text.Length;
            ((TextBox)sender).SelectionStart = len;
            if (c != 8)
            {
                if (c < 48 || c > 57)
                {
                    e.Handled = true;
                }
            }
        }
        void txtClient_KeyPress(object sender, KeyPressEventArgs e)
        {

        }
        void txtBalance_KeyPress(object sender, KeyPressEventArgs e)
        {

        }
        void dataGridView1_Click(object sender, EventArgs e)
        {
            if (cmdAdd.Text.Equals("Add Account"))
            {
                dataGridView1.CurrentRow.Selected = true;
                txtAcct.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                txtClient.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                txtBalance.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                origAcct = txtAcct.Text;
                setControlState(ControlState.UpdateRemove_Mode);
            }
        }

        private void getData()
        {

            try
            {
                mConn = new SqlConnection(mConnStr);
                mConn.Open();
                mCmd = new SqlCommand();
                mCmd.Connection = mConn;
                mCmd.CommandText = "SELECT * FROM [tAccounts] ORDER BY [Account#] ASC";
                SqlDataReader dr = mCmd.ExecuteReader();

                if (dr.HasRows)
                {
                    //bind and display
                    bindingSource1.DataSource = dr;
                    dataGridView1.DataSource = bindingSource1;
                    dataGridView1.ClearSelection();

                    //Auto resize column widths
                    dataGridView1.AutoResizeColumns();
                }
                dr.Close();
                mConn.Close();
            }
            catch (SqlException ex)
            {
                if (mConn != null)
                {
                    mConn.Close();
                }
                MessageBox.Show(ex.Message, "Error Reading Data.");
            }
        }
        private void getTData()
        {
            try
            {
                mConn = new SqlConnection(mConnStr);
                mConn.Open();
                mCmd = new SqlCommand();
                mCmd.Connection = mConn;
                mCmd.CommandText = "SELECT * FROM [tAccounts] WHERE [Account#] = '" + txtAcct.Text + "' ORDER BY [Account#] ASC";
                SqlDataReader dr = mCmd.ExecuteReader();

                if (dr.HasRows)
                {
                    //bind and display
                    bindingSource1.DataSource = dr;
                    dataGridView1.DataSource = bindingSource1;
                    dataGridView1.ClearSelection();

                    //Auto resize column widths
                    dataGridView1.AutoResizeColumns();
                }
                dr.Close();
                mConn.Close();
            }
            catch (SqlException ex)
            {
                if (mConn != null)
                {
                    mConn.Close();
                }
                MessageBox.Show(ex.Message, "Error Reading Data.");
            }
        }
        private void cmdAdd_Click(object sender, EventArgs e)
        {
            //Check button state
            if (cmdAdd.Text.Equals("Return to Add Mode"))
            {
                setControlState(ControlState.Add_Mode);
                return;
            }

            if (isValidAcct() && fieldsNotEmpty())
            {
                try
                {
                    string sql = "INSERT INTO [tAccounts] ([Account#],[Client],[Balance],[Last Transaction]) VALUES ('" + txtAcct.Text + "','" + txtClient.Text + "','" + txtBalance.Text + "','" + DateTime.Now + "')";
                    if (mConn.State != ConnectionState.Open)
                    {
                        mConn.Open();
                    }
                    mCmd = new SqlCommand(sql, mConn);
                    mCmd.ExecuteNonQuery();
                    MessageBox.Show("Account " + txtAcct.Text + " successfully created for " + txtClient.Text, "Account Added Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    getData();
                    clearText();
                    mConn.Close();
                }
                catch (SqlException ex)
                {
                    if (mConn != null)
                    {
                        mConn.Close();
                    }
                    MessageBox.Show(ex.Message, "Invalid Account", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }
        private void cmdUpdate_Click(object sender, EventArgs e)
        {
            if (cmdUpdate.Text.Equals("Withdraw"))
            {
                string sql = "UPDATE [tAccounts] SET [Balance] = '" + (origBal - Convert.ToDouble(txtBalance.Text)) + "', [Last Transaction] = '" + DateTime.Now + "' WHERE [Account#] = '" + txtAcct.Text + "'";
                try
                {
                    mConn.Open();
                    mCmd.CommandText = sql;
                    mCmd.ExecuteNonQuery();
                    mConn.Close();
                    getTData();
                }
                catch (SqlException ex)
                {
                    if (mConn != null)
                    {
                        mConn.Close();
                    }
                    MessageBox.Show(ex.Message, "Error Making Transaction.");
                }
            }
            else
            {
                string sql = "UPDATE [tAccounts] SET [Account#] = '" + txtAcct.Text + "', [Client] = '" + txtClient.Text + "', [Balance] = '" + txtBalance.Text + "' WHERE [Account#] = '" + origAcct + "'";
                try
                {
                    mConn.Open();
                    mCmd.CommandText = sql;
                    mCmd.ExecuteNonQuery();
                    mConn.Close();
                    getData();
                }
                catch (SqlException ex)
                {
                    if (mConn != null)
                    {
                        mConn.Close();
                    }
                    MessageBox.Show(ex.Message, "Error Updating Account.");
                }
                setControlState(ControlState.Add_Mode);
            }
        }
        private void cmdRemove_Click(object sender, EventArgs e)
        {
            if (cmdRemove.Text.Equals("Deposit"))
            {

            }
            else
            {
                if (MessageBox.Show("Are you sure you want to remove this account?", "Confirm Record Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.Yes)
                {
                    string sql = "DELETE FROM [tAccounts] WHERE [Account#] = '" + origAcct + "'";
                    try
                    {
                        mConn.Open();
                        mCmd.CommandText = sql;
                        mCmd.ExecuteNonQuery();
                        mConn.Close();
                        getData();
                    }
                    catch (SqlException ex)
                    {
                        if (mConn != null)
                        {
                            mConn.Close();
                        }
                        MessageBox.Show(ex.Message, "Error Deleting Record.");
                    }
                }
                setControlState(ControlState.Add_Mode);
            }
        }
        private void cmdTrans_Click(object sender, EventArgs e)
        {
            setControlState(ControlState.Transaction_Mode);
        }
        private void cmdView_Click(object sender, EventArgs e)
        {
            setControlState(ControlState.View_Mode);
        }
        private void clearText()
        {
            txtAcct.Text = "";
            txtClient.Text = "";
            txtBalance.Text = "";
            txtAcct.Focus();
            dataGridView1.ClearSelection();
        }
        private bool isValidAcct()
        {
            return true;
        }
        private bool fieldsNotEmpty()
        {
            //Checks the fields to avoid entering null data
            if (txtAcct.TextLength != 0 && txtClient.TextLength != 0 && txtBalance.TextLength != 0)
            {
                return true;
            }
            else
            {
                MessageBox.Show("All fields must be filled in!", "Missing Account Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
        }
        private void setControlState(ControlState state)
        {
            switch (state)
            {
                case ControlState.Add_Mode:
                    clearText();
                    cmdAdd.Text = "Add Account";
                    cmdUpdate.Text = "Update Account";
                    cmdRemove.Text = "Remove Account";
                    cmdView.Text = "View Transactions";
                    cmdUpdate.Enabled = false;
                    cmdRemove.Enabled = false;
                    cmdTrans.Enabled = false;
                    cmdView.Enabled = false;
                    txtBalance.Enabled = true;
                    txtAcct.Enabled = true;
                    dataGridView1.ClearSelection();
                    getData();
                    break;
                case ControlState.UpdateRemove_Mode:
                    cmdAdd.Text = "Return to Add Mode";
                    cmdUpdate.Enabled = true;
                    cmdRemove.Enabled = true;
                    cmdTrans.Enabled = true;
                    cmdView.Enabled = true;
                    txtAcct.Enabled = true;
                    txtClient.Enabled = true;
                    txtBalance.Enabled = false;
                    break;
                case ControlState.Transaction_Mode:
                    cmdAdd.Text = "Return to Add Mode";
                    cmdUpdate.Text = "Withdraw";
                    cmdRemove.Text = "Deposit";
                    txtAcct.Enabled = false;
                    txtBalance.Enabled = true;
                    origBal = Convert.ToDouble(txtBalance.Text);
                    txtBalance.Text = "";
                    cmdTrans.Enabled = false;
                    cmdView.Enabled = true;
                    getTData();
                    break;
                case ControlState.View_Mode:
                    clearText();
                    txtAcct.Enabled = false;
                    txtClient.Enabled = false;
                    txtBalance.Enabled = false;
                    cmdUpdate.Enabled = false;
                    cmdRemove.Enabled = false;
                    cmdTrans.Enabled = true;
                    cmdView.Enabled = false;
                    break;
                case ControlState.None_Mode:
                default:
                    break;
            }
        }
    }
}
