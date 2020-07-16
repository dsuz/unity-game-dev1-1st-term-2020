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
    /// <summary>ボールの最大速度</summary>
    [SerializeField] float m_maxSpeed = 3f;
    /// <summary>スペースキーを押した時にボールを動かす力の大きさ</summary>
    [SerializeField] float m_shakePower = 5f;
    Rigidbody2D m_rb2d;

    void Start()
    {
        m_rb2d = GetComponent<Rigidbody2D>();
        // ボールを動かす
        Push();
    }

    void Update()
    {
        // ボールの速度を制限する
        if (m_rb2d.velocity.magnitude > m_maxSpeed)
        {
            m_rb2d.velocity = m_rb2d.velocity.normalized * m_maxSpeed;
        }

        // スペースキーを押すと、ランダムな方向に力を加える
        if (Input.GetButtonDown("Jump"))
        {
            float x = Random.Range(-1f, 1f);
            float y = Random.Range(-1f, 1f);
            Vector2 dir = Vector2.right * x + Vector2.up * y;
            dir = dir.normalized;
            m_rb2d.AddForce(dir * m_shakePower, ForceMode2D.Impulse);

            // カメラを揺らす
            CameraController camera = Camera.main.GetComponent<CameraController>(); // Camera.main でメインカメラの GameObject を取得できる
            camera.Shake();
        }
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