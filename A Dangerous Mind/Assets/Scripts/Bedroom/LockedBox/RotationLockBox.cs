using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationLockBox : MonoBehaviour
{
    [SerializeField] private int locksSolved;
    [SerializeField] private int lockNumber;
    [SerializeField] private GameObject lid;

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
            Destroy(lid);
            Debug.Log("case Opened");
            Destroy(this);
        }
    }
}
