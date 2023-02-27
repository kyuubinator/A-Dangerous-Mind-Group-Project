using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationLock : MonoBehaviour
{
    [SerializeField] private float anglePerNumber = 36;
    [SerializeField] private float angleOffSet = 18;
    [SerializeField] private float currentAngle;
    [SerializeField] private float currentAngleOffSet;
    [SerializeField] private int value;
    [SerializeField] private int desiredValue;
    [SerializeField] private bool sentValue;
    [SerializeField] private RotationLockBox rotationBox;
    private float time;

    private void Update()
    {
        time += Time.deltaTime;
        if (time > 0.2f)
        {
            currentAngle = this.transform.eulerAngles.z;

            for (int i = 0; i < 10; i++)
            {
                if ((currentAngle - currentAngleOffSet >= anglePerNumber * i - 18) && (currentAngle - currentAngleOffSet <= anglePerNumber * i + 18))
                {
                    value = i;
                    Debug.Log(value);
                }
            }

            if (value == desiredValue)
            {
                if (rotationBox != null && !sentValue)
                {
                    sentValue = true;
                    rotationBox.SolveLock();
                }
            }
            if (value != desiredValue)
            {
                if (rotationBox != null && sentValue)
                {
                    sentValue = false;
                    rotationBox.UnsolveLock();
                }
            }

            time = 0;
        }
    }
}
