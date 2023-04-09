using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class LazyDemoSolution : MonoBehaviour
{
    [SerializeField] private Animator chestAnim;
    [SerializeField] private XRGrabInteractable reward;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            chestAnim.SetTrigger("Unlock");
            reward.enabled = true;
            Destroy(this.gameObject);
        }
    }
}
