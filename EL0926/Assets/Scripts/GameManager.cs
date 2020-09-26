using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    GameObject clear_VFX;

    [SerializeField]
    GameObject failed_VFX;

    [SerializeField]
    SimpleFadeIn fade;

    bool clicked = false;

    void Update()
    {
        if (!clicked && Input.GetMouseButtonDown(0))
        {
            //先生をクリックしたかチェック
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            var hit = Physics2D.Raycast(ray.origin, ray.direction);
            if (hit.collider == null) return;
            var script = hit.collider.gameObject.GetComponent<Sensei>();
            if (script == null) return;

            //ニッチかどうか判定
            Debug.Log("ID:" + script.Type + " clicked. =>" + script.ToString());

            bool clear = GetNicheID() == script.Type;

            //フラグセットしてResultへ
            PlayerPrefs.SetInt("GameClear", clear ? 1 : 0);
            GameObject vfx = Instantiate(clear ? clear_VFX : failed_VFX);
            vfx.transform.position = hit.transform.position;
            clicked = true;
            Invoke("FadeOut", 0.5f);
            Invoke("GoToResult", 1.5f);
        }
    }

    void FadeOut()
    {
        fade.fadeIn = false;
        fade.StartFade();
    }

    void GoToResult()
    {
        SceneManager.LoadScene("ResultScene");
    }

    public int GetNicheID()
    {
        //int type_count = System.Enum.GetValues(typeof(TempType)).Length;
        int type_count = 5; //決め打ち!ｗ
        int[] counts = new int[type_count];

        //Type毎の数をカウント
        foreach (GameObject target in Object.FindObjectsOfType(typeof(GameObject)))
        {
            var script = target.GetComponent<Sensei>();
            if (script == null) continue;
            counts[script.Type]++; 
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
        Debug.Log("ID:" + nicheID + " is niche!!");
        return nicheID;
    }
}
