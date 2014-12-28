namespace AndoirdDatabaseHelper
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
            this.label1 = new System.Windows.Forms.Label();
            this.btnAnalyse = new System.Windows.Forms.Button();
            this.clAttributes = new System.Windows.Forms.CheckedListBox();
            this.btnAddAttr = new System.Windows.Forms.Button();
            this.txtClassName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.gbClass = new System.Windows.Forms.GroupBox();
            this.btnCreateQuery = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.cbPK = new System.Windows.Forms.ComboBox();
            this.txtClass = new System.Windows.Forms.RichTextBox();
            this.gbClass.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Paste class";
            // 
            // btnAnalyse
            // 
            this.btnAnalyse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAnalyse.Location = new System.Drawing.Point(416, 193);
            this.btnAnalyse.Name = "btnAnalyse";
            this.btnAnalyse.Size = new System.Drawing.Size(75, 23);
            this.btnAnalyse.TabIndex = 2;
            this.btnAnalyse.Text = "Analyse";
            this.btnAnalyse.UseVisualStyleBackColor = true;
            this.btnAnalyse.Click += new System.EventHandler(this.btnAnalyse_Click);
            // 
            // clAttributes
            // 
            this.clAttributes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.clAttributes.Location = new System.Drawing.Point(20, 47);
            this.clAttributes.Name = "clAttributes";
            this.clAttributes.Size = new System.Drawing.Size(434, 139);
            this.clAttributes.TabIndex = 3;
            this.clAttributes.SelectedValueChanged += new System.EventHandler(this.clAttributes_SelectedValueChanged);
            // 
            // btnAddAttr
            // 
            this.btnAddAttr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddAttr.Location = new System.Drawing.Point(360, 57);
            this.btnAddAttr.Name = "btnAddAttr";
            this.btnAddAttr.Size = new System.Drawing.Size(84, 23);
            this.btnAddAttr.TabIndex = 4;
            this.btnAddAttr.Text = "Add attribute";
            this.btnAddAttr.UseVisualStyleBackColor = true;
            this.btnAddAttr.Click += new System.EventHandler(this.btnAddAttr_Click);
            // 
            // txtClassName
            // 
            this.txtClassName.Location = new System.Drawing.Point(87, 21);
            this.txtClassName.Name = "txtClassName";
            this.txtClassName.Size = new System.Drawing.Size(173, 20);
            this.txtClassName.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Class name:";
            // 
            // gbClass
            // 
            this.gbClass.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbClass.Controls.Add(this.btnAddAttr);
            this.gbClass.Controls.Add(this.btnCreateQuery);
            this.gbClass.Controls.Add(this.label3);
            this.gbClass.Controls.Add(this.cbPK);
            this.gbClass.Controls.Add(this.clAttributes);
            this.gbClass.Controls.Add(this.label2);
            this.gbClass.Controls.Add(this.txtClassName);
            this.gbClass.Enabled = false;
            this.gbClass.Location = new System.Drawing.Point(15, 222);
            this.gbClass.Name = "gbClass";
            this.gbClass.Size = new System.Drawing.Size(476, 247);
            this.gbClass.TabIndex = 7;
            this.gbClass.TabStop = false;
            this.gbClass.Text = "Analysed class";
            // 
            // btnCreateQuery
            // 
            this.btnCreateQuery.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCreateQuery.Location = new System.Drawing.Point(319, 193);
            this.btnCreateQuery.Name = "btnCreateQuery";
            this.btnCreateQuery.Size = new System.Drawing.Size(135, 48);
            this.btnCreateQuery.TabIndex = 9;
            this.btnCreateQuery.Text = "Create database code";
            this.btnCreateQuery.UseVisualStyleBackColor = true;
            this.btnCreateQuery.Click += new System.EventHandler(this.btnCreateQuery_Click);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(266, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Primary key :";
            // 
            // cbPK
            // 
            this.cbPK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbPK.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPK.FormattingEnabled = true;
            this.cbPK.Location = new System.Drawing.Point(333, 21);
            this.cbPK.Name = "cbPK";
            this.cbPK.Size = new System.Drawing.Size(121, 21);
            this.cbPK.TabIndex = 7;
            // 
            // txtClass
            // 
            this.txtClass.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtClass.Location = new System.Drawing.Point(15, 31);
            this.txtClass.Name = "txtClass";
            this.txtClass.Size = new System.Drawing.Size(476, 156);
            this.txtClass.TabIndex = 8;
            this.txtClass.Text = "public class Student{\n\n     private int id;\n     private String name;\n     privat" +
    "e String lastName;\n     private boolean active;\n\n}";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(503, 481);
            this.Controls.Add(this.txtClass);
            this.Controls.Add(this.gbClass);
            this.Controls.Add(this.btnAnalyse);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.gbClass.ResumeLayout(false);
            this.gbClass.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAnalyse;
        private System.Windows.Forms.CheckedListBox clAttributes;
        private System.Windows.Forms.Button btnAddAttr;
        private System.Windows.Forms.TextBox txtClassName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox gbClass;
        private System.Windows.Forms.Button btnCreateQuery;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbPK;
        private System.Windows.Forms.RichTextBox txtClass;
    }
}

