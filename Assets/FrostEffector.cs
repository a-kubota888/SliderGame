using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrostEffector : MonoBehaviour
{
    private float duration = 0.3f;         // 霜のエフェクトの FrostAmount の値の加算値

    private bool isApplyEffected;　　　　　// １回だけ霜のエフェクトを発生させるための接触判定の制御用の判定値。false なら未接触。true なら接触済。

    private void OnCollisionEnter(Collision col)
    {

        // Player タグを持つゲームオブジェクト(ペンギン)と接触した際に、まだ１回も接触判定を行っていない(isApplyEffected の値が false である)場合
        if (col.gameObject.tag == "Player" && isApplyEffected == false)
        {

            // 何回も接触することを想定し、１回だけ霜のエフェクトを発生させるように条件を制御する
            isApplyEffected = true;

            // Main Camera タグのついているゲームオブジェクトをヒエラルキーから探して、そのゲームオブジェクトにアタッチされている FrostEffectController スクリプトの情報を取得し、
            // FrostEffectController スクリプト内にある UpdateFrostAmount メソッドを呼び出す命令を行う。引数として duration 変数の値を渡す
            Camera.main.gameObject.GetComponent<FrostEffectController>().UpdateFrostAmount(duration);

            // このゲームオブジェクトを破棄する　=>　ゲーム画面に残しておきたい場合には、この部分はコメントアウトか削除する
            Destroy(gameObject, 0.5f);
        }
    }
}