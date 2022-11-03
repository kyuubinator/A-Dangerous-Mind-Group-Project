using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grab_Restrictor : MonoBehaviour
{
    [SerializeField] private GameObject rightHandRay;
    [SerializeField] private GameObject leftHandRay;
    [SerializeField] private GameObject rightHand;
    [SerializeField] private GameObject leftHand;
    [SerializeField] private SkinnedMeshRenderer rightHandMesh;
    [SerializeField] private SkinnedMeshRenderer leftHandMesh;
    public void RightHandGrabON()
    {
        Color color = rightHandMesh.material.color;
        color.a = 0;
        rightHandMesh.material.color = color;

        rightHandRay.SetActive(false);
        
    }

    public void LeftHandGrabOn()
    {
        Color color = leftHandMesh.material.color;
        color.a = 0;
        rightHandMesh.material.color = color;

        leftHandRay.SetActive(false);
    }

    public void RightHandGrabOff()
    {
        Color color = rightHandMesh.material.color;
        color.a = 1;
        rightHandMesh.material.color = color;

        rightHandRay.SetActive(true);
    }

    public void LeftHandGrabOff()
    {
        Color color = leftHandMesh.material.color;
        color.a = 1;
        rightHandMesh.material.color = color;

        leftHandRay.SetActive(true);
    }
}
