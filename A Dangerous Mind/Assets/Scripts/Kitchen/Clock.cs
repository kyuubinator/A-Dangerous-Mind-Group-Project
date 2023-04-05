using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clock : MonoBehaviour
{
    [SerializeField] private GameObject minPointer;
    [SerializeField] private GameObject hourPointer;
    [SerializeField] private GameObject complete;

    [SerializeField] private float anglePerNumber = 30;
    [SerializeField] private float angleOffSet = 15;
    [SerializeField] private float currentAngle;
    [SerializeField] private float currentAngleOffSet;
    [SerializeField] private int hourValue;
    [SerializeField] private int minValue;
    [SerializeField] private int value;

    [SerializeField] private int desiredHour;
    [SerializeField] private int desiredMinute;

    [Header("Debug")]
    [SerializeField] private Vector3 hours;
    [SerializeField] private Vector3 minutes;
    [SerializeField] private Vector3 thisObject;
    private bool isComplete;
    private float time;

    private void Update()
    {
        minPointer.transform.rotation = Quaternion.Euler(0, 0, this.transform.eulerAngles.z);
        hourPointer.transform.rotation = Quaternion.Euler(0, 0, (minPointer.transform.eulerAngles.z / 12));
        CheckTimeValue();
        TestUpdate();
    }

    private void CheckTimeValue()
    {
        minutes = minPointer.transform.eulerAngles;
        hours = hourPointer.transform.eulerAngles;
        thisObject = this.transform.eulerAngles;
        if (!isComplete)
        {
            time += Time.deltaTime;
            if (time > 0.2f)
            {
                for (int e = 0; e <= 2; e++)
                {
                    if (e == 0)
                    {
                        currentAngle = minPointer.transform.localEulerAngles.z;

                        for (int i = 0; i < 12; i++)
                        {
                            if ((currentAngle - currentAngleOffSet >= anglePerNumber * i - 15) && (currentAngle - currentAngleOffSet <= anglePerNumber * i + 15))
                            {
                                currentAngle = minValue;
                                Debug.Log("Minutes " + minValue);
                                CheckIfComplete();
                            }
                        }
                    }
                    else
                    {
                        currentAngle = hourPointer.transform.localEulerAngles.z;
                        for (int i = 0; i < 12; i++)
                        {
                            if ((currentAngle - currentAngleOffSet >= anglePerNumber * i - 15) && (currentAngle - currentAngleOffSet <= anglePerNumber * i + 15))
                            {
                                currentAngle = hourValue;
                                Debug.Log("Hours " + hourValue);
                               
                                CheckIfComplete();
                            }
                        }
                    }

                }

                time = 0;
            }
        }
    }

    [SerializeField] private float totalRotation = 0;
    [SerializeField] private int nrOfRot;

    private Vector3 lastPoint;

    void Start()
    {
        lastPoint = transform.TransformDirection(Vector3.right);
        lastPoint.z = 0;
    }

    void TestUpdate()
    {
        Vector3 facing = transform.TransformDirection(Vector3.right);
        facing.z = 0;

        float angle = Vector3.Angle(lastPoint, facing);
        if (Vector3.Cross(lastPoint, facing).z < 0)
            angle *= -1;

        totalRotation += angle;
        lastPoint = facing;
        nrOfRot =  Mathf.Abs((int)totalRotation / 360);
    }

    private void CheckIfComplete()
    {
        if (hourValue == desiredHour && minValue == desiredMinute)
        {
            isComplete = true;
            complete.SetActive(true);
        }
    }
}
