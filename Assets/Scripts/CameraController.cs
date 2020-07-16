using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// カメラにアタッチして使う。カメラを制御する機能を提供する。
/// </summary>
public class CameraController : MonoBehaviour
{
    public float m_shakeIntensity = .3f;
    public float m_shakeDecay = .3f;
    private Vector3 m_originPosition;
    private float decay;
    private float intensity;

    void Start()
    {
        m_originPosition = this.transform.position;
    }

    void Update()
    {
        if (intensity > 0)
        {
            transform.position = m_originPosition + Random.insideUnitSphere * intensity;
            intensity -= decay * Time.deltaTime;
            if (intensity <= 0)
                transform.position = m_originPosition;
        }
    }

    public void Shake()
    {
        if (intensity <= 0)
            m_originPosition = transform.position;

        intensity = m_shakeIntensity;
        decay = m_shakeDecay;
    }
}
