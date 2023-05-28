using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;

public class EntityCorridor1 : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private AudioSource audioE;
    [SerializeField] private BoxCollider colliderE;

    private void OnTriggerEnter(Collider other)
    {
        Camera player = other.GetComponent<Camera>();
        if (player != null)
        {
            colliderE.enabled = false;
            if (!animator.enabled)
            {
                animator.enabled = true;
            }
            else
            {
                animator.SetTrigger("Walk");
            }
            audioE.Play();
            StartCoroutine(End());
        }
    }

    IEnumerator End()
    {
        yield return new WaitForSeconds(4);
        Destroy(this.gameObject);
    }
}
