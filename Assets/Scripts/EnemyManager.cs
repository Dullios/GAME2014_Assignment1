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

    [Header("Wave Statistics")]
    public int waveNum;
    public float flightTime;
    public bool spawnBool;
    public bool moveBool;

    // Start is called before the first frame update
    void Start()
    {
        waveNum = 1;

        CreateWaves();
    }

    // Update is called once per frame
    void Update()
    {
        if(spawnBool)
        {
            SpawnWave(waveNum);
            spawnBool = false;
        }

        if(moveBool)
        {
            MoveWave(waveNum);
        }
        else
            flightTime = 0.0f;

        bool newWave = true;
        switch(waveNum)
        {
            case 1:
                foreach(EnemyMovement enMove in wave1List)
                {
                    if (enMove.enemy.activeInHierarchy)
                    {
                        newWave = false;
                        break;
                    }
                }
                break;
            case 2:
                foreach (EnemyMovement enMove in wave2List)
                {
                    if (enMove.enemy.activeInHierarchy)
                    {
                        newWave = false;
                        break;
                    }
                }
                break;
        }

        if(newWave == true)
        {
            waveNum = waveNum == 1 ? 2 : 1;
            spawnBool = true;
            moveBool = true;
        }
    }

    /// <summary>
    /// Method to set up start and end positions of enemy waves through brute force
    /// </summary>
    private void CreateWaves()
    {
        wave1List = new List<EnemyMovement>();
        #region Wave1
        // Enemy 1
        EnemyMovement nmeMove = new EnemyMovement();
        nmeMove.enemy = EnemyFactory.Instance().CreateEnemy(EnemyType.First, wave1.transform);
        nmeMove.enemy.SetActive(false);
        nmeMove.startPos = new Vector3(12.5f, 3.5f, 0.0f);
        nmeMove.endPos = new Vector3(7.5f, 3.5f, 0.0f);

        wave1List.Add(nmeMove);

        // Enemy 2
        nmeMove = new EnemyMovement();
        nmeMove.enemy = EnemyFactory.Instance().CreateEnemy(EnemyType.First, wave1.transform);
        nmeMove.enemy.SetActive(false);
        nmeMove.startPos = new Vector3(10.5f, 1.5f, 0.0f);
        nmeMove.endPos = new Vector3(5.5f, 1.5f, 0.0f);

        wave1List.Add(nmeMove);

        // Enemy 3
        nmeMove = new EnemyMovement();
        nmeMove.enemy = EnemyFactory.Instance().CreateEnemy(EnemyType.First, wave1.transform);
        nmeMove.enemy.SetActive(false);
        nmeMove.startPos = new Vector3(10.5f, -1.5f, 0.0f);
        nmeMove.endPos = new Vector3(5.5f, -1.5f, 0.0f);

        wave1List.Add(nmeMove);

        // Enemy 4
        nmeMove = new EnemyMovement();
        nmeMove.enemy = EnemyFactory.Instance().CreateEnemy(EnemyType.First, wave1.transform);
        nmeMove.enemy.SetActive(false);
        nmeMove.startPos = new Vector3(12.5f, -3.5f, 0.0f);
        nmeMove.endPos = new Vector3(7.5f, -3.5f, 0.0f);

        wave1List.Add(nmeMove);
        #endregion

        #region Wave2
        wave2List = new List<EnemyMovement>();

        // Enemy 1
        nmeMove = new EnemyMovement();
        nmeMove.enemy = EnemyFactory.Instance().CreateEnemy(EnemyType.Second, wave1.transform);
        nmeMove.enemy.SetActive(false);
        nmeMove.startPos = new Vector3(12.5f, 3.5f, 0.0f);
        nmeMove.endPos = new Vector3(6.5f, 3.5f, 0.0f);

        wave2List.Add(nmeMove);

        // Enemy 2
        nmeMove = new EnemyMovement();
        nmeMove.enemy = EnemyFactory.Instance().CreateEnemy(EnemyType.Second, wave1.transform);
        nmeMove.enemy.SetActive(false);
        nmeMove.startPos = new Vector3(10.5f, 2.2f, 0.0f);
        nmeMove.endPos = new Vector3(4.5f, 2.2f, 0.0f);

        wave2List.Add(nmeMove);

        // Enemy 3
        nmeMove = new EnemyMovement();
        nmeMove.enemy = EnemyFactory.Instance().CreateEnemy(EnemyType.Second, wave1.transform);
        nmeMove.enemy.SetActive(false);
        nmeMove.startPos = new Vector3(10.5f, -2.2f, 0.0f);
        nmeMove.endPos = new Vector3(4.5f, -2.2f, 0.0f);

        wave2List.Add(nmeMove);

        // Enemy 4
        nmeMove = new EnemyMovement();
        nmeMove.enemy = EnemyFactory.Instance().CreateEnemy(EnemyType.Second, wave1.transform);
        nmeMove.enemy.SetActive(false);
        nmeMove.startPos = new Vector3(12.5f, -3.5f, 0.0f);
        nmeMove.endPos = new Vector3(6.5f, -3.5f, 0.0f);

        wave2List.Add(nmeMove);

        // Enemy 5
        nmeMove = new EnemyMovement();
        nmeMove.enemy = EnemyFactory.Instance().CreateEnemy(EnemyType.Third, wave1.transform);
        nmeMove.enemy.SetActive(false);
        nmeMove.startPos = new Vector3(13.5f, 1.0f, 0.0f);
        nmeMove.endPos = new Vector3(7.5f, 1.0f, 0.0f);

        wave2List.Add(nmeMove);

        // Enemy 6
        nmeMove = new EnemyMovement();
        nmeMove.enemy = EnemyFactory.Instance().CreateEnemy(EnemyType.Third, wave1.transform);
        nmeMove.enemy.SetActive(false);
        nmeMove.startPos = new Vector3(13.5f, -1.0f, 0.0f);
        nmeMove.endPos = new Vector3(7.5f, -1.0f, 0.0f);

        wave2List.Add(nmeMove);
        #endregion
    }

    /// <summary>
    /// Get Enemy game objects and assign them to a wave
    /// </summary>
    /// <param name="wave"></param>
    public void SpawnWave(int wave)
    {
        switch (wave)
        {
            case 1:
                for(int i = 0; i < wave1List.Count; i++)
                {
                    wave1List[i].enemy.SetActive(true);
                    wave1List[i].enemy.transform.position = wave1List[i].startPos;
                }
                break;
            case 2:
                for (int i = 0; i < wave2List.Count; i++)
                {
                    wave2List[i].enemy.SetActive(true);
                    wave2List[i].enemy.transform.position = wave2List[i].startPos;
                }
                break;
        }
    }

    /// <summary>
    /// Method to move a given wave over time from its start to end position
    /// </summary>
    /// <param name="wave"></param>
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
                    {
                        moveBool = false;
                    }
                }
                break;
            case 2:
                foreach (EnemyMovement em in wave2List)
                {
                    if (flightTime < 1)
                    {
                        em.enemy.transform.position = new Vector3(Mathf.Lerp(em.startPos.x, em.endPos.x, flightTime), em.enemy.transform.position.y, 0.0f);
                        flightTime += 0.002f;
                    }
                    else
                    {
                        moveBool = false;
                    }
                }
                break;
        }
    }
}
