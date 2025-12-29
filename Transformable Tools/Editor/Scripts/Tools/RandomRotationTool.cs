using UnityEngine;
using UnityEditor;

[System.Serializable]
public class RandomRotationTool
{
    public enum Mode
    {
        Set,
        Add
    }

    [SerializeField] private Vector3 minAngel;
    [SerializeField] private Vector3 maxAngel;
    [SerializeField] private Mode mode;


    public void Draw()
    {
        GUILayout.Space(10);
        GUILayout.Label("Random Rotation", EditorStyles.boldLabel);

        minAngel = EditorGUILayout.Vector3Field(new GUIContent("MinAngel"), minAngel);
        maxAngel = EditorGUILayout.Vector3Field(new GUIContent("MaxAngel"), maxAngel);

        mode = (Mode) EditorGUILayout.EnumPopup(new GUIContent("Mode"), mode); 
        
        if (GUILayout.Button(new GUIContent("Set Random Rotation")))
        {
            SetRandomRotation();
        }
    }

    private void SetRandomRotation()
    {
        for (int i = 0; i < Selection.gameObjects.Length; i++)
        {
            Undo.RecordObject(Selection.gameObjects[i].transform, "Random Rotation");

            Vector3 newEulerAngel = Selection.gameObjects[i].transform.eulerAngles;

            if (mode == Mode.Set)
            {
                newEulerAngel = new Vector3(
                    Random.Range(minAngel.x, maxAngel.x),
                    Random.Range(minAngel.y, maxAngel.y),
                    Random.Range(minAngel.z, maxAngel.z));
            }

            if (mode == Mode.Add)
            {
                newEulerAngel += new Vector3(
                    Random.Range(minAngel.x, maxAngel.x),
                    Random.Range(minAngel.y, maxAngel.y),
                    Random.Range(minAngel.z, maxAngel.z));
            }

            Selection.gameObjects[i].transform.eulerAngles = newEulerAngel;
        }
    }
}
