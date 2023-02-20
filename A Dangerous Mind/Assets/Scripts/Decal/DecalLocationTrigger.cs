using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecalLocationTrigger : MonoBehaviour
{
    [SerializeField] private DecalCheck decalCheck;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            bool decal = true;
            other.GetComponentInChildren<DecalRaycast>().CanCast = decal;
            decalCheck.InPosition(decal, this);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            bool decal = false;
            other.GetComponentInChildren<DecalRaycast>().CanCast = decal;
            decalCheck.InPosition(decal, this);
        }
    }

    
}
