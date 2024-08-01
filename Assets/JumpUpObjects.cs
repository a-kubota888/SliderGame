using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;      //DOTweenの機能を利用する場合には追加します

public class JumpUpObject : MonoBehaviour
{
    private float startHeight;           // キャラのスタート位置の高さ
    private float hideHeight = 2.5f;     // キャラを隠すための高さの度合

    void Start()
    {
        // 隠す
        Hide();
    }

    /// <summary>
    /// ゲームオブジェクトを隠す
    /// </summary>
    private void Hide()
    {

        // ゲーム開始前の設置位置を記録しておく
        startHeight = transform.position.y;

        // オブジェクトの高さ(Y軸)を変更して斜面の中に隠れるようにする
        transform.position = new Vector3(transform.position.x, transform.position.y - hideHeight, transform.position.z);
    }

    private void OnTriggerEnter(Collider col)
    {
        // キャラが一定の距離に入ったら顔を出す
        if (col.gameObject.tag == "Player")
        {

            Debug.Log(col.gameObject.tag);

            // TODO 
            HeadUp();
        }
    }

    /// <summary>
    /// 顔を出す
    /// </summary>
    private void HeadUp()
    {

        transform.DOMoveY(startHeight, 0.25f);
    }

}