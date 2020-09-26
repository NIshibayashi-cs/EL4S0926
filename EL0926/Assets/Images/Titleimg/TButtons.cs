using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TButtons : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onClickStart()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void onClickEnd()
    {
        //UnityEditor.EditorApplication.isPlaying = false;
        UnityEngine.Application.Quit();
    }
}
