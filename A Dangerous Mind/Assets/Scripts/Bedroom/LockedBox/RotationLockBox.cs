using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class RotationLockBox : MonoBehaviour
{
    [SerializeField] private int locksSolved;
    [SerializeField] private int lockNumber;
    [SerializeField] private Animator lid;
    [SerializeField] private XRGrabInteractable[] locks;

    public void SolveLock()
    {
        locksSolved++;
        CheckLocks();
    }

    public void UnsolveLock()
    {
        locksSolved--;
    }

    private void CheckLocks()
    {
        if (locksSolved == lockNumber)
        {
            lid.enabled = true;
            Debug.Log("case Opened");
            for (int i = 0; i < locks.Length; i++)
            {
                locks[i].enabled = false;
            }
            Destroy(this);
        }
    }
}
