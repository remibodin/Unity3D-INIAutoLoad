using System;
using UnityEngine;
using UnityEditor;
using UnityEditor.Callbacks;
using System.Collections.Generic;
using IniParser.Model;
using System.Reflection;

namespace IniConfiguration
{
    class PostBuild
    {
        private static Dictionary<string, IniData> _datas;

        /// <summary>
        /// Call after export project to create default ini files
        /// </summary>
        /// <param name="target">build target</param>
        /// <param name="pathToBuiltProject">build path</param>
        [PostProcessBuildAttribute(0)]
        public static void OnPostprocessBuild(BuildTarget target, string pathToBuiltProject)
        {
            if (target != BuildTarget.StandaloneLinux &&
                target != BuildTarget.StandaloneLinux64 &&
                target != BuildTarget.StandaloneLinuxUniversal &&
                target != BuildTarget.StandaloneWindows && 
                target != BuildTarget.StandaloneWindows64)
                {
                    Debug.LogWarning("INI files not created. BuildTarget not supported");
                    return;
                }
            string exportPath = System.IO.Path.GetDirectoryName(pathToBuiltProject);
            _datas = new Dictionary<string, IniData>();

            foreach (Assembly assembly in AppDomain.CurrentDomain.GetAssemblies())
            {
                foreach (Type type in assembly.GetTypes())
                {
                    foreach(Attributes.File attr in type.GetCustomAttributes(typeof(Attributes.File), false))
                    {
                        // Create IniData object if it's first time for this file
                        if (_datas.ContainsKey(attr.filepath) == false)
                        {
                            _datas[attr.filepath] = new IniData();
                        }
                        foreach (var field in type.GetFields(BindingFlags.Public | BindingFlags.Static))
                        {
                            foreach(Attributes.Section sectionAttr in field.GetCustomAttributes(typeof(Attributes.Section), false))
                            {
                                _datas[attr.filepath][sectionAttr.name][field.Name] = field.GetValue(null).ToString();
                            }
                        }
                    }
                }
            }

            // write all files
            foreach(var key in _datas.Keys)
            {
                IniData data = _datas[key];
                string absoluteFilePath = System.IO.Path.Combine(exportPath, key);
                string absoluteDirectoryPath = System.IO.Path.GetDirectoryName(absoluteFilePath);
                System.IO.Directory.CreateDirectory(absoluteDirectoryPath);
                IniParser.FileIniDataParser.WriteFile(absoluteFilePath, data);    
            }
            
        }
    }
}