using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * File:
 *      BulletController.cs
 * 
 * By:
 *      Russell Brabers - 101192571
 * 
 * Date Modified: 
 *      October 25, 2020
 * 
 * Description:
 *      A script to control the movement and recyclying of bullet objects
 *      
 * Revision History:
 *      - Initial creation
 *      - Added CheckBounds method
 */

public class BulletController : MonoBehaviour
{
    public BulletManager bulletManager;

    public BulletType bulletType;
    public int speed;
    public float boundary;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(speed, 0.0f, 0.0f) * Time.deltaTime;

        CheckBounds();
    }

    private void CheckBounds()
    {
        if(transform.position.x > boundary || transform.position.x < -boundary)
        {
            switch(bulletType)
            {
                case BulletType.PlayerBullet:
                    bulletManager.ReturnBullet(bulletType, gameObject);
                    break;
                case BulletType.LaserBullet:
                    break;
                case BulletType.EnemyBullet:
                    bulletManager.ReturnBullet(bulletType, gameObject);
                    break;
            }
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        // TODO: check player and enemy collisions

        bulletManager.ReturnBullet(bulletType, gameObject);
    }
}
