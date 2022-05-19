using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootProjectile : MonoBehaviour
{
    public GameObject projectilePrefab;

    public GameObject playerControlObject;
    private PlayerControl v_playerControl;
   
    public float timer;
    private float timeLimit = 0.35f;
    

    // Start is called before the first frame update
    void Start()
    {
        v_playerControl = playerControlObject.GetComponent<PlayerControl>();
    }

    // Update is called once per frame
    void Update()
    {
        // Allow player to shoot if alive
        if(v_playerControl.isAlive == true)
        {
            FireProjectile();
        }
    }
    void FireProjectile()
    {
        // Start the timer for the attack interval
        timer += Time.deltaTime;
        // Shoot a prjectile based on the position of the cannon
        if (Input.GetKeyDown(KeyCode.Space) && timer > timeLimit)
        {
            Instantiate(projectilePrefab, transform.position, transform.rotation);
            timer = 0.0f;
        }
    }
}
