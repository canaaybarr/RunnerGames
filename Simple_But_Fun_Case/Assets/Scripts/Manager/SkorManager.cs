using UnityEngine;
using TMPro;

public class SkorManager : MonoBehaviour
{
    [Header("TotalSkor")] 
    public int moneyScore = 0;
    public TMP_Text ScoreText;
    public TMP_Text WinScoreText;

    
    void Update()
    {
        if (Movement.Instance.isGame == true)
        {
            moneyScore = Stack.Instance.objects.Count + -1;
            ScoreText.text = moneyScore + " =";
            WinScoreText.text = moneyScore + " =";
            if (moneyScore == 0 || moneyScore <= 0)
            {
                moneyScore = 0;
            }
        }
    }
}
