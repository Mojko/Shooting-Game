using UnityEngine;
using System.Collections;

public class Wardrobe : MonoBehaviour 
{
    public SkinnedMeshRenderer skinnedMeshRenderer;
    public SkinnedMeshRenderer[] clothes;

	private void Start ()
	{
		foreach(var cloth in clothes)
        {
            SkinnedMeshRenderer newMesh = Instantiate(cloth);
            newMesh.transform.parent = this.transform;
            newMesh.bones = this.skinnedMeshRenderer.bones;
            newMesh.rootBone = this.skinnedMeshRenderer.rootBone;
        }
	}
	
	private void Update ()
	{
		
	}
}