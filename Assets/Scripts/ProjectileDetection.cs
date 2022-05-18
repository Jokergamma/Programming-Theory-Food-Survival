using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileDetection : MonoBehaviour
{
    private float xBound = 40.0f;
    private float zBound = 15.0f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        DestoryOutOfBounds();
    }
    // Destroy projectile and enemy once they collide (IN PROGRESS! BUGGED WAHHHHHHHH!)
    private void OnCollisionEnter(Collision other)
    {
        if(!gameObject.CompareTag("Player"))
        Destroy(other.gameObject);
        Debug.Log("HIT");
        Destroy(gameObject);
    }
    // Destroy projectiles that go outside of the scene
    private void DestoryOutOfBounds()
    {
        if (transform.position.x < -xBound || transform.position.x > xBound || transform.position.z < -zBound || transform.position.z > zBound)
        {
            Destroy(gameObject);
        }
    }
}