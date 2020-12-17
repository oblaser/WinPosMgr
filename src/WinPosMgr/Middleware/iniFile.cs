/*!

\author         Oliver Blaser

\date           15.12.2020

\copyright      GNU GPLv3 - Copyright (c) 2020 Oliver Blaser

\brief          Ini file parser/serializer

Old lib of mine, with bad exception handling. XML docs may be outdated.
Should be rewritten.

But does it's job

*/

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace WinPosMgr.Middleware
{
    namespace Util
    {
        namespace IniFile
        {
            public class IniFile
            {
                private const string NoSectionsSection = "noSections";
                private bool SectionEnable;
                private List<int> SectionStart;
                private List<tSection> Section;

                public string FileName { get; }

                public System.Text.Encoding FileEncoding { get; private set; }

                /// <summary>
                /// 
                /// </summary>
                /// <param name="FileName">File will be created, if it could not be found.</param>
                /// <param name="ContainsSections">If the file gets created, this defines whether it's a ini file with Sections or without.</param>
                public IniFile(string FileName, System.Text.Encoding FileEncoding, bool ContainsSections)
                {
                    this.FileName = FileName;
                    this.FileEncoding = FileEncoding;

                    bool CreateFile = false;

                    // check ExceptionCode class for duplicates
                    if (Ex.GroupBy(x => x).Any(g => g.Count() > 1)) throw new Exception("Attribute \"Ex\" has duplicates! Caused by a mistake of the developer.");

                    // read file
                    string[] FileLines;
                    try { FileLines = File.ReadAllLines(this.FileName, this.FileEncoding); }
                    catch
                    {
                        FileLines = new string[0];
                        CreateFile = true;
                    }

                    this.SectionEnable = ContainsSections;
                    // in the (following) old way empty files would become marked as file wich no sections instead of empty file. Also see IsEmpty method
                    /*if (CreateFile)
                    {
                        this.SectionEnable = ContainsSections;
                    }

                    else
                    {
                        // check if sectors are present
                        this.SectionEnable = false;
                        foreach (string s in FileLines)
                        {
                            if (s.Length > 0)
                            {
                                if (s.ToCharArray()[0] == '[')
                                {
                                    this.SectionEnable = true;
                                    break;
                                }
                            }
                        }
                    }*/

                    // parse file
                    if (this.SectionEnable)
                    {
                        SectionStart = new List<int>();

                        // search lines with section start
                        for (int i = 0; i < FileLines.Length; i++) if (FileLines[i].Length > 0) if (FileLines[i].ToCharArray()[0] == '[') SectionStart.Add(i);

                        Section = new List<tSection>(0);

                        for (int i = 0; i < SectionStart.Count; i++) Section.Add(new tSection(FileLines, SectionStart[i]));
                    }

                    else
                    {
                        Section = new List<tSection>(0);

                        List<string> tmpLines = new List<string>(0);

                        tmpLines.Add("[" + NoSectionsSection + "]");
                        tmpLines.AddRange(FileLines);

                        Section.Add(new tSection(tmpLines.ToArray(), 0));
                    }

                    if (CreateFile)
                    {
                        try { this.SaveToFile(); }
                        catch (Exception ex) { throw ex; }
                    }
                }

                public bool IsEmpty()
                {
                    bool result;

                    if ((this.SectionEnable && this.Section.Count == 0) || (!this.SectionEnable && this.Section[0].Key.Count == 0)) result = true;
                    else result = false;

                    return result;
                }

                /// <summary>
                /// 
                /// <para>
                /// Can throw the following exceptions:
                /// ExID.FileHasNoSections
                /// </para>
                /// </summary>
                /// <returns></returns>
                public List<tSection> GetSections()
                {
                    if (this.SectionEnable == false) throw new Exception(Ex[(int)ExID.FileHasNoSections]);

                    return this.Section;
                }

                /// <summary>
                /// 
                /// <para>
                /// Can throw the following exceptions:
                /// ExID.FileHasNoSections
                /// </para>
                /// </summary>
                /// <param name="index"></param>
                /// <returns></returns>
                public tSection GetSection(int index)
                {
                    if (this.SectionEnable == false) throw new Exception(Ex[(int)ExID.FileHasNoSections]);

                    return this.Section[index];
                }

                /// <summary>
                /// 
                /// <para>
                /// Can throw the following exceptions:
                /// ExID.FileHasSections
                /// </para>
                /// </summary>
                /// <returns></returns>
                public List<tKey> GetKeys()
                {
                    if (this.SectionEnable == true) throw new Exception(Ex[(int)ExID.FileHasSections]);

                    return this.Section[0].Key;
                }

                /// <summary>
                /// 
                /// <para>
                /// Can throw the following exceptions:
                /// ExID.FileHasSections
                /// </para>
                /// </summary>
                /// <param name="index"></param>
                /// <returns></returns>
                public tKey GetKey(int index)
                {
                    if (this.SectionEnable == true) throw new Exception(Ex[(int)ExID.FileHasSections]);

                    return this.Section[0].Key[index];
                }

                #region Get Methods
                /// <summary>
                /// 
                /// <para>
                /// Can throw the following exceptions:
                /// ExID.FileHasNoSections / 
                /// ExID.SectionNotFound / 
                /// ExID.KeyNotFound / 
                /// </para>
                /// </summary>
                /// <param name="Section"></param>
                /// <param name="KeyName"></param>
                /// <returns></returns>
                public string Get(string Section, string KeyName)
                {
                    // <para>
                    // Can throw the following exceptions:
                    // ExID.FileHasNoSections / 
                    // ExID.SectionNotFound / 
                    // ExID.KeyNotFound / 
                    // </para>

                    try { return this.Get(Section, KeyName, false, String.Empty); }
                    catch (Exception ex) { throw ex; }
                }
                /// <summary>
                /// 
                /// // <para>
                /// // Can throw the following exceptions:
                /// // ExID.FileHasNoSections / 
                /// // ExID.SectionNotCreated / 
                /// // ExID.KeyNotCreated / 
                /// // ExID.SectionNotFound / 
                /// // ExID.KeyNotFound / 
                /// // ExID.ExID.FileIOException and an inner exception (throwed by the private method SaveToFile())
                /// // </para>
                /// </summary>
                /// <param name="Section"></param>
                /// <param name="KeyName"></param>
                /// <param name="AllowCreation"></param>
                /// <param name="CreatedValue"></param>
                /// <returns></returns>
                public string Get(string Section, string KeyName, bool AllowCreation, string CreatedValue)
                {
                    // <para>
                    // Can throw the following exceptions:
                    // ExID.FileHasNoSections / 
                    // ExID.SectionNotCreated / 
                    // ExID.KeyNotCreated / 
                    // ExID.SectionNotFound / 
                    // ExID.KeyNotFound / 
                    // ExID.ExID.FileIOException and an inner exception (throwed by the private method SaveToFile())
                    // </para>

                    if (this.SectionEnable == false) throw new Exception(Ex[(int)ExID.FileHasNoSections]);

                    int SectionID = -1;
                    int KeyID = -1;
                    int Attempts = 0;
                    const int AttemptsMin = 3; // 1. Section not found => create section | 2. Section found, key not found => create key | 3. Section and key found

                    while (Attempts++ < (AttemptsMin + 10) && (SectionID < 0 || KeyID < 0))
                    {
                        SectionID = -1;
                        KeyID = -1;

                        for (int sIndex = 0; sIndex < this.Section.Count; sIndex++)
                        {
                            if (this.Section[sIndex].Name == Section)
                            {
                                SectionID = sIndex;

                                for (int kIndex = 0; kIndex < this.Section[sIndex].Key.Count; kIndex++)
                                {
                                    if (this.Section[sIndex].Key[kIndex].Name == KeyName)
                                    {
                                        KeyID = kIndex;
                                        break;
                                    }
                                }

                                break;
                            }
                        }

                        if (AllowCreation)
                        {
                            if (SectionID < 0) this.Section.Add(new tSection(new string[] { "[" + Section + "]" }, 0));
                            else if (KeyID < 0)
                            {
                                this.Section[SectionID].Key.Add(new tKey(new string[] { KeyName + "=" + CreatedValue }, 0));

                                try { this.SaveToFile(); }
                                catch (Exception ex) { throw ex; }

                                return CreatedValue;
                            }
                        }
                    }

                    if (AllowCreation)
                    {
                        if (SectionID < 0) throw new Exception(Ex[(int)ExID.SectionNotCreated]);
                        if (KeyID < 0) throw new Exception(Ex[(int)ExID.KeyNotCreated]);
                    }

                    else
                    {
                        if (SectionID < 0) throw new Exception(Ex[(int)ExID.SectionNotFound]);
                        if (KeyID < 0) throw new Exception(Ex[(int)ExID.KeyNotFound]);
                    }

                    return this.Section[SectionID].Key[KeyID].Value;
                }

                /// <summary>
                /// 
                /// <para>
                /// Can throw the following exceptions:
                /// ExID.FileHasSections / 
                /// ExID.KeyNotFound / 
                /// </para>
                /// </summary>
                /// <param name="KeyName"></param>
                /// <returns></returns>
                public string Get(string KeyName)
                {
                    // <para>
                    // Can throw the following exceptions:
                    // ExID.FileHasSections / 
                    // ExID.KeyNotFound / 
                    // </para>

                    try { return this.Get(KeyName, false, String.Empty); }
                    catch (Exception ex) { throw ex; }
                }
                /// <summary>
                /// 
                /// <para>
                /// Can throw the following exceptions:
                /// ExID.FileHasSections / 
                /// ExID.KeyNotCreated /  
                /// ExID.KeyNotFound / 
                /// ExID.ExID.FileIOException and an inner exception (throwed by the private method SaveToFile())
                /// </para>
                /// </summary>
                /// <param name="KeyName"></param>
                /// <param name="AllowCreation"></param>
                /// <param name="CreatedValue"></param>
                /// <returns></returns>
                public string Get(string KeyName, bool AllowCreation, string CreatedValue)
                {
                    // <para>
                    // Can throw the following exceptions:
                    // ExID.FileHasSections / 
                    // ExID.KeyNotCreated /  
                    // ExID.KeyNotFound / 
                    // ExID.ExID.FileIOException and an inner exception (throwed by the private method SaveToFile())
                    // </para>

                    if (this.SectionEnable == true) throw new Exception(Ex[(int)ExID.FileHasSections]);

                    int KeyID = -1;
                    int Attempts = 0;
                    const int AttemptsMin = 3; // 1. Section not found => create section | 2. Section found, key not found => create key | 3. Section and key found

                    while (Attempts++ < (AttemptsMin + 10) && (KeyID < 0))
                    {
                        KeyID = -1;

                        for (int kIndex = 0; kIndex < this.Section[0].Key.Count; kIndex++)
                        {
                            if (this.Section[0].Key[kIndex].Name == KeyName)
                            {
                                KeyID = kIndex;
                                break;
                            }
                        }

                        // create unfound keys
                        if (AllowCreation)
                        {
                            if (KeyID < 0)
                            {
                                this.Section[0].Key.Add(new tKey(new string[] { KeyName + "=" + CreatedValue }, 0));

                                try { this.SaveToFile(); }
                                catch (Exception ex) { throw ex; }

                                return CreatedValue;
                            }
                        }
                    }

                    if (AllowCreation) { if (KeyID < 0) throw new Exception(Ex[(int)ExID.KeyNotCreated]); }
                    else { if (KeyID < 0) throw new Exception(Ex[(int)ExID.KeyNotFound]); }

                    return this.Section[0].Key[KeyID].Value;
                }
                #endregion

                #region Set Methods
                /// <summary>
                /// 
                /// <para>
                /// Can throw the following exceptions:
                /// ExID.FileHasNoSections / 
                /// ExID.SectionNotFound / 
                /// ExID.KeyNotFound / 
                /// ExID.ExID.FileIOException and an inner exception (throwed by the private method SaveToFile())
                /// </para>
                /// </summary>
                /// <param name="Section"></param>
                /// <param name="KeyName"></param>
                /// <param name="Value"></param>
                public void Set(string Section, string KeyName, string Value)
                {
                    // <para>
                    // Can throw the following exceptions:
                    // ExID.FileHasNoSections / 
                    // ExID.SectionNotFound / 
                    // ExID.KeyNotFound / 
                    // ExID.ExID.FileIOException and an inner exception (throwed by the private method SaveToFile())
                    // </para>

                    try { this.Set(Section, KeyName, Value, false, false); }
                    catch (Exception ex) { throw ex; }
                }
                /// <summary>
                /// 
                /// <para>
                /// Can throw the following exceptions:
                /// ExID.FileHasNoSections / 
                /// ExID.SectionNotFound / 
                /// ExID.KeyNotFound / 
                /// ExID.ExID.FileIOException and an inner exception (throwed by the private method SaveToFile())
                /// </para>
                /// </summary>
                /// <param name="Section"></param>
                /// <param name="KeyName"></param>
                /// <param name="Value"></param>
                /// <param name="PreventSaveToFile"></param>
                public void Set(string Section, string KeyName, string Value, bool PreventSaveToFile)
                {
                    // <para>
                    // Can throw the following exceptions:
                    // ExID.FileHasNoSections / 
                    // ExID.SectionNotFound / 
                    // ExID.KeyNotFound / 
                    // ExID.ExID.FileIOException and an inner exception (throwed by the private method SaveToFile())
                    // </para>

                    try { this.Set(Section, KeyName, Value, PreventSaveToFile, false); }
                    catch (Exception ex) { throw ex; }
                }
                /// <summary>
                /// 
                /// <para>
                /// Can throw the following exceptions:
                /// ExID.FileHasNoSections / 
                /// ExID.SectionNotCreated / 
                /// ExID.KeyNotCreated / 
                /// ExID.SectionNotFound / 
                /// ExID.KeyNotFound / 
                /// ExID.ExID.FileIOException and an inner exception (throwed by the private method SaveToFile())
                /// </para>
                /// </summary>
                /// <param name="Section"></param>
                /// <param name="KeyName"></param>
                /// <param name="Value"></param>
                /// <param name="PreventSaveToFile"></param>
                /// <param name="AllowCreation"></param>
                public void Set(string Section, string KeyName, string Value, bool PreventSaveToFile, bool AllowCreation)
                {
                    // <para>
                    // Can throw the following exceptions:
                    // ExID.FileHasNoSections / 
                    // ExID.SectionNotCreated / 
                    // ExID.KeyNotCreated / 
                    // ExID.SectionNotFound / 
                    // ExID.KeyNotFound / 
                    // ExID.ExID.FileIOException and an inner exception (throwed by the private method SaveToFile())
                    // </para>

                    if (this.SectionEnable == false) throw new Exception(Ex[(int)ExID.FileHasNoSections]);

                    int SectionID = -1;
                    int KeyID = -1;
                    int Attempts = 0;
                    const int AttemptsMin = 3; // 1. Section not found => create section | 2. Section found, key not found => create key | 3. Section and key found

                    while (Attempts++ < (AttemptsMin + 10) && (SectionID < 0 || KeyID < 0))
                    {
                        SectionID = -1;
                        KeyID = -1;

                        for (int sIndex = 0; sIndex < this.Section.Count; sIndex++)
                        {
                            if (this.Section[sIndex].Name == Section)
                            {
                                SectionID = sIndex;

                                for (int kIndex = 0; kIndex < this.Section[sIndex].Key.Count; kIndex++)
                                {
                                    if (this.Section[sIndex].Key[kIndex].Name == KeyName)
                                    {
                                        KeyID = kIndex;
                                        break;
                                    }
                                }

                                break;
                            }
                        }

                        // create unfound keys
                        if (AllowCreation)
                        {
                            if (SectionID < 0) this.Section.Add(new tSection(new string[] { "[" + Section + "]" }, 0));
                            else if (KeyID < 0) this.Section[SectionID].Key.Add(new tKey(new string[] { KeyName + "=" }, 0));
                        }
                    }

                    if (AllowCreation)
                    {
                        if (SectionID < 0) throw new Exception(Ex[(int)ExID.SectionNotCreated]);
                        if (KeyID < 0) throw new Exception(Ex[(int)ExID.KeyNotCreated]);
                    }

                    else
                    {
                        if (SectionID < 0) throw new Exception(Ex[(int)ExID.SectionNotFound]);
                        if (KeyID < 0) throw new Exception(Ex[(int)ExID.KeyNotFound]);
                    }

                    this.Section[SectionID].Key[KeyID].Value = Value;

                    if (PreventSaveToFile == false)
                    {
                        try { this.SaveToFile(); }
                        catch (Exception ex) { throw ex; }
                    }
                }

                /// <summary>
                /// 
                /// <para>
                /// Can throw the following exceptions:
                /// ExID.FileHasSections / 
                /// ExID.KeyNotFound / 
                /// ExID.ExID.FileIOException and an inner exception (throwed by the private method SaveToFile())
                /// </para>
                /// </summary>
                /// <param name="KeyName"></param>
                /// <param name="Value"></param>
                public void Set(string KeyName, string Value)
                {
                    // <para>
                    // Can throw the following exceptions:
                    // ExID.FileHasSections / 
                    // ExID.KeyNotFound / 
                    // ExID.ExID.FileIOException and an inner exception (throwed by the private method SaveToFile())
                    // </para>

                    try { this.Set(KeyName, Value, false, false); }
                    catch (Exception ex) { throw ex; }
                }
                /// <summary>
                /// 
                /// <para>
                /// Can throw the following exceptions:
                /// ExID.FileHasSections / 
                /// ExID.KeyNotFound / 
                /// ExID.ExID.FileIOException and an inner exception (throwed by the private method SaveToFile())
                /// </para>
                /// </summary>
                /// <param name="KeyName"></param>
                /// <param name="Value"></param>
                /// <param name="PreventSaveToFile"></param>
                public void Set(string KeyName, string Value, bool PreventSaveToFile)
                {
                    // <para>
                    // Can throw the following exceptions:
                    // ExID.FileHasSections / 
                    // ExID.KeyNotFound / 
                    // ExID.ExID.FileIOException and an inner exception (throwed by the private method SaveToFile())
                    // </para>

                    try { this.Set(KeyName, Value, PreventSaveToFile, false); }
                    catch (Exception ex) { throw ex; }
                }
                /// <summary>
                /// 
                /// <para>
                /// Can throw the following exceptions:
                /// ExID.FileHasSections / 
                /// ExID.KeyNotCreated /  
                /// ExID.KeyNotFound / 
                /// ExID.ExID.FileIOException and an inner exception (throwed by the private method SaveToFile())
                /// </para>
                /// </summary>
                /// <param name="KeyName"></param>
                /// <param name="Value"></param>
                /// <param name="PreventSaveToFile"></param>
                /// <param name="AllowCreation"></param>
                public void Set(string KeyName, string Value, bool PreventSaveToFile, bool AllowCreation)
                {
                    // <para>
                    // Can throw the following exceptions:
                    // ExID.FileHasSections / 
                    // ExID.KeyNotCreated /  
                    // ExID.KeyNotFound / 
                    // ExID.ExID.FileIOException and an inner exception (throwed by the private method SaveToFile())
                    // </para>

                    if (this.SectionEnable == true) throw new Exception(Ex[(int)ExID.FileHasSections]);

                    int KeyID = -1;
                    int Attempts = 0;
                    const int AttemptsMin = 3; // 1. Section not found => create section | 2. Section found, key not found => create key | 3. Section and key found

                    while (Attempts++ < (AttemptsMin + 10) && (KeyID < 0))
                    {
                        KeyID = -1;

                        for (int kIndex = 0; kIndex < this.Section[0].Key.Count; kIndex++)
                        {
                            if (this.Section[0].Key[kIndex].Name == KeyName)
                            {
                                KeyID = kIndex;
                                break;
                            }
                        }

                        // create unfound keys
                        if (AllowCreation)
                        {
                            if (KeyID < 0) this.Section[0].Key.Add(new tKey(new string[] { KeyName + "=" }, 0));
                        }
                    }

                    if (AllowCreation) { if (KeyID < 0) throw new Exception(Ex[(int)ExID.KeyNotCreated]); }
                    else { if (KeyID < 0) throw new Exception(Ex[(int)ExID.KeyNotFound]); }

                    this.Section[0].Key[KeyID].Value = Value;

                    if (PreventSaveToFile == false)
                    {
                        try { this.SaveToFile(); }
                        catch (Exception ex) { throw ex; }
                    }
                }
                #endregion






                /// <summary>
                /// 
                /// </summary>
                /// <param name="section"></param>
                /// <returns>true on success</returns>
                public bool RemoveSection(string section)
                {
                    return RemoveSection(section, false);
                }

                /// <summary>
                /// 
                /// </summary>
                /// <param name="section"></param>
                /// <param name="PreventSaveToFile"></param>
                /// <returns>true on success</returns>
                public bool RemoveSection(string section, bool PreventSaveToFile)
                {
                    bool result;

                    if (this.SectionEnable == false) throw new Exception(Ex[(int)ExID.FileHasNoSections]);

                    int sIndex = -1;

                    for (int i = 0; i < this.Section.Count; ++i)
                    {
                        if (this.Section[i].Name == section) sIndex = i;
                    }

                    if (sIndex < 0) result = true;
                    else
                    {
                        try
                        {
                            this.Section.RemoveAt(sIndex);
                            result = true;
                        }
                        catch { result = false; }
                    }

                    if (PreventSaveToFile == false)
                    {
                        try { this.SaveToFile(); }
                        catch (Exception ex) { throw ex; }
                    }

                    return result;
                }










                /// <summary>
                /// 
                /// <para>
                /// Can throw the following exception:
                /// ExID.FileIOException and an inner exception (throwed by the System.IO.File.WriteAllText() method)
                /// </para>
                /// </summary>
                public void SaveToFile()
                {
                    string FileContent = String.Empty;

                    if (this.SectionEnable)
                    {
                        for (int sIndex = 0; sIndex < this.Section.Count; sIndex++)
                        {
                            if (sIndex != 0) FileContent += "\n";

                            FileContent += "[" + this.Section[sIndex].Name + "]\n";

                            for (int kIndex = 0; kIndex < this.Section[sIndex].Key.Count; kIndex++)
                            {
                                FileContent += this.Section[sIndex].Key[kIndex].Name + "=" + this.Section[sIndex].Key[kIndex].Value + "\n";
                            }
                        }
                    }

                    else
                    {
                        for (int kIndex = 0; kIndex < this.Section[0].Key.Count; kIndex++)
                        {
                            FileContent += this.Section[0].Key[kIndex].Name + "=" + this.Section[0].Key[kIndex].Value + "\n";
                        }
                    }

                    try { File.WriteAllText(this.FileName, FileContent, this.FileEncoding); }
                    catch (Exception ex) { throw new Exception(Ex[(int)ExID.FileIOException], ex); }
                }

                public class tSection
                {
                    private List<int> KeyLine;

                    public string Name { get; private set; }
                    public List<tKey> Key { get; internal set; }

                    public tSection(string[] FileLines, int StartLine)
                    {
                        int index = StartLine;

                        this.Name = FileLines[index].Replace("[", "").Replace("]", "");
                        index++;

                        KeyLine = new List<int>();

                        // search lines with keys
                        while (index < FileLines.Length - 1 && FileLines[index].Length < 1) index++;

                        while (index < FileLines.Length && FileLines[index].ToCharArray()[0] != '[')
                        {
                            if (FileLines[index].ToCharArray()[0] != ';' &&
                                FileLines[index] != String.Empty &&
                                FileLines[index].Contains("="))
                            {
                                KeyLine.Add(index);
                            }

                            index++;
                            while (index < FileLines.Length - 1 && FileLines[index].Length < 1) index++;
                        }

                        Key = new List<tKey>(0);

                        for (int i = 0; i < KeyLine.Count; i++) Key.Add(new tKey(FileLines, KeyLine[i]));
                    }
                }

                public class tKey
                {
                    public string Name { get; private set; }
                    public string Value { get; internal set; }

                    public tKey(string[] FileLines, int KeyLine)
                    {
                        string[] pair = FileLines[KeyLine].Split(new char[] { '=' }, 2);

                        this.Name = pair[0];
                        if (pair.Length > 1) this.Value = pair[1];
                        else this.Value = String.Empty;
                    }
                }

                public enum ExID
                {
                    FileIsEmpty = 0,
                    FileHasNoSections,
                    FileHasSections,
                    SectionNotFound,
                    KeyNotFound,
                    SectionNotCreated,
                    KeyNotCreated,
                    FileIOException
                }

                public static string[] Ex =
                {
                    "FileIsEmpty",
                    "FileHasNoSections",
                    "FileHasSections - you need to specify a section",
                    "SectionNotFound",
                    "KeyNotFound",
                    "SectionNotCreated",
                    "KeyNotCreated",
                    "FileException"
                };
            }
        }
    }
}
