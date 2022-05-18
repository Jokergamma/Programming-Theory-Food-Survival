using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Rigidbody enemyRb;

    [SerializeField] private float speed;
   
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        // Find the rigid body of the enemy as well as the player/target
        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        FollowPlayer();
    }
    public void FollowPlayer()
    {
        Vector3 lookDirection = (player.transform.position - transform.position).normalized;
        transform.Translate(lookDirection * speed * Time.deltaTime);
    }
}
