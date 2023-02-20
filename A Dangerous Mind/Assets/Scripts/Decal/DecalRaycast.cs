using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecalRaycast : MonoBehaviour
{
    private bool canCast;
    [SerializeField] private LayerMask layerMask;
    private DecalCheck decalCheck;

    public bool CanCast { get => canCast; set => canCast = value; }

    private void Update()
    {
        if (canCast)
        {

            //EDIT THE VECTOR FOR IT TO WORK PROPERLY!!!!!!!!!!!!!!!!!!!!!!!!  (currently in Vector3.back because it worked best for non vr at the moment of codding :)
            
            RaycastHit hit;
            Debug.DrawRay(transform.position, Vector3.back, Color.red, 1);
            if (Physics.Raycast(transform.position, Vector3.back, out hit, 20, layerMask))
            {
                if(hit.collider != null)
                {
                    bool var = true;
                    hit.collider.gameObject.GetComponent<DecalCheck>().RaycastHit(var, this);
                }
            }
            else
            {
                if (decalCheck != null)
                {
                bool var = false;
                decalCheck.RaycastHit(var, this);
                }
                else
                {

                }
            }
        }
    }
}
