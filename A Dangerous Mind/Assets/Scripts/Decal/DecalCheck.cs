using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecalCheck : MonoBehaviour
{
    [SerializeField] private bool positionCheck;
    [SerializeField] private bool rayCastCheck;
    [SerializeField] private GameObject reward;
    [SerializeField] private DecalLocationTrigger decalTrigger;
    [SerializeField] private DecalRaycast decalRay;

    public void InPosition(bool var, DecalLocationTrigger decal)
    {
        decalTrigger = decal;
        positionCheck = var;
        CheckIfReady();
    }

    public void RaycastHit(bool var, DecalRaycast decal)
    {
        rayCastCheck = var;
        decalRay = decal;
        CheckIfReady();
    }

    private void CheckIfReady()
    {
        if (positionCheck && rayCastCheck)
        {
            Destroy(decalTrigger.gameObject);
            decalRay.CanCast = false;
            Destroy(this.gameObject);
            reward.SetActive(true);
        }
    }
}
