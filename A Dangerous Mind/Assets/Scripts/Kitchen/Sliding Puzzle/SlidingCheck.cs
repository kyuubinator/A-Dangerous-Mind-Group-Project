using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class SlidingCheck : MonoBehaviour
{
    [SerializeField] private SlidingPuzzle puzzle;
    [SerializeField] private int pieceId;
    [SerializeField] private int socketId;

    
    private void OnTriggerEnter(Collider other)
    {
        SlidingPiece piece = other.GetComponent<SlidingPiece>();
        if (piece != null)
        {
            pieceId = piece.Id;
            if (pieceId == socketId)
            {
                puzzle.RecievePiece(socketId,true);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        SlidingPiece piece = other.GetComponent<SlidingPiece>();
        if (piece != null)
        {
            pieceId = piece.Id;
            puzzle.RecievePiece(socketId,false);
        }
    }
}
