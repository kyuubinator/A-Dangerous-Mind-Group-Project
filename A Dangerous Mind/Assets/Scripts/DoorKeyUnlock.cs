using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorKeyUnlock : MonoBehaviour
{
    [SerializeField] private GameObject[] Door;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Key")
        {
            for (int i = 0; i < Door.Length; i++)
            {
                Destroy(Door[i]);
            }
            Destroy(this);
        }
    }
}
