using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorManipulator : MonoBehaviour
{
    [SerializeField] private Color changeColorTo;
    [SerializeField] private Wardrobe wardrobe;
    private Color[] originalColors;

    private void Start()
    {
        this.originalColors = new Color[wardrobe.clothes.Length + 1];

        this.originalColors[0] = this.wardrobe.skin.material.color;

        for(int i = 0; i < this.wardrobe.clothes.Length; i++)
        {
            this.originalColors[i] = this.wardrobe.clothes[i].material.color;
        }
    }

    public void ChangeColor()
    {
        this.wardrobe.skin.material.color = this.changeColorTo;

        foreach(SkinnedMeshRenderer mesh in this.wardrobe.clothes)
        {
            mesh.material.color = this.changeColorTo;
        }
    }

    public void ResetColor()
    {
        this.wardrobe.skin.material.color = this.originalColors[0];

        for (int i = 0; i < this.wardrobe.clothes.Length; i++)
        {
            this.wardrobe.clothes[i].material.color = this.originalColors[i];
        }
    }
}
