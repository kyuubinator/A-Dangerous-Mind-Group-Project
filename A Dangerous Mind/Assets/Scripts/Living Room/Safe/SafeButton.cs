using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeButton : MonoBehaviour
{
    [SerializeField] private SafeManager safe;
    [SerializeField] private int id;
    [SerializeField] private float distance;
    private Vector3 inicialPos;
    private bool canCheck;

    [SerializeField] private AudioSource sound;

    private void Start()
    {
        inicialPos = this.transform.position;
        sound = this.GetComponent<AudioSource>();
    }

    private void FixedUpdate()
    {
        distance = inicialPos.x - transform.position.x;
        if (distance >= 0.01f && canCheck)
        {
            safe.RecieveInput(id);
            canCheck = false;
            sound.Play();

        }
        if (distance <= 0.005f && !canCheck)
        {
            canCheck = true;
        }
    }
}
