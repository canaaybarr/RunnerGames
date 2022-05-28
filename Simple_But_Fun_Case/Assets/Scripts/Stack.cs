
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using PathCreation.Examples;

public class Stack : MonoBehaviour
{
    public static Stack Instance;
    [SerializeField]private Transform stackedStacks,leaveTransform;
    public List<PathFollower> objects = new List<PathFollower>();
    public float movementDelay = 0.1f;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    private void Update()
    {
        MoveListElements();
    }
    public void StackCube(GameObject other, int index)
    {
        PathFollower pathFollower = other.transform.parent.GetComponent<PathFollower>();
        other.transform.parent.parent = stackedStacks; 
        float newPos = objects[index].distanceTravelled;
        newPos += 1;
        pathFollower.distanceTravelled = newPos;        
        objects.Add(pathFollower);
        pathFollower.enabled = true;
        StartCoroutine(ObjecBigger());
    }
    //Stacklendiği zaman Baştan sona şişirme
    private IEnumerator ObjecBigger()
    {
        for (int i = objects.Count-1; i > 0; i--)
        {
            int c = i;
            Vector3 scale = new Vector3(1, 1, 1);
            scale *= 1.5f;
            objects[c].transform.DOScale(scale, 0.1f)
                .OnComplete((() => objects[c].transform.DOScale(new Vector3(1, 1, 1), 0.1f)));

            yield return new WaitForSeconds(0.05f);
        }
    }
    //toplanınan objelerin characteri takip etmesi
   public void MoveListElements()
   {
       for (int i = 1; i < objects.Count; i++)
       {
           if (i == 1)
           {
               Vector3 pos = objects[i].transform.GetChild(0).localPosition;
               pos.y = objects[i - 1].transform.GetChild(1).localPosition.y;
               objects[i].transform.GetChild(0).DOLocalMove(pos, movementDelay);
           }
           else
           {
               Vector3 pos = objects[i].transform.GetChild(0).localPosition;
               pos.y = objects[i - 1].transform.GetChild(0).localPosition.y;
               objects[i].transform.GetChild(0).DOLocalMove(pos, movementDelay);
           }
       }
   }
   
   /// <summary>
   /// Hangi noktadan değdiyse ondan sonrakileri yok etme 
   /// </summary>
   public void DistributeCollectibles(GameObject other)
   {
       PathFollower pathFollower = other.transform.parent.GetComponent<PathFollower>();
       other.transform.parent.parent = leaveTransform;
       int  StartIndex = objects.IndexOf(pathFollower);
       int elemantCount = objects.Count;
       int selectedCount = elemantCount - StartIndex;
       for (int i = -1 ; i < selectedCount -1; i++)
       {
           if (StartIndex <= 0)
           {
               return;
           }
           PathFollower pf = objects[StartIndex];
           objects.Remove(pf);
           pf.enabled = false;
           Destroy(pf.gameObject);
       }
       
   }
   /// <summary>
   /// Stackten bir tane obje çıkarma 
   /// </summary>
   public void Distribute(GameObject other)
   {
       if (objects.Count <= 0)
       {
           return;
       }
       other.transform.parent.parent = leaveTransform;
       int elemantCount = objects.Count;
       PathFollower pf = objects[elemantCount -1];
       objects.Remove(pf);
       pf.enabled = false;
       Destroy(pf.gameObject);
   }
}    
