
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowController : MonoBehaviour
{
    GameObject player;

    void Start()
    {
        this.player = GameObject.Find("penguin");
    }

    void Update()
    {
        // フレームごとに等速で落下させる
        transform.Translate(0, -0.1f, 0);

        // 画面外に出たらオブジェクトを破棄する
        if (transform.position.y < -5.0f)
        {
            Destroy(gameObject);
        }

        // 当たり判定
        Vector2 p1 = transform.position;             // 矢の中心座標
        Vector2 p2 = this.player.transform.position; // プレイヤの中心座標
        Vector2 dir = p1 - p2;
        float d = dir.magnitude;
        float r1 = 0.5f; // 矢の半径
        float r2 = 1.0f; // プレイヤの半径 
    }
}
