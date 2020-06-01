using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ボールを制御するコンポーネント。ボールのオブジェクトに追加して使う。
/// </summary>
[RequireComponent(typeof(Rigidbody2D))]
public class BallController : MonoBehaviour
{
    /// <summary>ボールが最初に動く方向</summary>
    [SerializeField] Vector2 m_powerDirection = Vector2.up + Vector2.right;
    /// <summary>ボールを最初に動かす力の大きさ</summary>
    [SerializeField] float m_powerScale = 5f;
    Rigidbody2D m_rb2d;

    void Start()
    {
        m_rb2d = GetComponent<Rigidbody2D>();
        // ボールを動かす
        Push();
    }

    void Update()
    {

    }

    /// <summary>
    /// ボールに力を加える
    /// </summary>
    public void Push()
    {
        m_rb2d.AddForce(m_powerDirection.normalized * m_powerScale, ForceMode2D.Impulse);
    }
}