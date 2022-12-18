using UnityEngine;

public class Puzzle1Restrainer : MonoBehaviour
{
    [SerializeField] private GameObject fakeHand;
    [SerializeField] private GameObject playerHand;
    [SerializeField] private GameObject[] restrains;

    private void Update()
    {
        float time =+ Time.deltaTime;
        if (time >= 0.1f)
        {
            if (playerHand.activeSelf)
            {
                playerHand.SetActive(false);
            }
            time = 0;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Key")
        {
            DestroyRestrains();
        }
    }

    private void DestroyRestrains()
    {
        Rigidbody rb = this.GetComponent<Rigidbody>();
        rb.isKinematic = false;

        Destroy(fakeHand);
        for (int i = 0; i < restrains.Length; i++)
        {
            Destroy(restrains[i]);
        }
        playerHand.SetActive(true);
        Destroy(this);
    }
}
