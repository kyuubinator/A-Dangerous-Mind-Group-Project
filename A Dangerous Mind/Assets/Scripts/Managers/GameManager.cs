using System.Collections;
using System.Collections.Generic;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.XR.Interaction.Toolkit;

public class GameManager : MonoBehaviour
{
    [SerializeField] private XRGrabInteractable[] clock;
    [SerializeField] private Animator[] animDoors;    // 0 Bedroom Open // 1 Storage  Open // 2 LivingRoom Open // 3 Bedroom Close // 4 Storage  Close // 5 LivingRoom Close
    [SerializeField] private AudioManager audioManager;
    [SerializeField] private GameObject[] lights;
    [SerializeField] private Animator finalDoor;
    [SerializeField] private GameObject fakeDoor;
    [SerializeField] private GameObject entity;
    [SerializeField] private GameObject entity2;
    [SerializeField] private Renderer entity2Renderer;
    [SerializeField] private Animator animEntity2;

    [SerializeField] private GameObject finalSeqTriggers;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject endLocation;
    [SerializeField] private bool canSeeCreature;
    [SerializeField] private GameObject[] candleChecks;

    private bool crowbarVar;
    private bool isLivingRoomUnlocked;

    [SerializeField] private GameObject entityCorridor;

    private void Update()
    {
        LookAtCreature();
    }

    public void KinematicOn(Rigidbody value)
    {
        value.isKinematic = true;
    }

    public void KinematicOff(Rigidbody value)
    {
        value.isKinematic = false;
    }

    public void UnlockClockPuzzle()
    {
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
        lights[1].SetActive(true);
        yield return new WaitForSeconds(1);
        animDoors[0].SetTrigger("Unlock");
        audioManager.DoorSoundEffects[0].Play();
    }

    public void CloseBedroom()
    {
        lights[0].SetActive(false);
        //Ligths off sound
        animDoors[0].SetTrigger("Close");
        audioManager.DoorSoundEffects[3].Play();
        //Door Close Sound
        candleChecks[0].SetActive(true);
    }

    public void UnlockStorage()
    {
        StartCoroutine(UnlockStorageCor());
    }

    IEnumerator UnlockStorageCor() 
    {
        lights[2].SetActive(true);
        yield return new WaitForSeconds(2);
        animDoors[1].SetTrigger("Unlock");
        audioManager.DoorSoundEffects[1].Play();
        //Door Open sound
    }

    public void CloseStorage()
    {
        animDoors[1].SetTrigger("Close");
        audioManager.DoorSoundEffects[1].Play();
        // door Close Sound
        lights[2].SetActive(false);
        candleChecks[1].SetActive(true);
    }

    public void UnlockLivingRoom()
    {
        if (!isLivingRoomUnlocked)
        {
            StartCoroutine(UnlockLivingRoomDoor());
        }
    }

    IEnumerator UnlockLivingRoomDoor()
    {
        lights[3].SetActive(true);
        isLivingRoomUnlocked = true;
        entityCorridor.SetActive(true);
        yield return new WaitForSeconds(2);
        animDoors[2].SetTrigger("Unlock");
        audioManager.DoorSoundEffects[2].Play();
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

    public void PickUpCrowbar()
    {
        if (!crowbarVar)
        {
            CloseBedroom();
            crowbarVar = true;
        }
    }

    public void CompleteSlidingPuzzle()
    {
        lights[1].SetActive(false);
    }

    #region EndSequence

    public void StartFinalSequence()
    {
        StartCoroutine(StartFinalSeq());
    }

    IEnumerator StartFinalSeq()
    {
        yield return new WaitForSeconds(2);
        finalSeqTriggers.SetActive(true);
        fakeDoor.SetActive(false);
        entity.SetActive(true);
        lights[4].SetActive(true);
        audioManager.RandomSoundEffects[0].Play();
    }

    public void StepTrigger(int value)
    {
        if (value == 1)
        {
            StepTrigger1();
        }
        if (value == 2)
        {
            StepTrigger2();
        }
    }
    
    private void StepTrigger1()
    {
        //CloseBedroom();
        CloseStorage();
    }

    private void StepTrigger2()
    {
        StartCoroutine(FinalScene());
    }

    IEnumerator FinalScene()
    {
        finalDoor.enabled = true;
        yield return new WaitForSeconds(2);
        lights[4].SetActive(false);
        yield return new WaitForSeconds(0.5f);
        audioManager.EntitySounds[1].Play();
        yield return new WaitForSeconds(1);
        entity2.SetActive(true);
        animEntity2.SetTrigger("PrepRun");
        canSeeCreature = true;
        //yield return new WaitForSeconds(2);
        //animEntity2.SetTrigger("StartRunning");
        //audioManager.EntitySounds[0].Play();
        //yield return new WaitForSeconds(0.7f);
        //player.transform.position = new Vector3(endLocation.transform.position.x, player.transform.position.y, endLocation.transform.position.z);
    }

    private void LookAtCreature()
    {
        if (canSeeCreature)
        {
            if (entity2Renderer.isVisible == true)
                StartCoroutine(SeenCreature());
        }   
    }

    IEnumerator SeenCreature()
    {
        canSeeCreature = false;
        yield return new WaitForSeconds(1);
        animEntity2.SetTrigger("StartRunning");
        audioManager.EntitySounds[0].Play();
        yield return new WaitForSeconds(0.7f);
        player.transform.position = new Vector3(endLocation.transform.position.x, player.transform.position.y, endLocation.transform.position.z);
    }

    #endregion

    #region Audio

    public void PlayDoorSound(int value)
    {
        if (value < audioManager.DoorSoundEffects.Length)
            audioManager.DoorSoundEffects[value].Play();
    }

    public void PlaySoundEffect(int value)
    {
        if (value < audioManager.SoundEffects.Length)
            audioManager.SoundEffects[value].Play();
    }
    #endregion
}
