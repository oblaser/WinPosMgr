/*!

\author         Oliver Blaser

\date           15.12.2020

\copyright      GNU GPLv3 - Copyright (c) 2020 Oliver Blaser

\brief          

Future plans:
- Create a base class for the keys and every key should become a derivate of it.

*/

using System;

namespace WinPosMgr.Middleware.IniFileWrapper
{
    public static class Config
    {
        private static Util.IniFile.IniFile IniFile = new Util.IniFile.IniFile(AppFiles.File.Config, System.Text.Encoding.UTF8, true);

        public static void SaveFile()
        {
            IniFile.SaveToFile();
        }

        public static class General
        {
            private const string SectionName = "General";

            public static class FirstStart
            {
                private const string KeyName = "FirstStart";

                public static readonly bool DefaultValue = true;

                public static bool Get()
                {
                    try { return (System.Convert.ToInt32(IniFile.Get(SectionName, KeyName, true, (DefaultValue ? "1" : "0"))) != 0); }
                    catch
                    {
                        Set(DefaultValue, true);
                        return DefaultValue;
                    }
                }

                public static void Set(bool value) { Set(value, false); }
                public static void Set(bool value, bool preventSaveFile)
                {
                    IniFile.Set(SectionName, KeyName, (value ? "1" : "0"), preventSaveFile, true);
                }
            }
        }

        public static class UI
        {
            private const string SectionName = "UI";

            public static class WindowMaximized
            {
                private const string KeyName = "WindowMaximized";

                public static readonly bool DefaultValue = false;

                public static bool Get()
                {
                    try { return (System.Convert.ToInt32(IniFile.Get(SectionName, KeyName, true, (DefaultValue ? "1" : "0"))) != 0); }
                    catch
                    {
                        Set(DefaultValue, true);
                        return DefaultValue;
                    }
                }

                public static void Set(bool value) { Set(value, false); }
                public static void Set(bool value, bool preventSaveFile)
                {
                    IniFile.Set(SectionName, KeyName, (value ? "1" : "0"), preventSaveFile, true);
                }
            }

            public static class WindowLocation
            {
                private const string KeyName = "WindowLocation";

                public static readonly System.Drawing.Point DefaultValue = new System.Drawing.Point(20, 20);

                public static System.Drawing.Point Get()
                {
                    try
                    {
                        string[] tmp = IniFile.Get(SectionName, KeyName, true, (DefaultValue.X.ToString() + ';' + DefaultValue.Y.ToString())).Split(';');
                        return new System.Drawing.Point(System.Convert.ToInt32(tmp[0]), System.Convert.ToInt32(tmp[1]));
                    }
                    catch
                    {
                        Set(DefaultValue, true);
                        return DefaultValue;
                    }
                }

                public static void Set(System.Drawing.Point value) { Set(value, false); }
                public static void Set(System.Drawing.Point value, bool preventSaveFile)
                {
                    IniFile.Set(SectionName, KeyName, (value.X.ToString() + ';' + value.Y.ToString()), preventSaveFile, true);
                }
            }

            public static class WindowSize
            {
                private const string KeyName = "WindowSize";

                public static readonly System.Drawing.Size DefaultValue = new System.Drawing.Size(500, 255);

                public static System.Drawing.Size Get()
                {
                    try
                    {
                        string[] tmp = IniFile.Get(SectionName, KeyName, true, (DefaultValue.Width.ToString() + ';' + DefaultValue.Height.ToString())).Split(';');
                        return new System.Drawing.Size(System.Convert.ToInt32(tmp[0]), System.Convert.ToInt32(tmp[1]));
                    }
                    catch
                    {
                        Set(DefaultValue, true);
                        return DefaultValue;
                    }
                }

                public static void Set(System.Drawing.Size value) { Set(value, false); }
                public static void Set(System.Drawing.Size value, bool preventSaveFile)
                {
                    IniFile.Set(SectionName, KeyName, (value.Width.ToString() + ';' + value.Height.ToString()), preventSaveFile, true);
                }
            }
        }
    }

    public static class Settings
    {
        private static Util.IniFile.IniFile IniFile = new Util.IniFile.IniFile(AppFiles.File.Settings, System.Text.Encoding.UTF8, true);

        public static void SaveFile()
        {
            IniFile.SaveToFile();
        }

        public static class General
        {
            private const string SectionName = "General";

            public static class DefaultOpMode
            {
                private const string KeyName = "DefaultOpMode";

                public static readonly Application.Settings.OpMode DefaultValue = Application.Settings.OpMode.gui;

                public static Application.Settings.OpMode Get()
                {
                    try { return Util.Misc.ParseEnum<Application.Settings.OpMode>(IniFile.Get(SectionName, KeyName, true, DefaultValue.ToString()), true); }
                    catch
                    {
                        Set(DefaultValue, true);
                        return DefaultValue;
                    }
                }

                public static void Set(Application.Settings.OpMode value) { Set(value, false); }
                public static void Set(Application.Settings.OpMode value, bool preventSaveFile)
                {
                    IniFile.Set(SectionName, KeyName, value.ToString(), preventSaveFile, true);
                }
            }

            public static class OpModeRunErrorReporting
            {
                private const string KeyName = "OpModeRunErrorReporting";

                public static readonly Application.Settings.ErrorReporting DefaultValue = Application.Settings.ErrorReporting.None;

                public static Application.Settings.ErrorReporting Get()
                {
                    try { return Util.Misc.ParseEnum<Application.Settings.ErrorReporting>(IniFile.Get(SectionName, KeyName, true, DefaultValue.ToString()), true); }
                    catch
                    {
                        Set(DefaultValue, true);
                        return DefaultValue;
                    }
                }

                public static void Set(Application.Settings.ErrorReporting value) { Set(value, false); }
                public static void Set(Application.Settings.ErrorReporting value, bool preventSaveFile)
                {
                    IniFile.Set(SectionName, KeyName, value.ToString(), preventSaveFile, true);
                }
            }

            public static class JobsFile
            {
                private const string KeyName = "JobsFile";

                public static readonly string DefaultValue = Middleware.AppFiles.File.Jobs;

                public static string Get()
                {
                    try { return IniFile.Get(SectionName, KeyName, true, DefaultValue); }
                    catch
                    {
                        Set(DefaultValue, true);
                        return DefaultValue;
                    }
                }

                public static void Set(string value) { Set(value, false); }
                public static void Set(string value, bool preventSaveFile)
                {
                    IniFile.Set(SectionName, KeyName, value, preventSaveFile, true);
                }
            }
        }
    }
}
