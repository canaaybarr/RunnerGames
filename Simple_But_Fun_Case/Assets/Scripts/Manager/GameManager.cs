using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    #region Singleton class : GameManager
    public static GameManager Instance;
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
    
    public int vibrateMilisc;
    public GameObject vibratePanelOff;
    public GameObject vibratePanelOn;
    public GameObject winPanel;
    
    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }
    
    public void Pause()
    {
        Time.timeScale = 0;
    }
    public void Resume()
    {
        Time.timeScale = 1;
    }
    public void WinPanel()
    {
        winPanel.SetActive(true);
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        
    }
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
        
    }
    public void Play()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        
    }
    public void QuitGame()
    {
        Application.Quit();
        
    }
    public void VibrateOff()
    {
        vibrateMilisc = 0;
        vibratePanelOff.SetActive(false);
        vibratePanelOn.SetActive(true);
    }
    public void VibrateOn()
    {
        vibrateMilisc = 100;
        vibratePanelOn.SetActive(false);
        vibratePanelOff.SetActive(true);
    }
    public IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.3f);
        Restart();
    }
    
}
