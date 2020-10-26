using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * File:
 *      BulletFactory.cs
 * 
 * By:
 *      Russell Brabers - 101192571
 * 
 * Date Modified: 
 *      October 25, 2020
 * 
 * Description:
 *      A singleton class to create bullet game objets
 *      
 * Revision History:
 *      - Initial creation
 *      - Added CreateBullet method
 */

public class BulletFactory
{
    private static BulletFactory instance;
    private BulletFactory()
    {
        Init();
    }

    public static BulletFactory Instance()
    {
        if (instance == null)
            instance = new BulletFactory();

        return instance;
    }

    // Bullet prefabs
    private GameObject playerBullet;
    private GameObject enemyBullet;

    private void Init()
    {
        playerBullet = (GameObject)Resources.Load("Player_Bullet");
        enemyBullet = (GameObject)Resources.Load("Enemy_Bullet");
    }

    /// <summary>
    /// Instantiates a bullet object of BulletType attached to a parent game object
    /// </summary>
    /// <param name="type"></param>
    /// <param name="parent"></param>
    /// <returns></returns>
    public GameObject CreateBullet(BulletType type, Transform parent)
    {
        GameObject tempBullet = null;

        switch(type)
        {
            case BulletType.PlayerBullet:
                tempBullet = GameObject.Instantiate(playerBullet);
                tempBullet.transform.parent = parent;
                break;
            case BulletType.LaserBullet:

                break;
            case BulletType.EnemyBullet:
                tempBullet = GameObject.Instantiate(enemyBullet);
                tempBullet.transform.parent = parent;
                break;
        }

        return tempBullet;
    }
}
