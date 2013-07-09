using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DevExpress.CodeRush.Core;

namespace CR_WrapInTryFunction
{
    [UserLevel(UserLevel.NewUser)]
    public partial class Options1 : OptionsPage
    {
        private const string My_Options = "WrapInTryFunction";
        private const string OPT_EnableLogging = "EnableLogging";
        // DXCore-generated code...
        #region Initialize
        protected override void Initialize()
        {
            base.Initialize();
            RestoreDefaults += OnRestoreDefaults;
            PreparePage += OnPreparePage;
            CommitChanges += OnCommitChanges;
        }
        #endregion

        #region GetCategory
        public static string GetCategory()
        {
            return @"Editor\Refactoring";
        }
        #endregion
        #region GetPageName
        public static string GetPageName()
        {
            return @"WrapInTryFunction";
        }
        #endregion

        private void OnRestoreDefaults(Object sender, OptionsPageEventArgs ea)
        {
            // Setup defaults here
            chkEnableLogging.Checked = false;
        }

        private void OnPreparePage(Object sender, OptionsPageStorageEventArgs ea)
        {
            // Load options here
            chkEnableLogging.Checked = LoadOptions();

        }
        public static bool LoadOptions()
        {
            return Options1.Storage.ReadBoolean(My_Options, OPT_EnableLogging);
        }

        private void OnCommitChanges(Object sender, CommitChangesEventArgs ea)
        {
            // Save changes here.
            ea.Storage.WriteBoolean(My_Options, OPT_EnableLogging, chkEnableLogging.Checked);


        }



    }
}