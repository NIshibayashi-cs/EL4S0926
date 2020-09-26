using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SimpleFadeIn : MonoBehaviour {

    public float duration;
    Image image;

    [SerializeField]
    bool fadeIn = true;

    [SerializeField]
    bool autoStart = false;

    [SerializeField]
    bool disableInput = false;

    void Start () {
        image = GetComponent<Image>();
        image.color = Color.black;
        if (autoStart) StartFade();
    }

    public void StartFade()
    {
        StartCoroutine(Fade());
    }

    IEnumerator Fade()
    {
        image.raycastTarget = disableInput;

        var start = fadeIn ? 1 : 0;
        var dir = fadeIn ? -1 : 1;
        var base_color = image.color;
        base_color.a = start;

        var start_time = Time.time;
        while(Time.time <= start_time + duration)
        {
            base_color.a = start + (Time.time - start_time) * dir / duration;
            image.color = base_color;
            yield return null;
        }
        base_color.a = fadeIn ? 0 : 1;
        image.color = base_color;
        if(disableInput && fadeIn) image.raycastTarget = false;
    }
}
