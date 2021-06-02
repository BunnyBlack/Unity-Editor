using UnityEditor;
using UnityEngine;

namespace Editor
{
    public static class CanvasTool
    {
        [MenuItem("UI工具/生成UIRoot模板")]
        public static void GenerateUIRoot()
        {
            var window = EditorWindow.GetWindow<GenerateUIRootWindow>();
            window.titleContent = new GUIContent("GenerateUIRoot");
            window.Show();
        }

        [MenuItem("UI工具/生成UIRoot模板", true)]
        public static bool GenerateUIRootValidate()
        {
            return !GameObject.Find("UIRoot");
        }
    }
}
