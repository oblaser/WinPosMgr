/*!

\author         Oliver Blaser

\date           15.12.2020

\copyright      GNU GPLv3 - Copyright (c) 2020 Oliver Blaser

\brief          

*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinPosMgr.Application
{
    public class Settings
    {
        public static Settings Get()
        {
            Settings result = new Settings();

            result.General_DefaultOpMode = Middleware.IniFileWrapper.Settings.General.DefaultOpMode.Get();
            result.General_OpModeRunErrorReporting = Middleware.IniFileWrapper.Settings.General.OpModeRunErrorReporting.Get();
            result.General_JobsFile = Middleware.IniFileWrapper.Settings.General.JobsFile.Get();

            return result;
        }

        public static void Save(Settings settings)
        {
            Middleware.IniFileWrapper.Settings.General.DefaultOpMode.Set(settings.General_DefaultOpMode, true);
            Middleware.IniFileWrapper.Settings.General.OpModeRunErrorReporting.Set(settings.General_OpModeRunErrorReporting, true);
            Middleware.IniFileWrapper.Settings.General.JobsFile.Set(settings.General_JobsFile, true);
            Middleware.IniFileWrapper.Settings.SaveFile();
        }

        public OpMode General_DefaultOpMode;
        public ErrorReporting General_OpModeRunErrorReporting;
        public string General_JobsFile;

        public Settings()
        {
        }

        public enum OpMode
        {
            gui = 0,
            run
        }

        public enum ErrorReporting
        {
            None=0,
            MsgBox/*,
            Log*/ // not yet supported
        }
    }
}
