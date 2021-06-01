using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Editor
{
    public static class CanvasTool
    {
        [MenuItem("UI工具/生成UIRoot模板")]
        public static void GenerateUIRoot()
        {
            var uiRootGO = new GameObject("UIRoot");
            var canvasGO = new GameObject("Canvas");
            canvasGO.transform.SetParent(uiRootGO.transform);
            var canvas = canvasGO.AddComponent<Canvas>();
            canvas.renderMode = RenderMode.ScreenSpaceOverlay;
            canvasGO.AddComponent<CanvasScaler>();
            canvasGO.AddComponent<GraphicRaycaster>();
            
            var eventSystemGo = new GameObject("EventSystem");
            eventSystemGo.AddComponent<EventSystem>();
            eventSystemGo.transform.SetParent(uiRootGO.transform);
            eventSystemGo.AddComponent<StandaloneInputModule>();
        }
    }
}
