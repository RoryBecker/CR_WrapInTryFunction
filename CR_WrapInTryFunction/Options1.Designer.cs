using System;
using DevExpress.CodeRush.Core;

namespace CR_WrapInTryFunction
{
    partial class Options1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public Options1()
        {
            /// <summary>
            /// Required for Windows.Forms Class Composition Designer support
            /// </summary>
            InitializeComponent();
        }

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
            this.chkEnableLogging = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.Images16x16)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // chkEnableLogging
            // 
            this.chkEnableLogging.AutoSize = true;
            this.chkEnableLogging.Location = new System.Drawing.Point(20, 22);
            this.chkEnableLogging.Name = "chkEnableLogging";
            this.chkEnableLogging.Size = new System.Drawing.Size(98, 17);
            this.chkEnableLogging.TabIndex = 0;
            this.chkEnableLogging.Text = "Enable Logging";
            this.chkEnableLogging.UseVisualStyleBackColor = true;
            // 
            // Options1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Controls.Add(this.chkEnableLogging);
            this.Name = "Options1";
            ((System.ComponentModel.ISupportInitialize)(this.Images16x16)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        ///
        /// Gets a DecoupledStorage instance for this options page.
        ///
        public static DecoupledStorage Storage
        {
            get
            {
                return DevExpress.CodeRush.Core.CodeRush.Options.GetStorage(GetCategory(), GetPageName());
            }
        }
        ///
        /// Returns the category of this options page.
        ///
        public override string Category
        {
            get
            {
                return Options1.GetCategory();
            }
        }
        ///
        /// Returns the page name of this options page.
        ///
        public override string PageName
        {
            get
            {
                return Options1.GetPageName();
            }
        }
        ///
        /// Returns the full path (Category + PageName) of this options page.
        ///
        public static string FullPath
        {
            get
            {
                return GetCategory() + "\\" + GetPageName();
            }
        }

        ///
        /// Displays the DXCore options dialog and selects this page.
        ///
        public new static void Show()
        {
            DevExpress.CodeRush.Core.CodeRush.Command.Execute("Options", FullPath);
        }

        private System.Windows.Forms.CheckBox chkEnableLogging;
    }
}