using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowEnemy : Enemy
{
    private Rigidbody slowEnemyRb;

    private GameObject player;

    private float speed = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        slowEnemyRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        FollowPlayer();
    }
}
