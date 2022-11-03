using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject door;
    [SerializeField] private GameObject key;
    [SerializeField] private Animator animator;


    public void BeGoneThot()
    {
        animator.enabled = true;
        animator.SetTrigger("Unlock");
        StartCoroutine(DoorUnlock());
    }
    
    IEnumerator DoorUnlock()
    {
        yield return new WaitForSeconds(1.5f);
        //door.SetActive(false);
        key.transform.SetParent(door.transform, true);

    }
}
