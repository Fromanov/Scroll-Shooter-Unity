using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMover : MonoBehaviour
{
    [SerializeField]
    private float speed = 15f;

    private float bulletLifeTime = 3f;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.velocity = Vector3.forward * speed;
        bulletLifeTime -= Time.deltaTime;

        if(bulletLifeTime <= 0)
        {
            Death();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        switch(other.gameObject.tag)
        {
            case "Asteroid":
                player.GetComponent<PlayerController>().AddScore(100);
                Death();
                break;
            case "Enemy":
                player.GetComponent<PlayerController>().AddScore(200);
                Death();
                break;
            case "Border":                
                Death();
                break;
        }
    }

    void Death()
    {
        this.gameObject.SetActive(false);
        Destroy(this.gameObject);
    }
}
