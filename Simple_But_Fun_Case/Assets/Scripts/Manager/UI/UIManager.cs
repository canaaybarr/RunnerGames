using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [Header("LevelProgress UI")]
    [SerializeField] int sceneOffset;
    [SerializeField] TMP_Text nextLevelText;
    [SerializeField] TMP_Text currentLevelText;
    public GameObject tounchToScreen;
    
    void Start()
    {
        tounchToScreen = GameObject.FindGameObjectWithTag("TounchToScreen");
        tounchToScreen.SetActive(true);
        SetLevelProgressText();
    }
    /// <summary>
    /// Progress bara kaçıncı levelde olduğunu otomatik yazdırma
    /// </summary>
    void SetLevelProgressText()
    {
        int level = SceneManager.GetActiveScene().buildIndex + sceneOffset;
        nextLevelText.text = (level + 1).ToString();
        currentLevelText.text = level.ToString();   
    }
    public void StartGame()
    {
        tounchToScreen.SetActive(false);
        Movement.Instance.isGame = true;
    }
}
