using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * File:
 *      EnemyFactory.cs
 * 
 * By:
 *      Russell Brabers - 101192571
 * 
 * Date Modified: 
 *      October 25, 2020
 * 
 * Description:
 *      A singleton class to create enemy game objets
 *      
 * Revision History:
 *      - Initial creation
 *      - Added CreateEnemy method
 */

public class EnemyFactory
{
    private static EnemyFactory instance;
    private EnemyFactory()
    {
        Init();
    }

    public static EnemyFactory Instance()
    {
        if (instance == null)
            instance = new EnemyFactory();

        return instance;
    }

    // Enemy prefabs
    private GameObject enemy1;
    private GameObject enemy2;
    private GameObject enemy3;

    private void Init()
    {
        enemy1 = (GameObject)Resources.Load("Enemy_1");
        enemy2 = (GameObject)Resources.Load("Enemy_2");
        enemy3 = (GameObject)Resources.Load("Enemy_3");
    }

    /// <summary>
    /// Instantiates an enemy object of EnemyType attached to a parent game object
    /// </summary>
    /// <param name="type"></param>
    /// <param name="parent"></param>
    /// <returns></returns>
    public GameObject CreateEnemy(EnemyType type, Transform parent)
    {
        GameObject tempEnemy = null;

        switch (type)
        {
            case EnemyType.First:
                tempEnemy = GameObject.Instantiate(enemy1);
                tempEnemy.transform.parent = parent;
                break;
            case EnemyType.Second:
                tempEnemy = GameObject.Instantiate(enemy2);
                tempEnemy.transform.parent = parent;
                break;
            case EnemyType.Third:
                tempEnemy = GameObject.Instantiate(enemy3);
                tempEnemy.transform.parent = parent;
                break;
        }

        return tempEnemy;
    }
}
