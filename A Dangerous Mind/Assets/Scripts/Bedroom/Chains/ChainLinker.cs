using Newtonsoft.Json.Serialization;
using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;

public class ChainLinker : MonoBehaviour
{
    [SerializeField] private GameObject[] chains;
    [SerializeField] private FixedJoint[] fixedJoints;
    [SerializeField] private Rigidbody[] rb;



    private void Start()
    {
        for (int i = 0; i < chains.Length; i++)
        {
            rb[i] = chains[i].GetComponent<Rigidbody>();
        }
        for (int i = 0; i < chains.Length; i++)
        {
            if (chains[i].GetComponent<FixedJoint>() != null)
            {
                fixedJoints[i] = chains[i].GetComponent<FixedJoint>();
            }
        }
        for (int i = 0; i < fixedJoints.Length; i++)
        {
            if (i == 0)
            {

            }
            else
            {
                fixedJoints[i].connectedBody = rb[i - 1];
            }
        }
    }

}
