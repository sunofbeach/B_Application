﻿using System;
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
<<<<<<< HEAD
        private string mOrigAcct = "";
        private double mOrigBal = 0d;
        private const string mDatabaseName = "Bank.mdf";
        private const string mTableName = "tAccounts";
        private SqlDataAdapter mDA = null;
        private DataSet mDS = null;
        private int mRowIndex = -1;
=======
        private SqlCommand mCmd = null;
        private string origAcct = "";
        private double origBal = 0d;
        private const string mDatabaseName = "Bank.mdf";
>>>>>>> ffd4384c2269d5a41f5e1854dc5418ff92aaec1d
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
<<<<<<< HEAD
            getData();
            dataGridView1.Click += dataGridView1_Click;
            txtAcct.KeyPress += txtAcct_KeyPress;
            txtAcct.ContextMenuStrip = new System.Windows.Forms.ContextMenuStrip();
            txtClient.KeyPress += txtClient_KeyPress;
            txtClient.ContextMenuStrip = new System.Windows.Forms.ContextMenuStrip();
            txtBalance.KeyPress += txtBalance_KeyPress;
            txtBalance.ContextMenuStrip = new System.Windows.Forms.ContextMenuStrip();
            dataGridView1.Columns["Balance"].DefaultCellStyle.Format = "c";
            dataGridView1.Columns["Balance"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.KeyDown += dataGridView1_KeyDown;
=======
            dataGridView1.Click += dataGridView1_Click;
            getData();
            txtAcct.KeyPress += txtAcct_KeyPress;
            txtClient.KeyPress += txtClient_KeyPress;
            txtBalance.KeyPress += txtBalance_KeyPress;
            dataGridView1.KeyDown += dataGridView1_KeyDown;

>>>>>>> ffd4384c2269d5a41f5e1854dc5418ff92aaec1d
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
<<<<<<< HEAD
            char c = e.KeyChar;
=======
            int c = e.KeyChar;
>>>>>>> ffd4384c2269d5a41f5e1854dc5418ff92aaec1d
            int len = ((TextBox)sender).Text.Length;
            ((TextBox)sender).SelectionStart = len;
            if (c != 8)
            {
<<<<<<< HEAD
                if (len == 0 && (c < 49 || c > 57))
                {
                    e.Handled = true;
                }
                else if (len > 0 && (c < 48 || c > 57))
=======
                if (c < 48 || c > 57)
>>>>>>> ffd4384c2269d5a41f5e1854dc5418ff92aaec1d
                {
                    e.Handled = true;
                }
            }
        }
        void txtClient_KeyPress(object sender, KeyPressEventArgs e)
        {
<<<<<<< HEAD
            char c = e.KeyChar;
            int len = ((TextBox)sender).Text.Length;
            ((TextBox)sender).SelectionStart = len;
            if (c != 8)
            {
                if ((c < 65 || c > 90) && (c < 97 || c > 122))
                {
                    //not letter
                    e.Handled = true;
                }
                else if (len > 0 && (c > 96 && c < 123))
                {
                    //lower case
                    e.KeyChar = (char)(c - 32);
                }
                else if (len > 0 && (c > 64 && c < 91))
                {
                    e.KeyChar = (char)(c + 32);

                }
            }
        }
        void txtBalance_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            int len = ((TextBox)sender).Text.Length;
            ((TextBox)sender).SelectionStart = len;
            if (c != 8)
            {
                if (len == 0 && (c < 48 || c > 57))
                {
                    //first char not numeric digit
                    e.Handled = true;
                }
                else
                {
                    if ((c < 48 || c > 57))
                    {
                        if (c == 46)
                        {
                            if (((TextBox)sender).Text.IndexOf(".") > -1)
                            {
                                e.Handled = true;
                            }
                        }
                        else
                        { e.Handled = true; }
                    }
                    if (((TextBox)sender).Text.IndexOf(".") > -1)
                    {
                        //decimal exists
                        if (len == ((TextBox)sender).Text.IndexOf(".") + 3)
                        { e.Handled = true; }
                    }

                }
            }
=======

        }
        void txtBalance_KeyPress(object sender, KeyPressEventArgs e)
        {

>>>>>>> ffd4384c2269d5a41f5e1854dc5418ff92aaec1d
        }
        void dataGridView1_Click(object sender, EventArgs e)
        {
            if (cmdAdd.Text.Equals("Add Account"))
            {
<<<<<<< HEAD
                mRowIndex = dataGridView1.CurrentRow.Index;

                for (int i = 0; i < mDS.Tables[mTableName].Rows.Count; i++)
                {
                    DataRowState drs = mDS.Tables[mTableName].Rows[i].RowState;
                    if (drs != DataRowState.Deleted)
                    {
                        if (dataGridView1.CurrentRow.Cells[0].Value.ToString().Equals(mDS.Tables[mTableName].Rows[i][0].ToString()))
                        {
                            //item found...reset rowindex
                            mRowIndex = i;
                            break;

                        }
                    }
                }
=======
>>>>>>> ffd4384c2269d5a41f5e1854dc5418ff92aaec1d
                dataGridView1.CurrentRow.Selected = true;
                txtAcct.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                txtClient.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                txtBalance.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
<<<<<<< HEAD
                mOrigAcct = txtAcct.Text;
=======
                origAcct = txtAcct.Text;
>>>>>>> ffd4384c2269d5a41f5e1854dc5418ff92aaec1d
                setControlState(ControlState.UpdateRemove_Mode);
            }
        }

        private void getData()
        {
<<<<<<< HEAD
=======

>>>>>>> ffd4384c2269d5a41f5e1854dc5418ff92aaec1d
            try
            {
                mConn = new SqlConnection(mConnStr);
                mConn.Open();
<<<<<<< HEAD
                string sql = "select * from [" + mTableName + "]";
                mDA = new SqlDataAdapter(sql, mConn);
                SqlCommandBuilder cb = new SqlCommandBuilder(mDA);
                mDS = new DataSet();
                mDA.Fill(mDS, mTableName);
                mConn.Close();
                // display
                bindingSource1.DataSource = mDS;
                bindingSource1.DataMember = mTableName;
                dataGridView1.DataSource = bindingSource1;
                dataGridView1.ClearSelection();

                DataView myView = new DataView(mDS.Tables[mTableName]);
                myView.RowStateFilter = DataViewRowState.CurrentRows | DataViewRowState.Deleted;
                dgView.DataSource = myView;
                dgView.ClearSelection();
=======
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
>>>>>>> ffd4384c2269d5a41f5e1854dc5418ff92aaec1d
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
<<<<<<< HEAD
                    DataRow dr = mDS.Tables[mTableName].NewRow();
                    dr["Account#"] = Convert.ToInt32(txtAcct.Text);
                    dr["Client"] = txtClient.Text;
                    dr["Balance"] = Convert.ToDouble(txtBalance.Text);
                    mDS.Tables[mTableName].Rows.Add(dr);

                    clearText();
                    formatGrid();

=======
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
>>>>>>> ffd4384c2269d5a41f5e1854dc5418ff92aaec1d
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
<<<<<<< HEAD
                try
                {
                    DataRow dr = mDS.Tables[mTableName].Rows[mRowIndex];
                    dr["Account#"] = Convert.ToInt32(txtAcct.Text);
                    dr["Client"] = txtClient.Text;
                    dr["Balance"] = mOrigBal - Convert.ToDouble(txtBalance.Text);
                    dr["Last Transaction"] = DateTime.Now;
                    formatGrid();
=======
                string sql = "UPDATE [tAccounts] SET [Balance] = '" + (origBal - Convert.ToDouble(txtBalance.Text)) + "', [Last Transaction] = '" + DateTime.Now + "' WHERE [Account#] = '" + txtAcct.Text + "'";
                try
                {
                    mConn.Open();
                    mCmd.CommandText = sql;
                    mCmd.ExecuteNonQuery();
                    mConn.Close();
                    getTData();
>>>>>>> ffd4384c2269d5a41f5e1854dc5418ff92aaec1d
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
<<<<<<< HEAD
                try
                {
                    DataRow dr = mDS.Tables[mTableName].Rows[mRowIndex];
                    dr["Account#"] = Convert.ToInt32(txtAcct.Text);
                    dr["Client"] = txtClient.Text;
                    dr["Balance"] = Convert.ToDouble(txtBalance.Text);
                    formatGrid();
=======
                string sql = "UPDATE [tAccounts] SET [Account#] = '" + txtAcct.Text + "', [Client] = '" + txtClient.Text + "', [Balance] = '" + txtBalance.Text + "' WHERE [Account#] = '" + origAcct + "'";
                try
                {
                    mConn.Open();
                    mCmd.CommandText = sql;
                    mCmd.ExecuteNonQuery();
                    mConn.Close();
                    getData();
>>>>>>> ffd4384c2269d5a41f5e1854dc5418ff92aaec1d
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
<<<<<<< HEAD
                DataRow dr = mDS.Tables[mTableName].Rows[mRowIndex];
                dr["Account#"] = Convert.ToInt32(txtAcct.Text);
                dr["Client"] = txtClient.Text;
                dr["Balance"] = mOrigBal + Convert.ToDouble(txtBalance.Text);
                dr["Last Transaction"] = DateTime.Now;
                formatGrid();
=======

>>>>>>> ffd4384c2269d5a41f5e1854dc5418ff92aaec1d
            }
            else
            {
                if (MessageBox.Show("Are you sure you want to remove this account?", "Confirm Record Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.Yes)
                {
<<<<<<< HEAD
                    try
                    {
                        mDS.Tables[mTableName].Rows[mRowIndex].Delete();
                        formatGrid();
=======
                    string sql = "DELETE FROM [tAccounts] WHERE [Account#] = '" + origAcct + "'";
                    try
                    {
                        mConn.Open();
                        mCmd.CommandText = sql;
                        mCmd.ExecuteNonQuery();
                        mConn.Close();
                        getData();
>>>>>>> ffd4384c2269d5a41f5e1854dc5418ff92aaec1d
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
<<<<<<< HEAD
        private bool isValidAcct(bool isAdd = true)
        {
            if (isAdd)
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    if (txtAcct.Text.Equals(dataGridView1.Rows[i].Cells[0].Value.ToString()))
                    {
                        MessageBox.Show("This account exists...Enter new account!", "Primary Key Violation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtAcct.Focus();
                        return false;
                    }
                }
            }
            else
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    if (i != dataGridView1.CurrentRow.Index)
                    {
                        if (txtAcct.Text.Equals(dataGridView1.Rows[i].Cells[0].Value.ToString()))
                        {
                            MessageBox.Show("This account exists...Enter new account!", "Primary Key Violation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtAcct.Focus();
                            return false;
                        }
                    }
                }
            }
=======
        private bool isValidAcct()
        {
>>>>>>> ffd4384c2269d5a41f5e1854dc5418ff92aaec1d
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
<<<<<<< HEAD
                case ControlState.Add_Mode: ModeMethod_Add(); break;
                case ControlState.UpdateRemove_Mode: ModeMethod_UpdateRemove(); break;
                case ControlState.Transaction_Mode: ModeMethod_Transaction(); break;
                case ControlState.View_Mode: ModeMethod_View(); break;
                case ControlState.None_Mode: break;
            }
        }

        private void ModeMethod_Add()
        {
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
        }

        private void ModeMethod_UpdateRemove()
        {
            cmdAdd.Text = "Return to Add Mode";
            cmdUpdate.Enabled = true;
            cmdRemove.Enabled = true;
            cmdTrans.Enabled = true;
            cmdView.Enabled = true;
            txtAcct.Enabled = true;
            txtClient.Enabled = true;
            txtBalance.Enabled = false;
        }

        private void ModeMethod_Transaction()
        {
            cmdAdd.Text = "Return to Add Mode";
            cmdUpdate.Text = "Withdraw";
            cmdRemove.Text = "Deposit";
            txtAcct.Enabled = false;
            txtBalance.Enabled = true;
            mOrigBal = Convert.ToDouble(txtBalance.Text);
            txtBalance.Text = "";
            cmdTrans.Enabled = false;
            cmdView.Enabled = true;
        }

        private void ModeMethod_View()
        {
            clearText();
            txtAcct.Enabled = false;
            txtClient.Enabled = false;
            txtBalance.Enabled = false;
            cmdUpdate.Enabled = false;
            cmdRemove.Enabled = false;
            cmdTrans.Enabled = true;
            cmdView.Enabled = false;
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void formatGrid()
        {
            for (int i = 0; i < mDS.Tables[mTableName].Rows.Count; i++)
            {
                DataRowState mDRS = mDS.Tables[mTableName].Rows[i].RowState;
                switch (mDRS)
                {
                    case DataRowState.Unchanged:
                        dgView.Rows[i].DefaultCellStyle.BackColor = Color.White;
                        break;
                    case DataRowState.Added:
                        dgView.Rows[i].DefaultCellStyle.BackColor = Color.Green;
                        break;
                    case DataRowState.Modified:
                        dgView.Rows[i].DefaultCellStyle.BackColor = Color.Blue;
                        break;
                    case DataRowState.Deleted:
                        dgView.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                        break;
                }
            }
            try
            {
                mConn.Open();
                mDA.Update(mDS, mTableName);
                mConn.Close();
            }
            catch (SqlException ex)
            {
                if (mConn != null)
                {
                    mConn.Close();
                }
                MessageBox.Show(ex.Message, "Error Updating Database");
            }

=======
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
>>>>>>> ffd4384c2269d5a41f5e1854dc5418ff92aaec1d
        }
    }
}
