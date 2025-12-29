using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;


public class AlignWithEditorCamera : MonoBehaviour
{
    [MenuItem("Tools/Transformable Tools/Align With Editor Camera")]
    public static void _AlignWithEditorCamera()
    {
        if (Selection.activeObject != null) 
        {

            GameObject gameObject = Selection.activeObject as GameObject;

            gameObject.transform.position = SceneView.lastActiveSceneView.camera.transform.position;
            gameObject.transform.forward = SceneView.lastActiveSceneView.camera.transform.forward;


            Undo.RegisterCompleteObjectUndo(Selection.activeObject, "Undo Align With Editor Camera");
      
            EditorSceneManager.MarkSceneDirty(EditorSceneManager.GetActiveScene());
            EditorUtility.SetDirty(Selection.activeObject);
        }
    }
}
