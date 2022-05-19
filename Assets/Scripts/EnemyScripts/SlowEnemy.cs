using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowEnemy : Enemy
{
    // Start is called before the first frame update
    void Start()
    {
        FindRbAndPlayer();
    }

    // Update is called once per frame
    void Update()
    {
        FollowPlayer(5.0f);
    }
}
