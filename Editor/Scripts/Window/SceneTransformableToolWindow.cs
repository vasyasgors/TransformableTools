using UnityEngine;
using UnityEditor;

public class SceneTransformableToolWindow : EditorWindow
{
    private const string ToolsCollectorFilter = "t: SceneTransformableToolsCollector";

    private static SceneTransformableToolsCollector tools;


    private const string Titile = "Transformable Tools";

    [MenuItem("Tools/Transformable Tools/Window")]
    private static void Init()
    {
        SceneTransformableToolWindow window = (SceneTransformableToolWindow)GetWindow(typeof(SceneTransformableToolWindow));

        window.titleContent = new GUIContent(Titile);
        window.Show();

        UpdateTools();
    }

    private static bool UpdateTools()
    {
        if (tools == null)
        {
            string guid = AssetDatabase.FindAssets(ToolsCollectorFilter)[0];
            string path = AssetDatabase.GUIDToAssetPath(guid);

            tools = (SceneTransformableToolsCollector)AssetDatabase.LoadAssetAtPath(path, typeof(SceneTransformableToolsCollector));

            if (tools == null)
            {
                Debug.LogError("Scene Transformable Tools Collector is not found!");
                return false;
            }
        }

        return true;
    }


    private void OnEnable()
    {
        Selection.selectionChanged += Repaint;
    }

    private void OnDestroy()
    {
        Selection.selectionChanged -= Repaint;
    }

    private void OnGUI()
    {
        if (UpdateTools() == false) return;

        if (Selection.gameObjects.Length == 0)
            GUILayout.Label("Nothing selected", EditorStyles.boldLabel);
        else
            GUILayout.Label("Selected (" + Selection.gameObjects.Length + ") objects", EditorStyles.boldLabel);

        EditorGUI.BeginChangeCheck();

        tools.DrawAll();

        if (EditorGUI.EndChangeCheck())
        {
            Undo.RegisterCompleteObjectUndo(tools, "Inspector");
        }
    }








}
