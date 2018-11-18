using UnityEngine;
using System.Collections;

public class LockMouse : MonoBehaviour 
{
    public bool locked;

    private void Update()
    {
        if (locked)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }
}