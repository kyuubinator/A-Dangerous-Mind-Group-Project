using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.XR.Interaction.Toolkit;

public class GameManager : MonoBehaviour
{
    [SerializeField] private XRGrabInteractable[] clock;
    [SerializeField] private Animator[] animDoors;    // 0 Bedroom // 1 Storage // 2 LivingRoom

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
    
    public void UnlockBedroom()
    {
        StartCoroutine(UnlockBedroomDoor());
    }

    IEnumerator UnlockBedroomDoor()
    {
        //Key Sound
        yield return new WaitForSeconds(1);
        animDoors[0].SetTrigger("Unlock");
        //Door Open sound
    }

    public void UnlockStorage()
    {
        StartCoroutine(UnlockStorageCor());
    }

    IEnumerator UnlockStorageCor() 
    {
        yield return new WaitForSeconds(2);
        animDoors[1].SetTrigger("Unlock");
        //Door Open sound
    }

    public void UnlockLivingRoom()
    {
        StartCoroutine(UnlockLivingRoomDoor());
    }

    IEnumerator UnlockLivingRoomDoor()
    {
        yield return new WaitForSeconds(2);
        animDoors[2].SetTrigger("Unlock");
        //Door Open sound
    }

    public void LockAllDoors()
    {
        for (int i = 0; i < animDoors.Length; i++)
        {
            animDoors[i].SetTrigger("Close");
            //Door Shutting sound
        }
    }

    public void UnlockAllDoors()
    {
        for (int i = 0; i < animDoors.Length; i++)
        {
            animDoors[i].SetTrigger("Close");
            //Door Open sound ?
        }
    }
}
