using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Clock : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private MinutesPointer minPointer;
    [SerializeField] private HoursPointer hourPointer;
    [SerializeField] private Animator anim;
    [SerializeField] private XRGrabInteractable[] interactable;
    [SerializeField] private GameManager gameManager;
    [Header("values")]
    [SerializeField] private int hours;

    [SerializeField] private bool complete;

    private void Start()
    {
        if (anim != null)
        anim = GetComponentInChildren<Animator>();
    }

    public void CorrectHour()
    {
        hours++;
        CheckIfCorrect();
    }

    public void WrongHour()
    {
        hours--;
    }

    private void CheckIfCorrect()
    {
        if (hours == 2) 
        {
            anim.SetTrigger("Unlock");
            minPointer.enabled= false;
            hourPointer.enabled= false;
            for (int i = 0; i < interactable.Length; i++)
            {
                interactable[i].enabled = false;
            }
            gameManager.UnlockStorage();
        }
    }
}
