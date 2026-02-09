using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class GameOverScene : MonoBehaviour
{
    public TMP_Text ScoreText;

    public CardsController cardsController;
    public void Setup(int score)
    {
        gameObject.SetActive(true);
        ScoreText.text = score.ToString() + " SCORE";
    }
    public void restartbutton()
    {
        SceneManager.LoadScene("Gameplay");
    }
    public void Exitbutton()
    {
        SceneManager.LoadScene("Menu");
    }
}
