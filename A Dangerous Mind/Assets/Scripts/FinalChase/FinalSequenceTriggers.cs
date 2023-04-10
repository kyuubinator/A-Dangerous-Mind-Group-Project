using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalSequenceTriggers : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private int value;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            gameManager.StepTrigger(value);
            Destroy(this.gameObject);
        }
    }
}
