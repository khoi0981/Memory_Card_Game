using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class Menu_controller : MonoBehaviour
{
    public void onstartclick()
    {
        SceneManager.LoadScene("Gameplay");
    }
    public void onLV1startclick()
    {
        SceneManager.LoadScene("LV1");
    }public void onLV2startclick()
    {
        SceneManager.LoadScene("LV2");
    }public void onLV3startclick()
    {
        SceneManager.LoadScene("LV3");
    }
    public void onexitclick()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }
}
