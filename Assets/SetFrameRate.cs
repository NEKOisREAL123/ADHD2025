using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetFrameRate : MonoBehaviour
{
    // 設置目標幀率
    public int targetFrameRate = 120;

    void Start()
    {
        // 設置應用程序的目標幀率
        Application.targetFrameRate = targetFrameRate;
    }

    void Update()
    {
        // 確保幀率設置在更新過程中持續生效
        if (Application.targetFrameRate != targetFrameRate)
        {
            Application.targetFrameRate = targetFrameRate;
        }
    }
}
