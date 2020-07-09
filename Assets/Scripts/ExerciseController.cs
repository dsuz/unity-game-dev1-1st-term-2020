using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExerciseController : MonoBehaviour
{
    GameObject m_object;

    void Start()
    {
        m_object = GameObject.Find("BlueLeftWall"); // 指定した名前のオブジェクト (GameObject) 検索して取得する
    }

    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Rigidbody2D rb = m_object.GetComponent<Rigidbody2D>();  // 取得したオブジェクトから Rigidbody2D コンポーネントを取り出す
        rb.AddForce(3 * Vector2.left, ForceMode2D.Impulse);     // 左に大きさ3の力を加える
    }
}
