using Newtonsoft.Json.Serialization;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Transactions.Configuration;
using UnityEditor.UIElements;
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
