using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Rigidbody enemyRb;

    private float zBoundry = 11.2f;
    private float xBoundry = 32.3f;

    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        FindRbAndPlayer();
    }

    // Update is called once per frame
    void Update()
    {
        FollowPlayer(7.5f);
        RestrictEnemyMovement();
    }
    public void FollowPlayer(float speed)
    {
        Vector3 lookDirection = (player.transform.position - transform.position).normalized;
        transform.Translate(lookDirection * speed * Time.deltaTime);
    }
    // Find the rigid body of the enemy as well as the player/target
    public void FindRbAndPlayer()
    {
        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }
    // Restrict Enemy Movement
    public void RestrictEnemyMovement()
    {
        if (transform.position.x < -xBoundry)
        {
            transform.position = new Vector3(-xBoundry, transform.position.y, transform.position.z);
        }
        if (transform.position.x > xBoundry)
        {
            transform.position = new Vector3(xBoundry, transform.position.y, transform.position.z);
        }

        if (transform.position.z < -zBoundry)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -zBoundry);
        }

        if (transform.position.z > zBoundry)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zBoundry);
        }
    }
}

