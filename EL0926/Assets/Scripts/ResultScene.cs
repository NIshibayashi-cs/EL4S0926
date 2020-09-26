using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResultScene : MonoBehaviour
{
    public GameObject clear_root;
    public GameObject fail_root;
    public SimpleFadeIn fade;

    // Start is called before the first frame update
    void Start()
    {
        var cleard = PlayerPrefs.GetInt("GameClear", 0) > 0;
        clear_root.SetActive(cleard);
        fail_root.SetActive(!cleard);
    }


    bool inputGuard = false;

    public void OnTitleButtunClicked()
    {
        if (inputGuard) return;
        inputGuard = true;
        var fade_duration = 1.0f;
        fade.fadeIn = false;
        fade.duration = fade_duration;
        fade.disableInput = true;
        fade.StartFade();
        Invoke("BackToTitle", fade_duration);
    }


    void BackToTitle()
    {
        SceneManager.LoadScene("TitleScene");
    }
}
