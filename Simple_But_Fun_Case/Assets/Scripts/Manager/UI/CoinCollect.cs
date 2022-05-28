using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollect : MonoBehaviour
{
    
    #region Singleton class : CoinCollect
    
    public static CoinCollect Instance;
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(this);
            return;
        } 
        Instance = this;
    }
    #endregion
        
    public float Speed;

    public Transform target;
    //public Transform initial;
    public GameObject moneyPrefab;
    public Camera cam;
    
    private void Start()
    {
        if (cam == null)
        {
            cam = Camera.main;
        }
    }

    public void StartMoneyMove(Vector3 _intial , Action onComplete)
    {
        //Vector3 initialpos = cam.ScreenToWorldPoint(new Vector3(initial.position.x, initial.position.y, cam.transform.position.z * -1));
        Vector3 targetPos = cam.ScreenToWorldPoint(new Vector3(target.position.x, target.position.y, cam.transform.position.z * -1));
        GameObject _money = Instantiate(moneyPrefab, transform);

        StartCoroutine(MoveMoney(_money.transform, _intial, targetPos, onComplete));
    }
    
    IEnumerator MoveMoney(Transform obj, Vector3 startPos, Vector3 endPos, Action onComplete)
    {
        float time = 0;

        while (time < 1)
        {
            time += Speed * Time.deltaTime;
            obj.position = Vector3.Lerp(startPos, endPos, time);
            
            yield return new WaitForEndOfFrame();
        }
        
        onComplete.Invoke();
    }
}
