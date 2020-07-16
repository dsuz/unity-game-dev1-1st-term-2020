using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerController : MonoBehaviour
{
    public float m_interval = 3.0f;
    float m_timer;
    void Start()
    {
        m_timer = m_interval;
    }

    void Update()
    {
        m_timer += Time.deltaTime;
        
        if (Input.GetMouseButtonDown(0))
        {
            if (m_timer > m_interval)
            {
                m_timer = 0;
                Debug.Log("右クリックが押された。");
            }
            else
            {
                Debug.LogFormat("まだ {0} 秒経過していません。{1} 秒経過しています。", m_interval, m_timer.ToString("f2"));
            }
        }
    }
}
