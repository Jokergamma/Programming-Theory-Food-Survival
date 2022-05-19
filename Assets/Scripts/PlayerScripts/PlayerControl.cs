using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float speed;

    public GameObject projectilePrefab;

    private float horizontalInput;
    private float forwardInput;

    [SerializeField] private int lifeCount;
    [SerializeField] private bool isAlive;

    private float zBoundry = 12.0f;
    private float xBoundry = 35.0f;
    // Start is called before the first frame update
    void Start()
    {
        isAlive = true;
        lifeCount = 3;
    }

    // Update is called once per frame
    void Update()
    {
        if(isAlive == true)
        {
            Movement();
        }
    }
    // Allow the player to move using WASD
    void Movement()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");

        transform.Translate(Vector3.back * forwardInput * speed * Time.deltaTime);
        transform.Translate(Vector3.left * horizontalInput * speed * Time.deltaTime);
        // Restricts player movements
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

        if(transform.position.z > zBoundry)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zBoundry);
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        lifeCount -= 1;
    }

}
