using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorManipulator : MonoBehaviour
{
    [SerializeField] private Color changeColorTo;
    [SerializeField] private SkinnedMeshRenderer model;
    private Color originalColor;

    public void ChangeColor()
    {
        this.originalColor = this.model.material.color;
        this.model.material.color = this.changeColorTo;
    }

    public void ResetColor()
    {
        this.model.material.color = this.originalColor;
    }
}
