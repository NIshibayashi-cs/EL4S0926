using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TypeCheck : MonoBehaviour
{
    public enum TempType
    { //コーディング用の仮置き。先生オブジェクト側のenumを使う。
        Akiyama,
        Takahashi,
        Murase
    }

    public TempType GetNiche(List<GameObject> objects)
    {
        int type_count = System.Enum.GetValues(typeof(TempType)).Length;
        int[] counts = new int[type_count];

        //Type毎の数をカウント
        foreach (var target in objects)
        {
            var type = TempType.Akiyama; //Todo:先生オブジェクトからTypeを抽出する
            counts[(int)type]++;
        }

        //ニッチ(一番数が少ないType)を探す
        TempType nicheType = TempType.Akiyama;
        var nicheCount = counts[0];
        for (int i = 1; i < type_count; i++)
        {
            if (counts[i] >= nicheCount) continue;
            nicheCount = counts[i];
            nicheType = (TempType)System.Enum.ToObject(typeof(TempType), i);
        }

        return nicheType;
    }

}
