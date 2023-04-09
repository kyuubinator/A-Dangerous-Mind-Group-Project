using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class GameManager : MonoBehaviour
{
    [SerializeField] private XRGrabInteractable[] clock;

    public void KinematicOn(Rigidbody value)
    {
        value.isKinematic = true;
    }

    public void KinematicOff(Rigidbody value)
    {
        value.isKinematic = false;
    }

    public void UnlockClockPuzzle(Rigidbody value)
    {
        value.isKinematic = false;
        for (int i = 0; i < clock.Length; i++)
        {
            clock[i].enabled = true;
        }
    }
}
