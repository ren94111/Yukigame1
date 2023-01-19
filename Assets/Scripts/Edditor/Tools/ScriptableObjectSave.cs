#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;

namespace Mytool
{
    public class ScriptableObjectSave : EditorWindow
    {
        [MenuItem("MyTools/ScriptableSave", priority = 1)]
        private static void DisplayWindow()
        {
            AssetDatabase.SaveAssets();
            Debug.Log("Save");
        }
    }
}
#endif