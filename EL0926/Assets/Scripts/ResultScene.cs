using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultScene : MonoBehaviour
{
    public GameObject clear_root;
    public GameObject fail_root;

    // Start is called before the first frame update
    void Start()
    {
        var cleard = PlayerPrefs.GetInt("cleard", 0) > 1;
        clear_root.SetActive(cleard);
        fail_root.SetActive(!cleard);
    }


}
