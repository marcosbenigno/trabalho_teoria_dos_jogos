using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    public float speed = 3.0f;
    public bool vertical;
    public float changeTime = 3.0f;

    public int maxHealth = 5;

    float dazedTime;
    public float startDazedTime = 0.6f;

    int currentHealth;
    public int health { get { return currentHealth; } }

    Rigidbody2D rigidbody2D;
    float timer;
    int direction = 1;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();

        currentHealth = maxHealth;
    }

    void Update()
    {
        if (dazedTime <= 0 ) {
            speed = 3.0f;
        } else
        {
            speed = 0;
            dazedTime -= Time.deltaTime;
        }

        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }

        timer -= Time.deltaTime;

        if (timer < 0)
        {
            direction = -direction;
            timer = changeTime;
        }
    }

    void FixedUpdate()
    {
        Vector2 position = rigidbody2D.position;

        if (vertical)
        {
            position.y = position.y + Time.deltaTime * speed * direction;
        }
        else
        {
            position.x = position.x + Time.deltaTime * speed * direction;
        }

        rigidbody2D.MovePosition(position);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        MainCharControl player = other.gameObject.GetComponent<MainCharControl>();

        if (player != null)
        {
            player.ChangeHealth(-1);
        }
    }

    public void ChangeHealth(int amount)
    {
        dazedTime = startDazedTime;
        //Instantiate(bloodEffect, transform.position, Quaternion.identity);
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        UnityEngine.Debug.Log("Damage taken");
    }
}
