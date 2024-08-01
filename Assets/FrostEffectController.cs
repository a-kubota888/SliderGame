using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrostEffectController : MonoBehaviour
{
    private FrostEffect frostEffect;　　　// Frost スクリプトを代入して操作するための変数

    private float currentFrostValue;　　　// FrostAmount の値とリンクさせるための変数

    void Start()
    {
        // 同じゲームオブジェクトにアタッチされている FrostEffect スクリプトを取得して代入
        frostEffect = GetComponent<FrostEffect>();

        // 霜エフェクトの初期化(霜のエフェクトが画面に見えない状態にする)
        InitialFrostAmount();
    }

    void Update()
    {
        // currentFrostValue の値が 0 以上の時　=>　つまり、霜のエフェクトで画面がおおわれているとき
        if (currentFrostValue > 0)
        {

            // 値を操作して、画面を少しずつ見えるようにする
            currentFrostValue -= Time.deltaTime / 20;

            // 操作した値で FrostAmount の値を更新する　=>　この処理があることで霜のエフェクトが徐々に薄くなって消えていく
            UpdateFrostAmount(0);

            // currentFrostValue の値が 0 以下になった時　=>　霜のエフェクトをなくしてよい状態になったら
            if (currentFrostValue <= 0)
            {

                // 次の霜のエフェクト発生に備えて、FrostAmountの値を 0 に戻して初期化しておく
                InitialFrostAmount();
            }
        }
    }

    /// <summary>
    /// FrostEffectの FrostAmount の値を更新
    /// </summary>
    /// <param name="amount"></param>
    public void UpdateFrostAmount(float amount)
    {
        currentFrostValue += amount;
        frostEffect.FrostAmount = currentFrostValue;
    }

    /// <summary>
    /// FrostEffectの FrostAmount の値の初期化
    /// </summary>
    public void InitialFrostAmount()
    {
        currentFrostValue = 0;
        frostEffect.FrostAmount = currentFrostValue;
    }
}