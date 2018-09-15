using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Model : MonoBehaviour
{
    private SkinnedMeshRenderer[] modelParts;
    private Color[] originalColors;

    private void Start()
    {
        this.modelParts = this.GetComponentsInChildren<SkinnedMeshRenderer>();
        this.originalColors = new Color[modelParts.Length];
    }

    public void SetColor(Color color)
    {
        for(int i = 0; i < this.modelParts.Length; i++)
        {
            this.originalColors[i] = this.modelParts[i].material.color;
            this.modelParts[i].material.color = color;
        }
    }

    public void SetColor(Color[] colors)
    {
        if(colors.Length > this.modelParts.Length)
        {
            throw new ArgumentException("You tried to add more colors than there are renderers");
        }

        for(int i = 0; i < colors.Length; i++)
        {
            this.modelParts[i].material.color = colors[i];
        }
    }

    public void ResetColor()
    {
        this.SetColor(Color.white);
    }
}
