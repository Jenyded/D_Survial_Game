using System.IO;
using UnityEngine;
using UnityEditor;

namespace Zenject
{
    public static class UnityPackageUtil
    {
        public static void CreateUnityPackage()
        {
            var outPath = Path.GetFullPath(Path.Combine(Application.dataPath, "../Zenject.unitypackage"));
            AssetDatabase.ExportPackage("Assets/Plugins/Zenject", outPath, ExportPackageOptions.Recurse | ExportPackageOptions.IncludeDependencies);
            Debug.Log("Exported to " + outPath);
        }
    }
}
