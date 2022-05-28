
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Movement : MonoBehaviour
{
    public static Movement Instance;
    private void Awake()
    {
        Instance = this;
        
        anim = GetComponentInChildren<Animator>();
        isGame = false;
        _rigidbody = GetComponent<Rigidbody>();
        cam = Camera.main;
    }


    [SerializeField] private Transform characterTr;
    
    #region Bool
    [Header("Start Game")]
    public bool isGame;
    #endregion
    
    #region Value
    [Header("Karakter Hızı & Swipe Hızı")]
    public float swipeSpeed;
    private float rotSpeed;
    [Header("LevelBoundaries")]
    public float min = -6.5f;
    public float max = 5.8f;
    float touchPosX;
    #endregion
    
    #region Location
    public Animator anim;
    private Rigidbody _rigidbody;
    private Camera cam;
    #endregion

    
    void Update()
    {
        anim.SetBool("IsTree",true);
        isGame = true;
        if (TouchController.Instance.canMove && isGame == true)
        {
            touchPosX = TouchController.Instance.touch.deltaPosition.x * Time.deltaTime * swipeSpeed;
            characterTr.localPosition += Vector3.up * touchPosX;
            anim.SetFloat("Horizontal",touchPosX);
            LevelBoundaries();
        }
    }
    /// <summary>
    /// Sağa ve sola gidebilme sınırı
    /// </summary>
    void LevelBoundaries()
    {
        Vector3 pos = characterTr.localPosition;
        pos.y = Mathf.Clamp(pos.y, min, max);
        characterTr.localPosition = pos;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacles"))
        {
            anim.enabled = false;
        }
    }

    public void Active(bool isActive)
    {
        enabled = isActive;
    }
}
