using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookshelfManager : MonoBehaviour
{
    [SerializeField] private bool[] checks;
    [SerializeField] private Animator anim;
    [SerializeField] private GameObject decal;
    [SerializeField] private GameManager gameManager;
    [Header("Books")]
    [SerializeField] private GameObject books;
    [SerializeField] private GameObject fakeBooks;

    public void BookCheck(int var,bool check)
    {
        checks[var] = check;
        if (check == true) 
        { 
            CheckIfComplete();
        }
    }

    private void CheckIfComplete()
    {
        for (int i = 0; i < checks.Length; i++)
        {
            if (checks[i] == true)
            {

            }
            else
                return;
        }
        Complete();
    }
    
    private void Complete()
    {
        anim.enabled = true;
        decal.SetActive(true);
        gameManager.StartFinalSequence();
        books.SetActive(false);
        fakeBooks.SetActive(true);
    }
}
