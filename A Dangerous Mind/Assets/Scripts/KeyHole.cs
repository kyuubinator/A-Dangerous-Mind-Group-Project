using System.Collections;
using System.Collections.Generic;
using System.Transactions.Configuration;
using UnityEngine;

public class KeyHole : MonoBehaviour
{
    [SerializeField] private GameObject handle;
    [SerializeField] private GameObject key;
    [SerializeField] private GameObject block;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Key")
        {
            other.gameObject.SetActive(false);
            if (key != null)
            {
                key.SetActive(true);
            }
            if (handle != null)
            {
                handle.SetActive(true);
            }
            if (block != null)
            {
                block.SetActive(false);
            }
        }
    }
}
