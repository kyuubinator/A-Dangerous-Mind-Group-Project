using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clock : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private MinutesPointer minPointer;
    [SerializeField] private HoursPointer hourPointer;
    [Header("values")]
    [SerializeField] private int hours;

    [SerializeField] private bool complete;
    
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
            complete = true;
            minPointer.enabled= false;
            hourPointer.enabled= false;
        }
    }
}
