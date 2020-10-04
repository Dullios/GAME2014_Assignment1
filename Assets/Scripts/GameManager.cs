using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * File:
 *      GameManager.cs
 * 
 * By:
 *      Russell Brabers - 101192571
 * 
 * Date Modified: 
 *      October 3, 2020
 * 
 * Description:
 *      A script to manage the scene transitions and other miscellaneous functions of the game
 *      
 * Revision History:
 *      - Initial creation
 *      - Added ChangeScene method
 *      - Added ExitGame method
 */

public class GameManager : MonoBehaviour
{
    public AudioSource backgroundMusic;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeScene(int i)
    {
        SceneManager.LoadScene(i);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
