using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SocketActivateObject : MonoBehaviour
{
    [SerializeField] private GameObject door;



    public void BeGoneThot()
    {
        if (door == true)
        {
            door.SetActive(false);
        }
    }
}
