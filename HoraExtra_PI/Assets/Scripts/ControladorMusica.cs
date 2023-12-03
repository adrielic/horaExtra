using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControladorMusica : MonoBehaviour
{
    private static ControladorMusica instancia;

    public AudioSource musicaAudioSrc;

    private void Awake()
    {
        if (instancia == null)
        {
            instancia = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene cena, LoadSceneMode modo)
    {
        if (cena.name.Contains("Cena"))
        {
            TocarMusica();
        }
        else
        {
            PararMusica(); 
        }
    }

    private void TocarMusica()
    {
        if (musicaAudioSrc != null && !musicaAudioSrc.isPlaying)
        {
            musicaAudioSrc.Play();
        }
    }

    private void PararMusica()
    {
        if (musicaAudioSrc != null && musicaAudioSrc.isPlaying)
        {
            musicaAudioSrc.Stop();
        }
    }
}
