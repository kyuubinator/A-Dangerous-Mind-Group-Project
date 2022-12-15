using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cutter : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "ChainLink")
        {
            ChainLinkBreak chainBreak = other.gameObject.GetComponent<ChainLinkBreak>();
            chainBreak.BreakLink();
            Destroy(other.gameObject);
        }
    }
}
