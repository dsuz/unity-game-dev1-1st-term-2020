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

    /// <summary>
    /// ボールがコライダーに衝突した時に呼ばれる関数
    /// </summary>
    /// <param name="collision">衝突情報</param>
    private void OnCollisionEnter2D(Collision2D collision)
    {
        AudioSource audio = this.gameObject.GetComponent<AudioSource>();    // この GameObject から AudioSource コンポーネントを取ってくる
        if (audio != null)  // コンポーネントが取れたら
        {
            audio.Play();   // AudioSource コンポーネントの AudioClip プロパティにアサインされている音を鳴らす
        }
    }

    /// <summary>
    /// ボールがトリガーに接触した時に呼ばれる関数
    /// </summary>
    /// <param name="collision">接触情報</param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // OnCollisionEnter2D と同じの処理をする
        AudioSource audio = this.gameObject.GetComponent<AudioSource>();
        if (audio != null)
        {
            audio.Play();
        }
    }
}