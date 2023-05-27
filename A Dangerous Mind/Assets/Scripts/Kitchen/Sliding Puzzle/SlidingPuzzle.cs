using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SlidingPuzzle : MonoBehaviour
{
    
    [SerializeField] private XRGrabInteractable[] pieces;
    [SerializeField] private bool[] piecesInPlace;
    [Header("After Completion")]
    [SerializeField] private bool complete;
    [SerializeField] private Animator chestAnim;
    [SerializeField] private XRGrabInteractable reward;
    [SerializeField] private GameManager gameManager;
    [SerializeField] private GameObject piecesSolved;

    public void RecievePiece(int piece,bool var)
    {
        piecesInPlace[piece] = var;
        if (var == true)
        {
            CheckComplete();
        }
    }

    private void CheckComplete()
    {
        for (int i = 0; i < piecesInPlace.Length; i++)
        {
            if (piecesInPlace[i] == true)
            {

            }
            else
                return;
        }
        Complete();
    }

    private void Complete()
    {
        for (int i = 0; i < pieces.Length; i++)
        {
            pieces[i].gameObject.SetActive(false);
        }
        piecesSolved.SetActive(true);
        chestAnim.SetTrigger("Unlock");
        reward.enabled = true;
        gameManager.CompleteSlidingPuzzle();
    }
}
