using UnityEngine;
using System.Collections;
public class DiverMain : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth = 100;
    public HealthBar healthBar;
    public Rigidbody2D myRigidbody;
    public SpriteRenderer sprite;
    private Color color;
    //"HealthTextScript" must be 一字不錯 for unity to find properly
    public HealthTextScript healthText;
    public float upForceFactor = 75f;
    public float leftForceFactor = 75f;
    public float downForceFactor = 75f;
    public float rightForceFactor = 75f;
    public bool diverIsAlive = true;
    private bool isWPressed = false;
    private bool isAPressed = false;
    private bool isSPressed = false;
    private bool isDPressed = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        myRigidbody = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        color = sprite.material.color;
        // to execute visible score change on health text from diver script
        healthText = GameObject.FindWithTag("healthText").GetComponent<HealthTextScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (diverIsAlive)
        {
            isWPressed = Input.GetKey(KeyCode.W);
            isAPressed = Input.GetKey(KeyCode.A);
            isSPressed = Input.GetKey(KeyCode.S);
            isDPressed = Input.GetKey(KeyCode.D);
        }
    }
    // FixedUpdate is physics engine-dependent, so it's better for movement inputs
    void FixedUpdate()
    {
        if (isWPressed) 
        {
            myRigidbody.AddForce(transform.up * upForceFactor * Time.fixedDeltaTime, ForceMode2D.Impulse); 
        }

        if (isAPressed)
        {
            //transform.left doesn't exist, same as transform.down
            myRigidbody.AddForce(-transform.right * leftForceFactor * Time.fixedDeltaTime, ForceMode2D.Impulse);
        }

        if (isSPressed)
        {
            myRigidbody.AddForce(-transform.up * downForceFactor * Time.fixedDeltaTime, ForceMode2D.Impulse);
        }

        if (isDPressed)
        {
            myRigidbody.AddForce(transform.right * rightForceFactor * Time.fixedDeltaTime, ForceMode2D.Impulse);
        }
        Vector2 clampedPosition = transform.position;
        clampedPosition.x = Mathf.Clamp(clampedPosition.x, -18f, 18f);
        clampedPosition.y = Mathf.Clamp(clampedPosition.y, -10f, 10f);
        transform.position = clampedPosition;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "BasicPrey":
                TakeDamage(1);
                // break necessary to exit switch statement
                healthText.loseHealth(1);
                break;
            case "BasicPredator":
                TakeDamage(2);
                healthText.loseHealth(2);
                break;
        }
        StartCoroutine(Invincibility());
        StartCoroutine(Blink());
    }

    IEnumerator Invincibility()
    {
        // 3rd layer is fishlayer, 6th is diver
        Physics2D.IgnoreLayerCollision(3, 6, true);
        yield return new WaitForSeconds(1f);
        Physics2D.IgnoreLayerCollision(3, 6, false);
    }

    IEnumerator Blink()
    {
        sprite.material.color = new Color(color.r, color.g * 0.5f, color.b * 0.5f, color.a * 0.5f);
        yield return new WaitForSeconds(0.25f);
        sprite.material.color = new Color(color.r, color.g, color.b, color.a);
        yield return new WaitForSeconds(0.25f);
        sprite.material.color = new Color(color.r, color.g * 0.5f, color.b * 0.5f, color.a * 0.5f);
        yield return new WaitForSeconds(0.25f);
        sprite.material.color = new Color(color.r, color.g, color.b, color.a);
        yield return new WaitForSeconds(0.25f);
    }
    void TakeDamage(int amount)
    {
        currentHealth -= amount;
        // to update healthbar visuals
        healthBar.SetHealth(currentHealth);
        if (currentHealth <= 0)
        {
            diverIsAlive = false;
        }
    }
}