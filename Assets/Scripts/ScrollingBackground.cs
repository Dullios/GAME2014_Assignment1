using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * File:
 *      ScrollingBackground.cs
 * 
 * By:
 *      Russell Brabers - 101192571
 * 
 * Date Modified: 
 *      October 4, 2020
 * 
 * Description:
 *      A script to manage the moving background
 *      
 * Revision History:
 *      - Initial creation
 *      - Variable setup and added background movement in Update method
 */

public class ScrollingBackground : MonoBehaviour
{
    [SerializeField]
    private GameObject[] backgroundParts = new GameObject[3];

    [SerializeField]
    private int index;

    [SerializeField]
    private float speed;

    // Start is called before the first frame update
    void Start()
    {
        index = 2;
    }

    // Update is called once per frame
    void Update()
    {
        foreach(GameObject g in backgroundParts)
        {
            g.transform.Translate(new Vector3(speed, 0, 0));

            if (g.transform.position.x <= -15)
            {
                g.transform.position = new Vector3(backgroundParts[index].transform.position.x + 10.6f, 0, 0);
                index = index + 1 < 3 ? index + 1 : 0;
            }
        }
    }
}
