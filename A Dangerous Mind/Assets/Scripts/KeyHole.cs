using System.Collections;
using System.Collections.Generic;
using System.Transactions.Configuration;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class KeyHole : MonoBehaviour
{
    [SerializeField] private XRGrabInteractable interactable;

    private void Start()
    {
         interactable = GetComponentInParent<XRGrabInteractable>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Key"))
        {
            other.gameObject.SetActive(false);
            if (interactable != null)
            {
                interactable.enabled = true;
            }
            Destroy(this);
        }
    }
}
