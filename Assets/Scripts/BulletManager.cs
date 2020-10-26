using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * File:
 *      BulletManager.cs
 * 
 * By:
 *      Russell Brabers - 101192571
 * 
 * Date Modified: 
 *      October 25, 2020
 * 
 * Description:
 *      A script to manage bullet game objects
 *      
 * Revision History:
 *      - Initial creation
 *      - Added BulletType enum
 *      - Added GetBullet and ReturnBullet methods
 */

[System.Serializable]
public enum BulletType
{
    PlayerBullet,
    LaserBullet,
    EnemyBullet
}


public class BulletManager : MonoBehaviour
{
    // Bullet parent objects
    public GameObject playerAmmo;
    public GameObject enemyAmmo;

    public int maxBullets;

    private Queue<GameObject> playerBulletPool;
    private Queue<GameObject> enemyBulletPool;

    // Start is called before the first frame update
    void Start()
    {
        BuildBulletPool();
    }

    private void BuildBulletPool()
    {
        playerBulletPool = new Queue<GameObject>();
        enemyBulletPool = new Queue<GameObject>();

        for(int i = 0; i < maxBullets; i++)
        {
            var tempPlayBullet = BulletFactory.Instance().createBullet(BulletType.PlayerBullet, playerAmmo.transform);
            tempPlayBullet.GetComponent<BulletController>().bulletType = BulletType.PlayerBullet;
            tempPlayBullet.GetComponent<BulletController>().bulletManager = this;
            tempPlayBullet.SetActive(false);
            playerBulletPool.Enqueue(tempPlayBullet);

            var tempNmeBullet = BulletFactory.Instance().createBullet(BulletType.EnemyBullet, enemyAmmo.transform);
            tempNmeBullet.GetComponent<BulletController>().bulletType = BulletType.EnemyBullet;
            tempNmeBullet.GetComponent<BulletController>().bulletManager = this;
            tempNmeBullet.SetActive(false);
            enemyBulletPool.Enqueue(tempNmeBullet);
        }
    }

    public GameObject GetBullet(BulletType type, Vector3 position)
    {
        GameObject newBullet = null;

        switch(type)
        {
            case BulletType.PlayerBullet:
                newBullet = playerBulletPool.Dequeue();
                break;
            case BulletType.LaserBullet:
                break;
            case BulletType.EnemyBullet:
                newBullet = enemyBulletPool.Dequeue();
                break;
        }

        newBullet.SetActive(true);
        newBullet.transform.position = position;
        return newBullet;
    }

    public void ReturnBullet(BulletType type, GameObject returnedBullet)
    {
        returnedBullet.SetActive(false);

        switch (type)
        {
            case BulletType.PlayerBullet:
                playerBulletPool.Enqueue(returnedBullet);
                break;
            case BulletType.LaserBullet:
                break;
            case BulletType.EnemyBullet:
                enemyBulletPool.Enqueue(returnedBullet);
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
