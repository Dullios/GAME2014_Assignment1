using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * File:
 *      PowerUpController.cs
 * 
 * By:
 *      Russell Brabers - 101192571
 * 
 * Date Modified: 
 *      October 26, 2020
 * 
 * Description:
 *      A class to manage power up movement and triggers
 *      
 * Revision History:
 *      - Initial creation
 *      - Added a line in Update and CheckBounds method
 *      - Added OnTriggerEnter2D method
 */

public class PowerUpController : MonoBehaviour
{
    public int speed;
    public float boundary;

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(speed, 0.0f, 0.0f) * Time.deltaTime;

        CheckBounds();
    }

    private void CheckBounds()
    {
        if(transform.position.x <= boundary)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            FindObjectOfType<HUDManager>().IncreaseHealth();
            Destroy(gameObject);
        }
    }
}
