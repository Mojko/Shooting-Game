using UnityEngine;

[CreateAssetMenu(fileName = "New CameraSettings", menuName = "Camera Setting")]
public class CameraSettings : ScriptableObject
{
    public bool invertCamera;
    public float sensitivty;
}
