using UnityEngine;
using System.Collections;

public class Wardrobe : MonoBehaviour 
{
    public SkinnedMeshRenderer skin;
    public SkinnedMeshRenderer[] clothes;

	private void Start ()
	{
		foreach(var cloth in clothes)
        {
            SkinnedMeshRenderer newMesh = Instantiate(cloth);
            newMesh.transform.parent = this.transform;
            newMesh.bones = this.skin.bones;
            newMesh.rootBone = this.skin.rootBone;
        }
	}
	
	private void Update ()
	{
		
	}
}