﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public enum TempType
    { 
        Akiyama,
        Takahashi,
        Murase
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //先生をクリックしたかチェック
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            var hit = Physics2D.Raycast(ray.origin, ray.direction);
            if (hit.collider == null) return;
            var script = hit.collider.gameObject.GetComponent<Sensei>();
            if (script == null) return;

            //ニッチかどうか判定
            Debug.Log(script.ToString());

            bool clear = false;

            //フラグセットしてResultへ
            PlayerPrefs.SetInt("GameClear", clear ? 1 : 0);
            SceneManager.LoadScene("ResultScene");
        }
    }

    public int GetNicheID(List<GameObject> objects)
    {
        //int type_count = System.Enum.GetValues(typeof(TempType)).Length;
        int type_count = 4; //決め打ち!ｗ
        int[] counts = new int[type_count];

        //Type毎の数をカウント
        foreach (GameObject target in Object.FindObjectsOfType(typeof(GameObject)))
        {
            var script = target.GetComponent<Sensei>();
            if (script == null) continue;
            var type = TempType.Akiyama; //Todo:先生オブジェクトからTypeを抽出する
            counts[(int)type]++;
        }

        //ニッチ(一番数が少ないType)を探す
        int nicheID = 0;
        var nicheCount = counts[0];
        for (int i = 1; i < type_count; i++)
        {
            if (counts[i] >= nicheCount) continue;
            nicheCount = counts[i];
            nicheID = i;
        }

        return nicheID;
    }
}
