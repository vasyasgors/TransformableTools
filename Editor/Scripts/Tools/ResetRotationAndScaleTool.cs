using UnityEngine;
using UnityEditor;
using System;

[Serializable]
public class ResetRotationAndScaleTool 
{
    public void Draw()
    {
        GUILayout.Space(10);
        if (GUILayout.Button(new GUIContent("Reset Rotation and Scale")))
        {
            ResetRotationAndScale();
        }
    }

    private void ResetRotationAndScale()
    {
        for (int i = 0; i < Selection.gameObjects.Length; i++)
        {
            Undo.RecordObject(Selection.gameObjects[i].transform, "Reset Rotation And Scale");

            Selection.gameObjects[i].transform.localScale = Vector3.one;
            Selection.gameObjects[i].transform.rotation = Quaternion.identity;
        }
    }
}
