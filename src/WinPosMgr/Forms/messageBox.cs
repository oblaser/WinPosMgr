/*!

\author         Oliver Blaser

\date           17.12.2020

\copyright      GNU GPLv3 - Copyright (c) 2020 Oliver Blaser

\brief          

*/


#region config

// comment-out a #define line to disable it

#define USE_RESX_TITLE

#if(USE_RESX_TITLE)
#define INSERT_APP_NAME
#define DYNAMIC_TITLE
#endif

#endregion

using System;

namespace WinPosMgr.Forms
{
    public static class MessageBox
    {

#if (USE_RESX_TITLE)
#if (DYNAMIC_TITLE)
#if (INSERT_APP_NAME)
        private static string ErrorTitle = Properties.Strings.gAppName_abbr + " - " + Properties.Strings.gError;
        private static string InformationTitle = Properties.Strings.gAppName_abbr + " - " + Properties.Strings.gInformation;
        private static string WarningTitle = Properties.Strings.gAppName_abbr + " - " + Properties.Strings.gWarning;
#else
        private static string ErrorTitle = Properties.Strings.Error;
        private static string InformationTitle = Properties.Strings.Information;
        private static string WarningTitle = Properties.Strings.Warning;
#endif
        public static void SetTitles(string error, string information,string warning)
        {
            ErrorTitle = error;
            InformationTitle = information;
            WarningTitle = warning;
        }
#else
#if (INSERT_APP_NAME)
        private static readonly string ErrorTitle = Properties.Strings.appName_abbr + " - " + Properties.Strings.Error;
        private static readonly string InformationTitle = Properties.Strings.appName_abbr + " - " + Properties.Strings.Information;
        private static readonly string WarningTitle = Properties.Strings.appName_abbr + " - " + Properties.Strings.Warning;
#else
        private static readonly string ErrorTitle = Properties.Strings.Error;
        private static readonly string InformationTitle = Properties.Strings.Information;
        private static readonly string WarningTitle = Properties.Strings.Warning;
#endif
#endif
#else
        private static readonly string ErrorTitle = "Error";
        private static readonly string InformationTitle = "Information";
        private static readonly string WarningTitle = "Warning";
#endif

        public static System.Windows.Forms.DialogResult Error(string msg)
        {
            return System.Windows.Forms.MessageBox.Show(
                msg,
                ErrorTitle,
                System.Windows.Forms.MessageBoxButtons.OK,
                System.Windows.Forms.MessageBoxIcon.Error);
        }

        public static System.Windows.Forms.DialogResult Information(string msg)
        {
            return System.Windows.Forms.MessageBox.Show(
                msg,
                InformationTitle,
                System.Windows.Forms.MessageBoxButtons.OK,
                System.Windows.Forms.MessageBoxIcon.Information);
        }

        public static System.Windows.Forms.DialogResult Warning(string msg)
        {
            return System.Windows.Forms.MessageBox.Show(
                msg,
                WarningTitle,
                System.Windows.Forms.MessageBoxButtons.OK,
                System.Windows.Forms.MessageBoxIcon.Warning);
        }
    }
}
