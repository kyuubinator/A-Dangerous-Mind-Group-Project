using Newtonsoft.Json.Serialization;
using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;

public class ChainLinkerHinge : MonoBehaviour
{
    [SerializeField] private GameObject[] chains;
    [SerializeField] private HingeJoint[] hingeJoints;
    [SerializeField] private Rigidbody[] rb;



    private void Start()
    {
        for (int i = 0; i < chains.Length; i++)
        {
            rb[i] = chains[i].GetComponent<Rigidbody>();
        }
        for (int i = 0; i < chains.Length; i++)
        {
            if (chains[i].GetComponent<HingeJoint>() != null)
            {
                hingeJoints[i] = chains[i].GetComponent<HingeJoint>();
            }
        }
        for (int i = 0; i < hingeJoints.Length; i++)
        {
            if (i == 0)
            {

            }
            else
            {
                hingeJoints[i].connectedBody = rb[i - 1];
            }
        }
    }

}
