namespace SEM4_C__POS_pj.view
{
    partial class Category
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
            this.btnCreate = new System.Windows.Forms.Button();
            this.lblRole = new System.Windows.Forms.Label();
            this.txtCategoryname = new System.Windows.Forms.TextBox();
            this.rFalse = new System.Windows.Forms.RadioButton();
            this.rTrue = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.dgcategory = new System.Windows.Forms.DataGridView();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.lblinfo = new System.Windows.Forms.Label();
            this.txtsearch = new System.Windows.Forms.TextBox();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgcategory)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCreate
            // 
            this.btnCreate.BackColor = System.Drawing.Color.LimeGreen;
            this.btnCreate.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCreate.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnCreate.Location = new System.Drawing.Point(921, 44);
            this.btnCreate.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(125, 36);
            this.btnCreate.TabIndex = 29;
            this.btnCreate.Text = "Create";
            this.btnCreate.UseVisualStyleBackColor = false;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // lblRole
            // 
            this.lblRole.AutoSize = true;
            this.lblRole.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRole.Location = new System.Drawing.Point(20, 45);
            this.lblRole.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblRole.Name = "lblRole";
            this.lblRole.Size = new System.Drawing.Size(92, 25);
            this.lblRole.TabIndex = 28;
            this.lblRole.Text = "Category";
            // 
            // txtCategoryname
            // 
            this.txtCategoryname.Location = new System.Drawing.Point(230, 50);
            this.txtCategoryname.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.txtCategoryname.Name = "txtCategoryname";
            this.txtCategoryname.Size = new System.Drawing.Size(622, 30);
            this.txtCategoryname.TabIndex = 30;
            // 
            // rFalse
            // 
            this.rFalse.AutoSize = true;
            this.rFalse.Location = new System.Drawing.Point(350, 104);
            this.rFalse.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rFalse.Name = "rFalse";
            this.rFalse.Size = new System.Drawing.Size(81, 29);
            this.rFalse.TabIndex = 33;
            this.rFalse.TabStop = true;
            this.rFalse.Text = "False";
            this.rFalse.UseVisualStyleBackColor = true;
            // 
            // rTrue
            // 
            this.rTrue.AutoSize = true;
            this.rTrue.Location = new System.Drawing.Point(230, 102);
            this.rTrue.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rTrue.Name = "rTrue";
            this.rTrue.Size = new System.Drawing.Size(74, 29);
            this.rTrue.TabIndex = 32;
            this.rTrue.TabStop = true;
            this.rTrue.Text = "True";
            this.rTrue.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(46, 106);
            this.label4.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 25);
            this.label4.TabIndex = 31;
            this.label4.Text = "Active";
            // 
            // dgcategory
            // 
            this.dgcategory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgcategory.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7});
            this.dgcategory.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgcategory.Location = new System.Drawing.Point(25, 246);
            this.dgcategory.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgcategory.Name = "dgcategory";
            this.dgcategory.RowHeadersWidth = 51;
            this.dgcategory.RowTemplate.Height = 24;
            this.dgcategory.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgcategory.Size = new System.Drawing.Size(1136, 443);
            this.dgcategory.TabIndex = 34;
            this.dgcategory.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgcategory_CellDoubleClick);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.Red;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDelete.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnDelete.Location = new System.Drawing.Point(921, 137);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(125, 39);
            this.btnDelete.TabIndex = 36;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click_1);
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnUpdate.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnUpdate.Location = new System.Drawing.Point(921, 88);
            this.btnUpdate.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(125, 43);
            this.btnUpdate.TabIndex = 35;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // lblinfo
            // 
            this.lblinfo.AutoSize = true;
            this.lblinfo.Location = new System.Drawing.Point(889, 212);
            this.lblinfo.Name = "lblinfo";
            this.lblinfo.Size = new System.Drawing.Size(202, 25);
            this.lblinfo.TabIndex = 38;
            this.lblinfo.Text = "Press Enter to Search";
            // 
            // txtsearch
            // 
            this.txtsearch.Location = new System.Drawing.Point(25, 209);
            this.txtsearch.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtsearch.Name = "txtsearch";
            this.txtsearch.Size = new System.Drawing.Size(849, 30);
            this.txtsearch.TabIndex = 37;
            this.txtsearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtsearch_KeyPress);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "id";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            this.Column1.Width = 125;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "name";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            this.Column2.Width = 125;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "status";
            this.Column3.MinimumWidth = 6;
            this.Column3.Name = "Column3";
            this.Column3.Width = 125;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "createAt";
            this.Column4.MinimumWidth = 6;
            this.Column4.Name = "Column4";
            this.Column4.Width = 125;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "createBy";
            this.Column5.MinimumWidth = 6;
            this.Column5.Name = "Column5";
            this.Column5.Width = 125;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "updateAt";
            this.Column6.MinimumWidth = 6;
            this.Column6.Name = "Column6";
            this.Column6.Width = 125;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "updateBy";
            this.Column7.MinimumWidth = 6;
            this.Column7.Name = "Column7";
            this.Column7.Width = 125;
            // 
            // Category
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 703);
            this.Controls.Add(this.lblinfo);
            this.Controls.Add(this.txtsearch);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.dgcategory);
            this.Controls.Add(this.rFalse);
            this.Controls.Add(this.rTrue);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtCategoryname);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.lblRole);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Category";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Category";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Category_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgcategory)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.Label lblRole;
        private System.Windows.Forms.TextBox txtCategoryname;
        private System.Windows.Forms.RadioButton rFalse;
        private System.Windows.Forms.RadioButton rTrue;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dgcategory;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Label lblinfo;
        private System.Windows.Forms.TextBox txtsearch;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
    }
}