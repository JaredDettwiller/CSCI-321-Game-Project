using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMusicController : MonoBehaviour
{
    public AudioClip finalBossMusic;
    public AudioClip victorious;
    public AudioClip castleLevelTheme;
    public AudioClip caveLevelTheme;
    public AudioClip overworldTheme;
    private FinalBattle finalBattle;
    private AudioSource speaker;
    private Scene lastSceneLoaded;
    private SceneController sceneController;

    void Start()
    {
        speaker = GetComponent<AudioSource>();
        sceneController = GameObject.Find("SceneController").GetComponent<SceneController>();
        sceneController.getActiveScene();
    }

    void Update()
    {
        if(sceneController.getActiveScene() != lastSceneLoaded)
        {
            lastSceneLoaded = sceneController.getActiveScene();
            string cs = lastSceneLoaded.name;
            switch(cs)
            {
                case "Level1-Cave":
                    speaker.clip = caveLevelTheme;
                    speaker.volume = 1f;
                    speaker.loop = true;
                    break;

                case "Lich's Castle":
                    speaker.clip = castleLevelTheme;
                    speaker.volume = 1f;
                    speaker.loop = true;
                    break;

                default:
                    speaker.clip = overworldTheme;
                    speaker.volume = 0.5f;
                    speaker.loop = true;
                    break;
            }
            speaker.Play();
        }
        
    }

    public void finalBattleMusic()
    {
        speaker.clip = finalBossMusic;
        speaker.loop = true;
        speaker.Play();
    }

    public void victory()
    {
        speaker.clip = victorious;
        speaker.loop = false;
        speaker.volume = 0.6f;
        speaker.Play();
    }
}
