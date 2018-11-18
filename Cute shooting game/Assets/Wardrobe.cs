using UnityEngine;
using System.Collections;

public class Wardrobe : MonoBehaviour 
{
    public SkinnedMeshRenderer skin;
    public SkinnedMeshRenderer[] clothes;

	private void Start ()
	{
        for(int i = 0; i < this.clothes.Length; i++)
        {
            SkinnedMeshRenderer newMesh = Instantiate(this.clothes[i]);
            this.clothes[i] = newMesh;
            newMesh.transform.parent = this.transform;
            newMesh.bones = this.skin.bones;
            newMesh.rootBone = this.skin.rootBone;
        }
	}
}