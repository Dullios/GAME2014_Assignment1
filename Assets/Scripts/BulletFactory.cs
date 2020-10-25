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
 *      - 
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

    //public GameObject createBullet()
    //{

    //}
}
