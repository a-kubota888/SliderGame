using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class RotateObject : MonoBehaviour
{
    [Header("回転する時間")]
    public float duration;

    private bool isRotate = false;        // 回転しているか、まだしていないかの状態を設定するための値。false ならまだ回転していない、true なら回転して転倒している

    private void OnTriggerEnter(Collider col)
    {

        // キャラが一定の距離に入ったとき、まだ回転して転倒していない状態でないなら
        if (col.gameObject.tag == "Player" && isRotate == false)
        {

            // 木を回転させて倒す
            Rotate();

            // 回転して転倒した状態にする
            isRotate = true;
        }
    }

    /// <summary>
    /// 木を回転させる
    /// </summary>
    private void Rotate()
    {

        // Z 軸のみ duration 分の時間をかけて回転。回転角度は RandomAngle メソッドの戻り値を利用して、ランダムに左右に倒れるようにする
        transform.DORotate(new Vector3(0, 0, RandomAngle()), duration);
    }

    /// <summary>
    /// 木の回転角度をランダムに設定(float 型の戻り値があるので、処理が終了すると float 型の値を処理元に戻す)
    /// </summary>
    /// <returns></returns>
    private float RandomAngle()
    {

        // ランダムな値を取得して value に代入(Random.Range() メソッドも戻り値があります)
        int value = Random.Range(0, 2);

        // value の値が 0 の場合
        if (value == 0)
        {

            // 70.0f を呼び出し元に戻す
            return 70.0f;
        }
        // value の値が 1 の場合
        else
        {
            // -70.0f を呼び出し元に戻す
            return -70.0f;
        }
    }
}
