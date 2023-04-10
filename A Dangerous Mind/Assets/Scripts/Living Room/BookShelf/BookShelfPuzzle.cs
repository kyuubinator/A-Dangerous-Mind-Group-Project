using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookShelfPuzzle : MonoBehaviour
{
    [SerializeField] private int booksDelivered;
    [SerializeField] private int booksTotal;
    [SerializeField] private GameObject[] books;
    [SerializeField] private bool complete;
    [SerializeField] private Animator anim;
    [SerializeField] private GameObject decal;
    [SerializeField] private GameManager gameManager;


    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void RecievedBook(int value)
    {
        switch (value)
        {
            case 1:
                books[0].SetActive(true);
                AddBook();
                break;
            case 3:
                books[1].SetActive(true);
                AddBook();
                break;
            case 4:
                books[2].SetActive(true);
                AddBook();
                break;
        }
    }
    
    private void AddBook()
    {
        booksDelivered++;
        CheckBooks();
    }

    private void CheckBooks()
    {
        if (booksDelivered == booksTotal)
        {
            complete = true;
            anim.enabled = true;
            decal.SetActive(true);
            gameManager.StartFinalSequence();
        }
    }

}
