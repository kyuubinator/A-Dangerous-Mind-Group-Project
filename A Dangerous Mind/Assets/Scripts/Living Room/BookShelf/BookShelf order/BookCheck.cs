using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookCheck : MonoBehaviour
{
    [SerializeField] private BookshelfManager bookshelfManager;
    [SerializeField] private int bookId;
    [SerializeField] private int socketId;
    private bool hasBook;

    private void OnTriggerEnter(Collider other)
    {
        Book book = other.GetComponent<Book>();
        if (book != null)
        {
            bookId = book.Id;
            if (bookId == socketId)
            {
                if (!hasBook)
                {
                    OnBookIn();
                    hasBook = true;
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Book book = other.GetComponent<Book>();
        if (book != null)
        {
            bookId = book.Id;
            if (hasBook)
            {
                OnBookOut();
                hasBook = false;
            }
        }
    }
    private void OnBookIn()
    {
        bookshelfManager.BookCheck(bookId, true);
    }

    private void OnBookOut()
    {
        if (bookshelfManager != null)
        {
            bookshelfManager.BookCheck(bookId, false);
        }
    }
}
