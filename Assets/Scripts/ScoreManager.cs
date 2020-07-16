using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;   // UI (Text) を操作するために追加している

public class ScoreManager : MonoBehaviour
{
    int m_score;
    public int BlockBreakCounter;
    /// <summary>スコアを表示する UI のテキスト</summary>
    GameObject m_scoreText;

    private void Start()
    {
        m_scoreText = GameObject.Find("ScoreText"); // スコアを表示するオブジェクト
    }

    /// <summary>
    /// スコアを加算する。public として関数を作ることにより、外部から呼び出せるようになる。
    /// </summary>
    public void AddScore(int score)
    {
        m_score += score;   // m_score = m_score + score の短縮形
        Debug.LogFormat("Score: {0}", m_score);

        // スコアを画面に表示する
        Text scoreText = m_scoreText.GetComponent<Text>();
        scoreText.text = "SCORE: " + m_score.ToString();
    }

    /// <summary>
    /// private（public とつけていない）関数は、外部からは呼び出せない。
    /// </summary>
    void Dummy()
    {
    }
}
