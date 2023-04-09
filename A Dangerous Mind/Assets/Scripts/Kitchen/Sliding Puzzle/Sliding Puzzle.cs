using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlidingPuzzle : MonoBehaviour
{
    [SerializeField] private GameObject[] slidingPieces;

    [SerializeField] private GameObject[] piecesPos;

    [SerializeField] private GameObject[] puzzleSolution;
    [SerializeField] private GameObject[] possibleMove;


    public void AddPiece(GameObject piece)
    {
        
    }

    private void TryToMove(GameObject piece)
    {
        for (int i = 0; i < possibleMove.Length; i++)
        {
            if (possibleMove[i] == piece)
            {

            }
        }
    }
}
