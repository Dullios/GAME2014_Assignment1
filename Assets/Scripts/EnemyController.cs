using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * File:
 *      EnemyController.cs
 * 
 * By:
 *      Russell Brabers - 101192571
 * 
 * Date Modified: 
 *      October 25, 2020
 * 
 * Description:
 *      A script to manage enemy game objects
 *      
 * Revision History:
 *      - Initial creation
 *      - Added FireBullet and OnHit methods
 */

public class EnemyController : MonoBehaviour
{
    public BulletManager bulletManager;

    public int maxHealth;
    public int health;

    // Start is called before the first frame update
    void Start()
    {
        bulletManager = FindObjectOfType<BulletManager>();
    }

    // Update is called once per frame
    void Update()
    {
        FireBullet();
    }

    private void FireBullet()
    {
        if (Time.frameCount % 120 == 0)
            bulletManager.GetBullet(BulletType.EnemyBullet, gameObject.transform.position);
    }

    /// <summary>
    /// Called by colliding object to reduce enemy health and destroy it
    /// </summary>
    public void OnHit()
    {
        health--;

        if (health == 0)
        {
            if(GameManager.dropPowerUp)
            {
                GameObject.Instantiate((GameObject)Resources.Load("powerupGreen"), gameObject.transform.position, new Quaternion(0, 0, 0, 0));
                GameManager.dropPowerUp = false;
            }

            health = maxHealth;
            gameObject.SetActive(false);
            GameManager.Score += 100;
        }
    }
}
