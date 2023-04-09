using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Paintings : MonoBehaviour
{
    [SerializeField] private PaintingsPuzzle puzzle;
    [SerializeField] private GameObject correctPainting;
    [SerializeField] private bool correct;

    public void HasPainting(GameObject painting)
    {
        if (painting == correctPainting)
        {
            puzzle.AddPainting();
            correct = true;
        }
    }

    public void HasNoPainting()
    {
        if (correct)
        {
            puzzle.RemovePainting();
        }
    }
}
