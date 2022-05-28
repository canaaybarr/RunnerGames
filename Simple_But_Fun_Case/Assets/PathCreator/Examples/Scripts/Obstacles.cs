using UnityEngine;

public class Obstacles : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("CollectedObj"))
        {
            gameObject.SetActive(false);
        }
    }
}
