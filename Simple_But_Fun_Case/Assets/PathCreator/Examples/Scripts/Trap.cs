using PathCreation.Examples;
using UnityEngine;
using System.Collections;

public class Trap : MonoBehaviour
{
    public GameObject ragdoll;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //Character Kötü Objelere Değdiğinde ragdoll ölme
            other.gameObject.GetComponent<Movement>()?.Active(false);
            Movement.Instance.anim.enabled = false;
            ragdoll.SetActive(true);
            other.gameObject.GetComponent<BoxCollider>().enabled = false;
            other.gameObject.GetComponentInParent<PathFollower>().enabled = false;
            StartCoroutine(WaitFor());
        }
    }
    
    IEnumerator WaitFor()
    {
        yield return new WaitForSeconds(1f);
        GameManager.Instance.Restart();
    }
}
