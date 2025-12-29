using UnityEngine;

public class SceneTransformableToolsCollector : ScriptableObject
{
    [SerializeField] private RandomRotationTool randomRotationTool;
    [SerializeField] private RandomScaleTool randomScaleTool;
    [SerializeField] private ResetRotationAndScaleTool resetRotationAndScaleTool;
    [SerializeField] private SetOnFloorTool setOnFloorTool;

    public void DrawAll()
    {
        randomRotationTool.Draw();
        randomScaleTool.Draw();
        resetRotationAndScaleTool.Draw();
        setOnFloorTool.Draw();
    }
}
