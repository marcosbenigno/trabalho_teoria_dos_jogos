using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;
using static System.Net.Mime.MediaTypeNames;

public class MainCharControl : MonoBehaviour
{
    public float speed = 3.0f;

    public int maxHealth = 5;
    public float timeInvinsible = 2.0f;
    int currentHealth;
    public int health { get { return currentHealth; } }
    bool isInvinsible;
    float invincibleTimer;

    bool hasNewSword;

    Rigidbody2D rigidbody2d;
    float horizontal;
    float vertical;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();

        hasNewSword = false;

        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        if (isInvinsible)
        {
            invincibleTimer -= Time.deltaTime;
            if (invincibleTimer < 0)
            {
                isInvinsible = false;
            }
        }

        if (hasNewSword)
        {
            changeDamage(1);
        }
    }

    void FixedUpdate() {
        Vector2 position = rigidbody2d.position;
        position.x = position.x + speed * horizontal * Time.deltaTime;
        position.y = position.y + speed * vertical * Time.deltaTime;

        rigidbody2d.MovePosition(position);
    }

    public void ChangeHealth(int amount)
    {
        if (amount < 0)
        {
            if (isInvinsible)
                return;

            isInvinsible = true;
            invincibleTimer = timeInvinsible;
        }
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        UnityEngine.Debug.Log(currentHealth + "/" + maxHealth);
    }

    void changeDamage(int amount) {
        GetComponent<MainCharAttack>().damage += amount; // Mudar para o dano específico da espada
        hasNewSword = false;
    }
}
