using System.Collections;
using UnityEngine;

public class SkorSystem : MonoBehaviour
{
    public GameObject cube;

    public Movement characterMovement;
    public int EndSkor;
    public Transform pos;
    public GameObject oldCam, NewCam;
    private void OnTriggerEnter(Collider other)
    {
        //Level sonunda üst üste para birikme
        if (other.CompareTag("CollectedObj"))
        {
            other.gameObject.GetComponent<MeshRenderer>().enabled = false;
            other.gameObject.GetComponent<BoxCollider>().enabled = false;
            EndSkor++;
            Instantiate(cube,new Vector3(pos.transform.position.x ,pos.transform.position.y+ EndSkor * 0.5f,pos.transform.position.z),Quaternion.identity);
            characterMovement.enabled = false;
            StartCoroutine(CamWait());
        }
        if (other.CompareTag("Player"))
        {
            
            StartCoroutine(AnimationWait());
        }
    }
    
    
    IEnumerator AnimationWait()
    {
        yield return new WaitForSeconds(0.5f);
        Movement.Instance.anim.SetBool("IsTree",false);
        
        yield return new WaitForSeconds(3.2f);
        GameManager.Instance.WinPanel();
    }
    IEnumerator CamWait()
    {
        oldCam.SetActive(false);
        NewCam.SetActive(true);
        yield return new WaitForSeconds(1.5f);
    }
}
