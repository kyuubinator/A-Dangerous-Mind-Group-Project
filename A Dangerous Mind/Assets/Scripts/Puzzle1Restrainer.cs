using UnityEngine;

public class Puzzle1Restrainer : MonoBehaviour
{
    [SerializeField] private GameObject fakeHand;
    [SerializeField] private GameObject playerHand;
    [SerializeField] private GameObject[] restrains;

    private void Update()
    {
        float time =+ Time.deltaTime;
        if (time >= 0.2f)
        {
            playerHand.SetActive(false);
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
        Destroy(fakeHand);
        for (int i = 0; i < restrains.Length; i++)
        {
            Destroy(restrains[i]);
        }
        playerHand.SetActive(true);
        Destroy(this);
    }
}
