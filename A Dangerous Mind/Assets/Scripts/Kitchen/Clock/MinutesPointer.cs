using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinutesPointer : MonoBehaviour
{
    [SerializeField] private float anglePerNumber = 30;
    [SerializeField] private float angleOffSet = 15;
    [SerializeField] private float currentAngle;
    [SerializeField] private float currentAngleOffSet;
    [Header("Values")]
    [SerializeField] private int value;
    [SerializeField] private int desiredValue;
    [SerializeField] private bool sentValue;
    [SerializeField] private Clock clock;
    private float time;

    private void Update()
    {
        time += Time.deltaTime;
        if (time > 0.2f)
        {
            currentAngle = this.transform.eulerAngles.z;

            for (int i = 0; i <= 12; i++)
            {
                if ((currentAngle - currentAngleOffSet >= anglePerNumber * i - angleOffSet) && (currentAngle - currentAngleOffSet <= anglePerNumber * i + angleOffSet))
                {
                    value = i;
                    Debug.Log(value);
                }
            }

            if (value == desiredValue)
            {
                if (clock != null && !sentValue)
                {
                    sentValue = true;
                    clock.CorrectHour();
                }
            }
            if (value != desiredValue)
            {
                if (clock != null && sentValue)
                {
                    sentValue = false;
                    clock.CorrectHour();
                }
            }

            time = 0;
        }
    }
}
