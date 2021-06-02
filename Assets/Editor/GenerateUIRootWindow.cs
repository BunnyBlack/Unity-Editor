using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Editor
{
    public class GenerateUIRootWindow : EditorWindow
    {
        private int _width = 720;
        private int _height = 1280;

        private void OnGUI()
        {
            GUILayout.Label("Reference Resolution");
            GUILayout.BeginHorizontal();
            GUILayout.Label("Width", GUILayout.Width(40));
            _width = int.Parse(GUILayout.TextField(_width.ToString()));
            GUILayout.Label("Height", GUILayout.Width(45));
            _height = int.Parse(GUILayout.TextField(_height.ToString()));
            GUILayout.EndHorizontal();

            if (GUILayout.Button("Generate"))
            {
                DoGenerateUIRoot(_width, _height);

                Close();
            }
        }

        private static void DoGenerateUIRoot(int width, int height)
        {

            var uiRootGO = new GameObject("UIRoot") { layer = LayerMask.NameToLayer("UI") };
            var canvasGO = new GameObject("Canvas") { layer = LayerMask.NameToLayer("UI") };
            canvasGO.transform.SetParent(uiRootGO.transform);
            var canvas = canvasGO.AddComponent<Canvas>();
            canvas.renderMode = RenderMode.ScreenSpaceOverlay;
            var canvasScaler = canvasGO.AddComponent<CanvasScaler>();
            canvasScaler.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
            canvasScaler.referenceResolution = new Vector2(width, height);
            canvasGO.AddComponent<GraphicRaycaster>();

            var eventSystemGo = new GameObject("EventSystem") { layer = LayerMask.NameToLayer("UI") };
            eventSystemGo.AddComponent<EventSystem>();
            eventSystemGo.transform.SetParent(uiRootGO.transform);
            eventSystemGo.AddComponent<StandaloneInputModule>();
            Undo.RegisterCreatedObjectUndo(uiRootGO, "GenerateUIRoot");
        }
    }
}
