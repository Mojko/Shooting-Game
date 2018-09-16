using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(Shooter))]
public class Editor_SaveToScriptableObject : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        Shooter offset = (Shooter)target;
        if (GUILayout.Button("Save values to ScriptableObject (Gun)"))
        {
            offset.gun.position = offset.transform.localPosition;
            offset.gun.rotation = offset.transform.localRotation.eulerAngles;
            offset.gun.scale = offset.transform.localScale;
        }
    }
}