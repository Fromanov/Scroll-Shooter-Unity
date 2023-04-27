using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShootMover : MonoBehaviour
{
    [SerializeField]
    private float speed = 7f;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        rb.velocity = Vector3.back * speed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") ||
            other.gameObject.CompareTag("Border"))
        {
            Death();
        }
    }

    void Death()
    {
        this.gameObject.SetActive(false);
        Destroy(this.gameObject);
    }
}
