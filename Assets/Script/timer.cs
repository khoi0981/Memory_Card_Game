using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;

public class timer : MonoBehaviour
{
    [SerializeField] TMP_Text timerText;
    [SerializeField] GameObject panel;
    [SerializeField] UnityEngine.UI.Image timeImage;
    [SerializeField] float duration, currentTime;
    [SerializeField] CardsController cardsController;

    private void Start()
    {
        panel.SetActive(false);
        currentTime = duration;
        timerText.text = currentTime.ToString();
        StartCoroutine(TimeIEn());
    }

    IEnumerator TimeIEn()
    {
        while (currentTime > 0)
        {
            timeImage.fillAmount = Mathf.InverseLerp(0, duration, currentTime);
            timerText.text = ((int)currentTime).ToString();
            yield return new WaitForSeconds(1f);
            currentTime -= 1f;

        }
        OpenPanel();
    }

    void OpenPanel()
    {
        timerText.text = "0";
        panel.SetActive(true);
        cardsController.GameOver();
    }

    public void ResetTimer()
    {
        currentTime = duration;

        if (timeImage != null) timeImage.fillAmount = 1f;
        if (timerText != null) timerText.text = ((int)currentTime).ToString();
    }
}
