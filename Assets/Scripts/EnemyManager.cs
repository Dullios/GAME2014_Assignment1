using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * File:
 *      EnemyManager.cs
 * 
 * By:
 *      Russell Brabers - 101192571
 * 
 * Date Modified: 
 *      October 26, 2020
 * 
 * Description:
 *      A class to manage enemy waves in the scene
 *      
 * Revision History:
 *      - Initial creation
 *      - Created Enemy Type enum
 *      - Added functions to spawn and move waves of enemies
 */

[System.Serializable]
public enum EnemyType
{
    First,
    Second,
    Third
}

public class EnemyManager : MonoBehaviour
{
    public GameObject wave1;
    public GameObject wave2;

    public struct EnemyMovement
    {
        public GameObject enemy;
        public Vector3 startPos;
        public Vector3 endPos;
    }

    private List<EnemyMovement> wave1List;
    private List<EnemyMovement> wave2List;

    public float flightTime;
    public bool spawnBool;
    public bool moveBool;

    // Start is called before the first frame update
    void Start()
    {
        wave1List = new List<EnemyMovement>();
        wave2List = new List<EnemyMovement>();

        CreateWaves();
    }

    // Update is called once per frame
    void Update()
    {
        if(spawnBool)
        {
            SpawnWave(1);
            spawnBool = false;
        }

        if(moveBool)
        {
            MoveWave(1);
        }
    }

    public void SpawnWave(int wave)
    {
        GameObject tempEnemy;
        EnemyMovement enMoveTemp;

        switch (wave)
        {
            case 1:
                for(int i = 0; i < wave1List.Count; i++)
                {
                    enMoveTemp = wave1List[i];
                    tempEnemy = EnemyFactory.Instance().CreateEnemy(EnemyType.First, wave1.transform);
                    tempEnemy.transform.position = enMoveTemp.startPos;
                    enMoveTemp.enemy = tempEnemy;

                    wave1List[i] = enMoveTemp;
                }
                break;
            case 2:

                break;
        }
    }

    private void MoveWave(int wave)
    {
        switch(wave)
        {
            case 1:
                foreach(EnemyMovement em in wave1List)
                {
                    if (flightTime < 1)
                    {
                        em.enemy.transform.position = new Vector3(Mathf.Lerp(em.startPos.x, em.endPos.x, flightTime), em.enemy.transform.position.y, 0.0f);
                        flightTime += 0.002f;
                    }
                    else
                        moveBool = false;
                }
                break;
            case 2:
                break;
        }
    }

    private void CreateWaves()
    {
        #region Wave1
        // Enemy 1
        EnemyMovement nmeMove = new EnemyMovement();
        nmeMove.startPos = new Vector3(12.5f, 3.5f, 0.0f);
        nmeMove.endPos = new Vector3(7.5f, 3.5f, 0.0f);

        wave1List.Add(nmeMove);

        // Enemy 2
        nmeMove = new EnemyMovement();
        nmeMove.startPos = new Vector3(10.5f, 1.5f, 0.0f);
        nmeMove.endPos = new Vector3(5.5f, 1.5f, 0.0f);

        wave1List.Add(nmeMove);

        // Enemy 3
        nmeMove = new EnemyMovement();
        nmeMove.startPos = new Vector3(10.5f, -1.5f, 0.0f);
        nmeMove.endPos = new Vector3(5.5f, -1.5f, 0.0f);

        wave1List.Add(nmeMove);

        // Enemy 4
        nmeMove = new EnemyMovement();
        nmeMove.startPos = new Vector3(12.5f, -3.5f, 0.0f);
        nmeMove.endPos = new Vector3(7.5f, -3.5f, 0.0f);

        wave1List.Add(nmeMove);
        #endregion

        #region Wave2
        // Enemy 1
        nmeMove = new EnemyMovement();
        nmeMove.startPos = new Vector3(12.5f, 3.5f, 0.0f);
        nmeMove.endPos = new Vector3(6.5f, 3.5f, 0.0f);

        // Enemy 2
        nmeMove = new EnemyMovement();
        nmeMove.startPos = new Vector3(10.5f, 2.2f, 0.0f);
        nmeMove.endPos = new Vector3(4.5f, 2.2f, 0.0f);

        // Enemy 3
        nmeMove = new EnemyMovement();
        nmeMove.startPos = new Vector3(10.5f, -2.2f, 0.0f);
        nmeMove.endPos = new Vector3(4.5f, -2.2f, 0.0f);

        // Enemy 4
        nmeMove = new EnemyMovement();
        nmeMove.startPos = new Vector3(12.5f, -3.5f, 0.0f);
        nmeMove.endPos = new Vector3(6.5f, -3.5f, 0.0f);

        // Enemy 5
        nmeMove = new EnemyMovement();
        nmeMove.startPos = new Vector3(13.5f, 1.0f, 0.0f);
        nmeMove.endPos = new Vector3(7.5f, 1.0f, 0.0f);

        // Enemy 6
        nmeMove = new EnemyMovement();
        nmeMove.startPos = new Vector3(13.5f, -1.0f, 0.0f);
        nmeMove.endPos = new Vector3(7.5f, -1.0f, 0.0f);
        #endregion
    }
}
