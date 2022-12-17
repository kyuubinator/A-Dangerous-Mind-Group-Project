using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grab_Restrictor : MonoBehaviour
{
    [SerializeField] private GameObject rightHandRay;
    [SerializeField] private GameObject leftHandRay;
    [SerializeField] private GameObject rightHand;
    [SerializeField] private GameObject leftHand;


    public void RightHandGrabON()
    {
        rightHand.SetActive(false);

        rightHandRay.SetActive(false);
    }

    public void LeftHandGrabOn()
    {
        leftHand.SetActive(false);

        leftHandRay.SetActive(false);
    }

    public void RightHandGrabOff()
    {
        rightHand.SetActive(true);

        rightHandRay.SetActive(true);
    }

    public void LeftHandGrabOff()
    {
        leftHand.SetActive(true);

        leftHandRay.SetActive(true);
    }
}
