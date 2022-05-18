using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    public float projectileSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Shoot the projectile at a certain speed
        transform.Translate(Vector3.forward * projectileSpeed * Time.deltaTime);
    }
}
