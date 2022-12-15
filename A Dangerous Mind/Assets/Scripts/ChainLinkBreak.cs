using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChainLinkBreak : MonoBehaviour
{
    [SerializeField] private HingeJoint hingejoint;
    [SerializeField] private FixedJoint joint;

    void Start()
    {
        hingejoint = GetComponentInParent<HingeJoint>();
        joint = GetComponentInParent<FixedJoint>();
    }

    public void BreakLink()
    {
        if (joint == null)
            //hingejoint.connectedBody = null;
            Destroy(hingejoint);
        else
            //joint.connectedBody = null;
            Destroy(joint);
    }
}
