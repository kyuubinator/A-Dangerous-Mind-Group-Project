using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

public class FakeHandMover : MonoBehaviour
{
    [SerializeField] private Transform pivot;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private Vector3 dir;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        dir = pivot.position - transform.position;
        if (dir.x < 0.01f && dir.x > -0.01f && dir.y < 0.01f && dir.y > -0.01f && dir.z < 0.01f && dir.z > -0.01f)
        {

        }
        else
        {
           rb.MovePosition(transform.position + dir * Time.deltaTime * 12);
        }
        rb.MoveRotation(pivot.rotation);
    }
}
