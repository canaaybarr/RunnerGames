using PathCreation.Examples;
using UnityEngine;

public class Collision : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("CollectObj"))
        {
            //Stackleme trigger
            if (!Stack.Instance.objects.Contains(other.GetComponent<PathFollower>()))
            {
                Collectable collectable = other.GetComponent<Collectable>();
                if (collectable != null && !collectable.isCollected)
                {
                    collectable.isCollected = true;
                    other.GetComponent<BoxCollider>().isTrigger = false;
                    other.gameObject.tag = "CollectedObj";
                    //RigidBody ve Collision kodu ondekilerinde Stackliye bilmesi için
                    other.gameObject.AddComponent<Collision>();
                    other.gameObject.AddComponent<Rigidbody>().isKinematic = true;
                    Stack.Instance.StackCube(other.gameObject,Stack.Instance.objects.Count -1);
                    Vibrator.Vibrate(GameManager.Instance.vibrateMilisc);
                }
            }
        }
        if (other.gameObject.tag == "Obstacles")
        {
            Stack.Instance.Distribute(gameObject);
            Vibrator.Vibrate(GameManager.Instance.vibrateMilisc);
        }
        if (other.CompareTag("Thorn"))
        {
            gameObject.GetComponent<BoxCollider>().enabled = false;
            Stack.Instance?.DistributeCollectibles(gameObject);
            Vibrator.Vibrate(GameManager.Instance.vibrateMilisc);
        }
    }
}
