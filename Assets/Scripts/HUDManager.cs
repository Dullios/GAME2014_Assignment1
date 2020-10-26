using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

/*
 * File:
 *      HUDManager.cs
 * 
 * By:
 *      Russell Brabers - 101192571
 * 
 * Date Modified: 
 *      October 26, 2020
 * 
 * Description:
 *      A class to manage the HUD elements of the game
 *      
 * Revision History:
 *      - Initial creation
 *      - Added methods to update the score and health UI
 */

public class HUDManager : MonoBehaviour
{
    public GameObject scoreText;
    public GameObject[] healthBars = new GameObject[3];
    public int health;

    // Start is called before the first frame update
    void Start()
    {
        health = 2;
    }

    /// <summary>
    /// Method to update the score UI with a given score
    /// </summary>
    /// <param name="score"></param>
    public void UpdateScore(int score)
    {
        string text = score.ToString().PadLeft(5, '0');
        scoreText.GetComponent<TextMeshProUGUI>().text = text;
    }
    
    /// <summary>
    /// Method to update health UI
    /// </summary>
    public void UpdateHealth()
    {
        healthBars[health].gameObject.SetActive(false);
        health--;
        if (health < 0)
            FindObjectOfType<GameManager>().ChangeScene(3);
    }
}
