using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ターゲットブロック（ボールが当たったら壊れるブロック）を制御する
/// ターゲットブロックの GameObject に追加して使う
/// </summary>
public class TargetBlockController : MonoBehaviour
{
    /// <summary>ブロックを壊した時の得点</summary>
    int m_score = 3;
    /// <summary>スコアマネージャー</summary>
    GameObject m_scoreManager;

    void Start()
    {
        m_scoreManager = GameObject.Find("GameManager");    // GameManager を探して取ってくる
    }

    void Update()
    {

    }

    /// <summary>
    /// Collider に衝突判定があった時に呼ばれる
    /// </summary>
    /// <param name="collision">衝突の情報</param>
    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Enter OnCollisionEnter2D."); // 関数が呼び出されたら Console にログを出力する

        // 衝突相手がボールだったら得点を追加し、自分自身を破棄する
        if (collision.gameObject.tag == "BallTag")
        {
            if (m_scoreManager != null)
            {
                ScoreManager sm = m_scoreManager.GetComponent<ScoreManager>();
                sm.AddScore(m_score);
                sm.BlockBreakCounter += 1;
            }
            Destroy(this.gameObject);
        }
    }

    /// <summary>
    /// Collider に接触判定（トリガーモード時）があった時に呼ばれる
    /// </summary>
    /// <param name="collision">衝突の情報</param>
    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Enter OnTriggerEnter2D."); // 関数が呼び出されたら Console にログを出力する

        // 衝突相手がボールだったら得点を追加し、自分自身を破棄する
        if (collision.gameObject.tag == "BallTag")
        {
            if (m_scoreManager != null)
            {
                ScoreManager sm = m_scoreManager.GetComponent<ScoreManager>();
                sm.AddScore(m_score);
                sm.BlockBreakCounter += 1;
            }
            Destroy(this.gameObject);
        }
    }
}
