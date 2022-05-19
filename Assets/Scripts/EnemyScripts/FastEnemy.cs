using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastEnemy : Enemy
{
    // Start is called before the first frame update
    void Start()
    {
        FindRbAndPlayer();
    }

    // Update is called once per frame
    void Update()
    {
        FollowPlayer(10.0f);
    }
}
