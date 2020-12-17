/*!

\author         Oliver Blaser

\date           17.12.2020

\copyright      GNU GPLv3 - Copyright (c) 2020 Oliver Blaser

\brief          Index of directories and files

*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinPosMgr.Middleware.AppFiles
{
    public static class Directory
    {
        //public const string AppDirName = "winposmgr";

        //public const string AppDataUserRoaming = System.IO.Path.Combine(System.Environment.GetEnvironmentVariable("APPDATA"), AppDirName);
        //public const string AppDataUserLocal = System.IO.Path.Combine(System.Environment.GetEnvironmentVariable("LOCALAPPDATA"), AppDirName);
        //public const string AppDataAllUser = System.IO.Path.Combine(System.Environment.GetEnvironmentVariable("ALLUSERSPROFILE"), AppDirName);

        //public const string Log = /* no path = current working dir */ "log";

        public static void CreateInexistents()
        {
            //if (!System.IO.Directory.Exists(AppFiles.Directory.AppDataUserRoaming)) System.IO.Directory.CreateDirectory(AppFiles.Directory.AppDataUserRoaming);
            //if (!System.IO.Directory.Exists(AppFiles.Directory.AppDataUserLocal)) System.IO.Directory.CreateDirectory(AppFiles.Directory.AppDataUserLocal);
            //if (!System.IO.Directory.Exists(AppFiles.Directory.AppDataAllUser)) System.IO.Directory.CreateDirectory(AppFiles.Directory.AppDataAllUser);

            //if (!System.IO.Directory.Exists(AppFiles.Directory.Log)) System.IO.Directory.CreateDirectory(AppFiles.Directory.Log);
        }
    }

    public static class File
    {
        public const string Config = /* no path = current working dir */ "config.ini"; // initial file creation not needed
        public const string Settings = /* no path = current working dir */ "settings.ini"; // initial file creation not needed
        public const string Jobs = /* no path = current working dir */ "jobs.ini"; // initial file creation not needed

        public static void CreateInexistents()
        {
        }

        public static class FileDialogFilter
        {
            public const string Join = "|";
            public const string AllFiles = "All Files (*.*)|*.*";

            public const string CSV = "CSV Files (*.csv)|*.csv";
            public const string Ini = "ini Files (*.ini)|*.ini";
            public const string Text = "Text Files (*.txt)|*.txt";
        }
    }
}
