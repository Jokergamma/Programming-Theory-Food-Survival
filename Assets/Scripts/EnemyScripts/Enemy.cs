using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Rigidbody enemyRb;
   
    private GameObject player;

    [SerializeField] private float ForcePower = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        FindRbAndPlayer();
    }

    // Update is called once per frame
    void Update()
    {
        FollowPlayer(7.5f);
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
    // Push enemies away from the player
  /*  public void OnCollisionEnter(Collision other)
    {
        Vector3 awayFromPlayer = (transform.position - player.transform.position).normalized;
        if (gameObject.CompareTag("Player"))
        {
            enemyRb.AddForce(awayFromPlayer * ForcePower * Time.deltaTime, ForceMode.Impulse);
        }
    } */
}
