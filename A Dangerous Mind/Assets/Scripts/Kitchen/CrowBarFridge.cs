using Newtonsoft.Json.Serialization;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrowBarFridge : MonoBehaviour
{

    [SerializeField] private BoxCollider placeCrowbar;
    [SerializeField] private GameObject crowbar;
    private Vector3 inicialRotation;
    [SerializeField] private Animator fridgeAnimator;

    [SerializeField] private bool inPlace;
    [SerializeField] private float rotationC;
    // Start is called before the first frame update
    void Start()
    {
        placeCrowbar = GetComponent<BoxCollider>();
        inicialRotation = crowbar.transform.eulerAngles;
    }

    // Update is called once per frame
    void Update()
    {
        if (inPlace)
        {
            rotationC = Mathf.Abs(inicialRotation.y) - Mathf.Abs(crowbar.transform.eulerAngles.y);

            if (rotationC >= 22.0f) 
            {
                Debug.Log("Hello");
                inPlace = false;
                fridgeAnimator.SetTrigger("Open");
                StartCoroutine(Opened());
            }
        }
    }

    IEnumerator Opened()
    {
        yield return new WaitForSeconds(1f);
        crowbar.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (fridgeAnimator != null)
        {
            if (other.gameObject.CompareTag("Crowbar"))
            {
                Rigidbody rb = other.gameObject.GetComponent<Rigidbody>();
                if (Mathf.Abs(rb.velocity.y) >= 1f)   //Tests
                //if (rb.velocity.z <= -1f)   //Actual if for Swing Motion
                {
                    other.gameObject.SetActive(false);
                    crowbar.SetActive(true);
                    placeCrowbar.enabled = false;
                    inPlace = true;
                }
            }
        }
    }
}
