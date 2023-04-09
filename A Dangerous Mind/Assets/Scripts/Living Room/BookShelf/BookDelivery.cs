using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookDelivery : MonoBehaviour
{
    [SerializeField] private BookShelfPuzzle bookshelf;
    private void OnTriggerEnter(Collider other)
    {
        Book book = other.GetComponent<Book>();
        if (book != null)
        {
            bookshelf.RecievedBook(book.Id);
            other.gameObject.SetActive(false);
        }
    }
}
