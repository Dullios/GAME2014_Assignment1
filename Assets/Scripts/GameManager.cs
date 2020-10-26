using System.Collections;
using System.Collections.Generic;
using TMPro;
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
 *      October 26, 2020
 * 
 * Description:
 *      A script to manage the scene transitions and UI functions of the game
 *      
 * Revision History:
 *      - Initial creation
 *      - Added ChangeScene and ExitGame methods
 *      - Added static score variable
 *      - GameManager instantiates an enemy wave once MainGame scene is started
 */

public class GameManager : MonoBehaviour
{
    private static int score;
    public static int Score
    {
        get
        {
            return score;
        }
        set
        {
            score = value;
            FindObjectOfType<HUDManager>().UpdateScore(score);
        }
    }

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

                // Reset game stats
                Score = 0;
                FindObjectOfType<HUDManager>().health = 2;

                EnemyManager enManage = FindObjectOfType<EnemyManager>();
                enManage.spawnBool = true;
                enManage.moveBool = true;
                break;
            case "GameOver":
                PlayMusic((AudioClip)Resources.Load("Audio/Map_Basic"));

                TextMeshProUGUI[] textArray = FindObjectsOfType<TextMeshProUGUI>();
                foreach(TextMeshProUGUI text in textArray)
                {
                    if (text.gameObject.tag == "Score")
                        text.text = GameManager.Score.ToString().PadLeft(5, '0');
                }

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
