namespace Banking_Application
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtAcct = new System.Windows.Forms.TextBox();
            this.txtClient = new System.Windows.Forms.TextBox();
            this.txtBalance = new System.Windows.Forms.TextBox();
            this.cmdAdd = new System.Windows.Forms.Button();
            this.cmdUpdate = new System.Windows.Forms.Button();
            this.cmdRemove = new System.Windows.Forms.Button();
            this.cmdTrans = new System.Windows.Forms.Button();
            this.cmdView = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(163, 14);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(407, 202);
            this.dataGridView1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 15);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Account#";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 60);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Client";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 105);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 15);
            this.label3.TabIndex = 3;
            this.label3.Text = "Balance";
            // 
            // txtAcct
            // 
            this.txtAcct.Location = new System.Drawing.Point(21, 33);
            this.txtAcct.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtAcct.Name = "txtAcct";
            this.txtAcct.Size = new System.Drawing.Size(132, 25);
            this.txtAcct.TabIndex = 4;
            // 
            // txtClient
            // 
            this.txtClient.Location = new System.Drawing.Point(21, 78);
            this.txtClient.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtClient.Name = "txtClient";
            this.txtClient.Size = new System.Drawing.Size(132, 25);
            this.txtClient.TabIndex = 5;
            // 
            // txtBalance
            // 
            this.txtBalance.Location = new System.Drawing.Point(21, 123);
            this.txtBalance.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtBalance.Name = "txtBalance";
            this.txtBalance.Size = new System.Drawing.Size(132, 25);
            this.txtBalance.TabIndex = 6;
            // 
            // cmdAdd
            // 
            this.cmdAdd.Location = new System.Drawing.Point(21, 155);
            this.cmdAdd.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cmdAdd.Name = "cmdAdd";
            this.cmdAdd.Size = new System.Drawing.Size(133, 27);
            this.cmdAdd.TabIndex = 7;
            this.cmdAdd.Text = "Add Account";
            this.cmdAdd.UseVisualStyleBackColor = true;
            this.cmdAdd.Click += new System.EventHandler(this.cmdAdd_Click);
            // 
            // cmdUpdate
            // 
            this.cmdUpdate.Enabled = false;
            this.cmdUpdate.Location = new System.Drawing.Point(21, 189);
            this.cmdUpdate.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cmdUpdate.Name = "cmdUpdate";
            this.cmdUpdate.Size = new System.Drawing.Size(133, 27);
            this.cmdUpdate.TabIndex = 8;
            this.cmdUpdate.Text = "Update Account";
            this.cmdUpdate.UseVisualStyleBackColor = true;
            this.cmdUpdate.Click += new System.EventHandler(this.cmdUpdate_Click);
            // 
            // cmdRemove
            // 
            this.cmdRemove.Enabled = false;
            this.cmdRemove.Location = new System.Drawing.Point(21, 224);
            this.cmdRemove.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cmdRemove.Name = "cmdRemove";
            this.cmdRemove.Size = new System.Drawing.Size(133, 27);
            this.cmdRemove.TabIndex = 9;
            this.cmdRemove.Text = "Remove Account";
            this.cmdRemove.UseVisualStyleBackColor = true;
            this.cmdRemove.Click += new System.EventHandler(this.cmdRemove_Click);
            // 
            // cmdTrans
            // 
            this.cmdTrans.Enabled = false;
            this.cmdTrans.Location = new System.Drawing.Point(163, 223);
            this.cmdTrans.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cmdTrans.Name = "cmdTrans";
            this.cmdTrans.Size = new System.Drawing.Size(208, 27);
            this.cmdTrans.TabIndex = 10;
            this.cmdTrans.Text = "Make Transaction";
            this.cmdTrans.UseVisualStyleBackColor = true;
            this.cmdTrans.Click += new System.EventHandler(this.cmdTrans_Click);
            // 
            // cmdView
            // 
            this.cmdView.Enabled = false;
            this.cmdView.Location = new System.Drawing.Point(379, 223);
            this.cmdView.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cmdView.Name = "cmdView";
            this.cmdView.Size = new System.Drawing.Size(189, 27);
            this.cmdView.TabIndex = 11;
            this.cmdView.Text = "View Transactions";
            this.cmdView.UseVisualStyleBackColor = true;
            this.cmdView.Click += new System.EventHandler(this.cmdView_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(585, 262);
            this.Controls.Add(this.cmdView);
            this.Controls.Add(this.cmdTrans);
            this.Controls.Add(this.cmdRemove);
            this.Controls.Add(this.cmdUpdate);
            this.Controls.Add(this.cmdAdd);
            this.Controls.Add(this.txtBalance);
            this.Controls.Add(this.txtClient);
            this.Controls.Add(this.txtAcct);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "Form1";
            this.Text = "Banking Application";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtAcct;
        private System.Windows.Forms.TextBox txtClient;
        private System.Windows.Forms.TextBox txtBalance;
        private System.Windows.Forms.Button cmdAdd;
        private System.Windows.Forms.Button cmdUpdate;
        private System.Windows.Forms.Button cmdRemove;
        private System.Windows.Forms.Button cmdTrans;
        private System.Windows.Forms.Button cmdView;
    }
}

