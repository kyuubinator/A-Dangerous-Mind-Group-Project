using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecalLocationTrigger : MonoBehaviour
{
    [SerializeField] private DecalCheck decalCheck;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("DecalHit"))
        {
            bool decal = true;
            other.GetComponent<DecalRaycast>().CanCast = decal;
            decalCheck.InPosition(decal, this);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("DecalHit"))
        {
            bool decal = false;
            other.GetComponent<DecalRaycast>().CanCast = decal;
            decalCheck.InPosition(decal, this);
        }
    }

    
}
