namespace FenixMusic
{
    partial class FormStation
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormStation));
            this.visualStudio2012DarkTheme = new Telerik.WinControls.Themes.VisualStudio2012DarkTheme();
            this.gbEnterData = new Telerik.WinControls.UI.RadGroupBox();
            this.txtCategories = new Telerik.WinControls.UI.RadTextBox();
            this.txtLink = new Telerik.WinControls.UI.RadTextBox();
            this.txtName = new Telerik.WinControls.UI.RadTextBox();
            this.lblCategories = new Telerik.WinControls.UI.RadLabel();
            this.lblLink = new Telerik.WinControls.UI.RadLabel();
            this.lblName = new Telerik.WinControls.UI.RadLabel();
            this.btnSave = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)(this.gbEnterData)).BeginInit();
            this.gbEnterData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtCategories)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLink)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblCategories)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblLink)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSave)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // gbEnterData
            // 
            this.gbEnterData.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.gbEnterData.Controls.Add(this.txtCategories);
            this.gbEnterData.Controls.Add(this.txtLink);
            this.gbEnterData.Controls.Add(this.txtName);
            this.gbEnterData.Controls.Add(this.lblCategories);
            this.gbEnterData.Controls.Add(this.lblLink);
            this.gbEnterData.Controls.Add(this.lblName);
            this.gbEnterData.HeaderText = "Enter data";
            this.gbEnterData.Location = new System.Drawing.Point(12, 12);
            this.gbEnterData.Name = "gbEnterData";
            this.gbEnterData.Size = new System.Drawing.Size(366, 182);
            this.gbEnterData.TabIndex = 0;
            this.gbEnterData.Text = "Enter data";
            this.gbEnterData.ThemeName = "VisualStudio2012Dark";
            // 
            // txtCategories
            // 
            this.txtCategories.Location = new System.Drawing.Point(102, 129);
            this.txtCategories.MinimumSize = new System.Drawing.Size(0, 24);
            this.txtCategories.Name = "txtCategories";
            // 
            // 
            // 
            this.txtCategories.RootElement.MinSize = new System.Drawing.Size(0, 24);
            this.txtCategories.Size = new System.Drawing.Size(238, 24);
            this.txtCategories.TabIndex = 5;
            this.txtCategories.ThemeName = "VisualStudio2012Dark";
            // 
            // txtLink
            // 
            this.txtLink.Location = new System.Drawing.Point(102, 83);
            this.txtLink.MinimumSize = new System.Drawing.Size(0, 24);
            this.txtLink.Name = "txtLink";
            // 
            // 
            // 
            this.txtLink.RootElement.MinSize = new System.Drawing.Size(0, 24);
            this.txtLink.Size = new System.Drawing.Size(238, 24);
            this.txtLink.TabIndex = 4;
            this.txtLink.ThemeName = "VisualStudio2012Dark";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(102, 36);
            this.txtName.MinimumSize = new System.Drawing.Size(0, 24);
            this.txtName.Name = "txtName";
            // 
            // 
            // 
            this.txtName.RootElement.MinSize = new System.Drawing.Size(0, 24);
            this.txtName.Size = new System.Drawing.Size(238, 24);
            this.txtName.TabIndex = 3;
            this.txtName.ThemeName = "VisualStudio2012Dark";
            // 
            // lblCategories
            // 
            this.lblCategories.Location = new System.Drawing.Point(25, 131);
            this.lblCategories.Name = "lblCategories";
            this.lblCategories.Size = new System.Drawing.Size(68, 18);
            this.lblCategories.TabIndex = 2;
            this.lblCategories.Text = "Categories : ";
            this.lblCategories.ThemeName = "VisualStudio2012Dark";
            // 
            // lblLink
            // 
            this.lblLink.Location = new System.Drawing.Point(25, 84);
            this.lblLink.Name = "lblLink";
            this.lblLink.Size = new System.Drawing.Size(35, 18);
            this.lblLink.TabIndex = 1;
            this.lblLink.Text = "Link : ";
            this.lblLink.ThemeName = "VisualStudio2012Dark";
            // 
            // lblName
            // 
            this.lblName.Location = new System.Drawing.Point(25, 38);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(45, 18);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Name : ";
            this.lblName.ThemeName = "VisualStudio2012Dark";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(86, 210);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(206, 24);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Save";
            this.btnSave.ThemeName = "VisualStudio2012Dark";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // FormStation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(390, 251);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.gbEnterData);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormStation";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "Station";
            this.ThemeName = "VisualStudio2012Dark";
            this.Load += new System.EventHandler(this.FormStation_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gbEnterData)).EndInit();
            this.gbEnterData.ResumeLayout(false);
            this.gbEnterData.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtCategories)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLink)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblCategories)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblLink)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSave)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.Themes.VisualStudio2012DarkTheme visualStudio2012DarkTheme;
        private Telerik.WinControls.UI.RadGroupBox gbEnterData;
        private Telerik.WinControls.UI.RadButton btnSave;
        private Telerik.WinControls.UI.RadLabel lblCategories;
        private Telerik.WinControls.UI.RadLabel lblLink;
        private Telerik.WinControls.UI.RadLabel lblName;
        private Telerik.WinControls.UI.RadTextBox txtCategories;
        private Telerik.WinControls.UI.RadTextBox txtLink;
        private Telerik.WinControls.UI.RadTextBox txtName;
    }
}
