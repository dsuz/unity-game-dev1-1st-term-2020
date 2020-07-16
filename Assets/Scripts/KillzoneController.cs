using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// トリガーにアタッチして使う。「ここにボールが当たったらゲームオーバーにする」機能を提供する。
/// </summary>
public class KillzoneController : MonoBehaviour
{
    /// <summary>Gameover を表示するオブジェクト</summary>
    GameObject m_gameoverText;

    void Start()
    {
        m_gameoverText = GameObject.Find("GameoverText");
        m_gameoverText.SetActive(false);    // 無効にして見えなくする
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "BallTag")
        {
            Destroy(collision.gameObject);
            m_gameoverText.SetActive(true); // 有効にする
        }
    }
}
