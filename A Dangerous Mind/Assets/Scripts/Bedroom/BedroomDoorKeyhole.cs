using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BedroomDoorKeyhole : MonoBehaviour
{
    [SerializeField] private GameObject key;
    [SerializeField] private GameManager gameManager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Key"))
        {
            other.gameObject.SetActive(false);
            key.gameObject.SetActive(true);
            gameManager.UnlockBedroom();
        }
    }
}