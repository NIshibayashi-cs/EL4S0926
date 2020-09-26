using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundController : MonoBehaviour
{
    // BGM clip
    AudioSource m_audio_source;

    private static SoundController m_instance = null;
    public static SoundController instance
    {
        get
        {
            if (m_instance == null)
            {
                m_instance = FindObjectOfType<SoundController>();
                if(m_instance == null)
                {
                    GameObject obj = Resources.Load("Prefabs/SoundController") as GameObject ;
                    m_instance = GameObject.Instantiate(obj).GetComponent<SoundController>();
                }
            }
            return m_instance;
        }
    }


    void Awake()
    {
        if(m_instance == null)
        {
            m_instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    void Start()
    {
        m_audio_source = GetComponent<AudioSource>();
        m_audio_source.loop = true;

        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // BGMの停止
    public void Stop_BGM()
    {
        m_audio_source.Stop();
    }

    // BGMの再生
    public void Play_BGM()
    {
        if (m_audio_source == null)
            m_audio_source = GetComponent<AudioSource>();
        m_audio_source.Play();
    }
}
