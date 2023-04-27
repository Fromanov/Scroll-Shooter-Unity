using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private int health = 3;
    private int maxHealth = 3; 
    [SerializeField]
    private int score = 0;
    [SerializeField]
    private float speed = 5f;
    [SerializeField]
    private GameObject bullet;
    [SerializeField]
    private Transform shootPosition;    

    private float movementX;
    private float movementY;
    private Rigidbody rb;
    private GameObject uiManager;
    private GameObject audioManager;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        uiManager = GameObject.FindGameObjectWithTag("UI");
        audioManager = GameObject.FindGameObjectWithTag("Audio");
    }

    public void OnMove(InputValue inputValue)
    {
        Vector2 movementVector = inputValue.Get<Vector2>();
        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    public void OnFire()
    {
        Instantiate(bullet, 
            new Vector3(shootPosition.position.x, shootPosition.position.y,
            shootPosition.position.z), bullet.transform.rotation);
        audioManager.GetComponent<AudioManager>().Play("Shoot");
    }
    
    void FixedUpdate()
    {
        rb.velocity = 
            new Vector3(movementX * speed, 0.0f, movementY * speed);        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Asteroid") ||
            other.gameObject.CompareTag("Enemy"))
        {
            health--;
            
            uiManager.GetComponent<UIManager>().ShowHeartsUI(health);

            if (health <= 0)
            {
                Death();
            }
        }

        if(other.gameObject.CompareTag("Heal"))
        {
            if (health < maxHealth)
            {
                health++;
                uiManager.GetComponent<UIManager>().ShowHeartsUI(health);
            }            
        }
    }

    void Death()
    {
        uiManager.GetComponent<UIManager>().ShowDeathPanel();
        this.gameObject.SetActive(false);
        Destroy(this.gameObject);
    }

    public int ShowHealth()
    {
        int showHealth = health;
        return showHealth;
    }

    public void AddScore(int addScore)
    {
        score += addScore;
        uiManager.GetComponent<UIManager>().ShowScoreUI(score);
    }
}
