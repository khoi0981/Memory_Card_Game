using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BGM_Manager : MonoBehaviour
{
    private static BGM_Manager BGM_manage;

    void awake()
    {
        if (BGM_manage == null)
        {
            BGM_manage = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}
