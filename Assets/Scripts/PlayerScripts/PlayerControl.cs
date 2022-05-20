using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] private float speed = 11;

    [SerializeField] private GameObject projectilePrefab;

   [SerializeField] private float horizontalInput;
   [SerializeField] private float forwardInput;

    [SerializeField] private float forcePower = 5.0f;

    [SerializeField] private TextMeshProUGUI lifeCountText;
    [SerializeField] private TextMeshProUGUI gameoverText;
    [SerializeField] private Button playAgainButton;
    [SerializeField] private int lifeCount;
    public bool isAlive;

    private float zBoundry = 11.2f;
    private float xBoundry = 32.3f;
    // Start is called before the first frame update
    void Start()
    {
        StartingPlayerStats();
    }

    // Update is called once per frame
    void Update()
    {
        // Allow movement when player is alive
        if(isAlive == true)
        {
            Movement();
        }
        else if(isAlive == false)
        {
            GameOver();
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
        lifeCount = lifeCount - 1;
        lifeCountText.text = "Health: " + lifeCount;
        if(lifeCount == 0)
        {
            isAlive = false;
        }
    }
    // Push enemies away from the player
    private void OnCollisionEnter(Collision other) // IN PROCESS
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Rigidbody enemyRigidbody = other.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = other.gameObject.transform.position - transform.position;

            enemyRigidbody.AddForce(awayFromPlayer * forcePower, ForceMode.Impulse);
        }
    }
    private void GameOver()
    {
        gameoverText.gameObject.SetActive(true);
        playAgainButton.gameObject.SetActive(true);
    }
    private void StartingPlayerStats()
    {
        isAlive = true;
        lifeCount = 3;
        lifeCountText.text = "Health: " + lifeCount;
    }
}
