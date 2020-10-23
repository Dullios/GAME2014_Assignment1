using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/*
 * File:
 *      GameManager.cs
 * 
 * By:
 *      Russell Brabers - 101192571
 * 
 * Date Modified: 
 *      October 23, 2020
 * 
 * Description:
 *      A script to manage the scene transitions and other miscellaneous functions of the game
 *      
 * Revision History:
 *      - Initial creation
 *      - Added ChangeScene and ExitGame methods
 */

public class GameManager : MonoBehaviour
{
    public AudioSource backgroundMusic;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        SceneManager.sceneLoaded += OnSceneChange;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// Function to change scene to a given build index
    /// </summary>
    /// <param name="i"></param>
    public void ChangeScene(int i)
    {
        SceneManager.LoadScene(i);
    }

    public void OnSceneChange(Scene scene, LoadSceneMode mode)
    {
        switch (scene.name)
        {
            case "TitleScene":
                PlayMusic((AudioClip)Resources.Load("Audio/Venus"));
                break;
            case "Instructions":
                PlayMusic((AudioClip)Resources.Load("Audio/Map"));
                FindObjectOfType<Button>().onClick.AddListener(delegate { ChangeScene(0); });
                break;
            case "MainGame":
                PlayMusic((AudioClip)Resources.Load("Audio/Mercury"));
                FindObjectOfType<Button>().onClick.AddListener(delegate { ChangeScene(3); });
                break;
            case "GameOver":
                PlayMusic((AudioClip)Resources.Load("Audio/Map_Basic"));

                Button[] sceneButtons = FindObjectsOfType<Button>();
                foreach(Button b in sceneButtons)
                {
                    if (b.gameObject.name == "Restart Button")
                        b.onClick.AddListener(delegate { ChangeScene(2); });
                    else if (b.gameObject.name == "Title Button")
                        b.onClick.AddListener(delegate { ChangeScene(0); });
                }
                break;
        }
    }

    public void PlayMusic(AudioClip clip)
    {
        backgroundMusic.clip = clip;
        backgroundMusic.Play();
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
