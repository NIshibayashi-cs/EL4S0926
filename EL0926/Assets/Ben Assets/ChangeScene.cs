using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    enum Scenes
    {
        Title,
        Game,
        Result,
    }

    [SerializeField]
    Scenes nextScene;

    void GoToScene()
    {
        SceneManager.LoadScene((int)nextScene);
    }

    void Update()
    {
        //Test
        if (Input.GetKeyDown(KeyCode.T))
        {
            GoToScene();
        }
    }
}
