using System;
using UnityEngine;
using UnityEditor;

[Serializable]
public class SetOnFloorTool
{
    [SerializeField] private LayerMask raycastMask = 0; 
    [SerializeField] private bool alongByNormal;
   

    public void Draw()
    {
        GUILayout.Space(10);
        GUILayout.Label("Set on Floor", EditorStyles.boldLabel);

        EditorGUILayout.LabelField("Raycast Mask:", GUILayout.Width(80));
        raycastMask = EditorGUILayout.LayerField(raycastMask);

        alongByNormal = EditorGUILayout.Toggle(new GUIContent("Along By Normal"), alongByNormal);

        if (GUILayout.Button(new GUIContent("Set On Floor")))
        {
            SetOnFloor();
        }
    }

    private void SetOnFloor()
    {
        for (int i = 0; i < Selection.gameObjects.Length; i++)
        {
            Undo.RecordObject(Selection.gameObjects[i].transform, "Undo Set On Floor");

            RaycastHit raycastHit;

            // Добавлена маска raycastMask в Physics.Raycast
            if (Physics.Raycast(Selection.gameObjects[i].transform.position, Vector3.down, out raycastHit, 10000f, raycastMask))
            {
                Selection.gameObjects[i].transform.position = raycastHit.point;

                if (alongByNormal == true)
                    Selection.gameObjects[i].transform.up = raycastHit.normal;
            }
        }
    }
}
