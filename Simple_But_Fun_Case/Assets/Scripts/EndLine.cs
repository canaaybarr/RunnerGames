using UnityEngine;

public class EndLine : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("CollectedObj"))
        {
            gameObject.GetComponent<BoxCollider>().enabled = false;
        }
    }
}
