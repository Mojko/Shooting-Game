using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorManipulator : MonoBehaviour
{
    [SerializeField] private Color changeColorTo;
    [SerializeField] private Model model;

    public void ChangeColor()
    {
        model.SetColor(this.changeColorTo);
    }

    public void ResetColor()
    {
        model.ResetColor();
    }
}
