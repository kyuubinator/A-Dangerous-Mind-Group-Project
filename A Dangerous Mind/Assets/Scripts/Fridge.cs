using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fridge : MonoBehaviour
{
    [SerializeField] private GameObject fridgeKey;
    private bool isUnlocked;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("FridgeKey"))
        {
            Destroy(other.gameObject);
            isUnlocked = true;
            fridgeKey.SetActive(true);
            rb.isKinematic = false;
        }
    }
}
