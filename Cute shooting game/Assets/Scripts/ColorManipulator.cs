using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorManipulator : MonoBehaviour
{
    [SerializeField] private Color changeColorTo;
    [SerializeField] private Wardrobe wardrobe;
    private Color originalColor;

    public void ChangeColor()
    {
        this.wardrobe.skin.material.color = this.changeColorTo;

        foreach(SkinnedMeshRenderer mesh in this.wardrobe.clothes)
        {
            this.originalColor = Color.white;
            mesh.material.color = this.changeColorTo;
        }
    }

    public void ResetColor()
    {
        this.wardrobe.skin.material.color = this.originalColor;

        foreach (SkinnedMeshRenderer mesh in this.wardrobe.clothes)
        {
            mesh.material.color = this.originalColor;
        }
    }
}
