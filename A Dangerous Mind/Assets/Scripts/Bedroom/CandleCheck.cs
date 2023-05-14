using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using UnityEngine;

public class CandleCheck : MonoBehaviour
{
    [SerializeField] private Transform deliveryPoint;

    private float timer;

    private void FixedUpdate()
    {
        timer += Time.deltaTime;
        if (timer >= 0.5f)
        {
            timer = 0;
            this.gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Candle candle = other.GetComponent<Candle>();
        if (candle != null)
        {
            other.transform.position = deliveryPoint.position;
            other.transform.rotation = deliveryPoint.rotation;
        }
        Book book = other.GetComponent<Book>();
        if (book)
        {
            other.transform.position = deliveryPoint.position;
            other.transform.rotation = deliveryPoint.rotation;
        }
    }
}
