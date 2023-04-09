using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintingsPuzzle : MonoBehaviour
{
    [SerializeField] private int paintings;
    [SerializeField] private int totalPaintings;
    [SerializeField] private bool complete;
    


    public void AddPainting()
    {
        paintings++;
    }

    public void RemovePainting() 
    {
        paintings--;
    }

    public void CheckPaintings()
    {
        if (totalPaintings == paintings)
        {
            complete = true;
        }
    }
}
