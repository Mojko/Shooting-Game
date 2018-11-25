using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class FbxImporter : MonoBehaviour 
{
    public GameObject fbx;

    private Animator animator;

    private void Start()
    {
        this.animator = this.GetComponent<Animator>();
    }
}