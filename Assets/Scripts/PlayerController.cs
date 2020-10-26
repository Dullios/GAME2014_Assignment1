using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/*
 * File:
 *      PlayerController.cs
 * 
 * By:
 *      Russell Brabers - 101192571
 * 
 * Date Modified: 
 *      October 25, 2020
 * 
 * Description:
 *      A script to control the movement and functions of the player character
 *      
 * Revision History:
 *      - Initial creation
 *      - Added Move and CheckBounds methods
 *      - Added BulletManager reference
 *      - Added OnHit unity event to run when player is hit
 */

public class PlayerController : MonoBehaviour
{
    public UnityEvent OnHit;

    public BulletManager bulletManager;

    [Header("Player Movement")]
    public float speed;
    public float leftBoundary;
    public float rightBoundary;
    public float verticalBoundary;
    public float timeValue;

    private Rigidbody2D rigidBody;
    private Vector3 touchEnded;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        touchEnded = new Vector3();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        CheckBounds();
        FireBullet();
    }

    private void Move()
    {
        float verticalDir = 0.0f;
        float horizontalDir = 0.0f;

        foreach (Touch touch in Input.touches)
        {
            var worldTouch = Camera.main.ScreenToWorldPoint(touch.position);
            
            if (worldTouch.x > transform.position.x)
                horizontalDir = 1.0f;
            else if (worldTouch.x < transform.position.x)
                horizontalDir = -1.0f;

            if (worldTouch.y > transform.position.y)
                verticalDir = 1.0f;
            else if (worldTouch.y < transform.position.y)
                verticalDir = -1.0f;

            touchEnded = worldTouch;
        }

        if (touchEnded.x <= 0.0f && touchEnded.y != 0.0f)
            transform.position = new Vector3(Mathf.Lerp(transform.position.x, touchEnded.x, timeValue), Mathf.Lerp(transform.position.y, touchEnded.y, timeValue), 0.0f);
        else
        {
            Vector2 newVelocity = rigidBody.velocity + new Vector2(horizontalDir * speed, verticalDir * speed);
            rigidBody.velocity *= 0.99f;
        }
    }

    private void CheckBounds()
    {
        if (transform.position.x >= rightBoundary)
            transform.position = new Vector3(rightBoundary, transform.position.y, 0.0f);
        else if(transform.position.x <= leftBoundary)
            transform.position = new Vector3(leftBoundary, transform.position.y, 0.0f);

        if (transform.position.y >= verticalBoundary)
            transform.position = new Vector3(transform.position.x, verticalBoundary, 0.0f);
        else if (transform.position.y <= -verticalBoundary)
            transform.position = new Vector3(transform.position.x, -verticalBoundary, 0.0f);
    }

    private void FireBullet()
    {
        if (Time.frameCount % 60 == 0)
            bulletManager.GetBullet(BulletType.PlayerBullet, gameObject.transform.position);
    }
}
