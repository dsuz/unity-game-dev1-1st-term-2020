using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// パドルを制御するコンポーネント。パドルのオブジェクトに追加して使う。
/// </summary>
[RequireComponent(typeof(Rigidbody2D))]
public class PaddleController : MonoBehaviour
{
    /// <summary>パドルの移動速度</summary>
    [SerializeField] float m_speed = 5f;
    Rigidbody2D m_rb2d;

    void Start()
    {
        m_rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // 水平方向の入力を検出する
        float h = Input.GetAxisRaw("Horizontal");
        // 入力に応じてパドルを水平方向に動かす
        m_rb2d.velocity = h * Vector2.right * m_speed;
    }
}