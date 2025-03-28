using UnityEngine;
using UnityEngine.SceneManagement; 
using UnityEngine.UI;

public class SpaceCarController : MonoBehaviour
{
    public float speed = 50f;
    public float turnSpeed = 50f;
    private Rigidbody rb;
    public int health = 100;
    public HealthBarController healthBar;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;
        rb.interpolation = RigidbodyInterpolation.Interpolate;

        if (healthBar != null)
        {
            healthBar.SetHealth(health);
        }
    }

    void FixedUpdate()
    {
        float move = Input.GetAxis("Vertical") * speed;
        float turn = Input.GetAxis("Horizontal") * turnSpeed;

        if (!Physics.Raycast(transform.position, transform.forward, 2.0f))
        {
            Vector3 movement = transform.forward * move * Time.fixedDeltaTime;
            rb.MovePosition(rb.position + movement);
        }
        Quaternion turnRotation = Quaternion.Euler(0f, turn * Time.fixedDeltaTime, 0f);
        rb.MoveRotation(rb.rotation * turnRotation);
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (healthBar != null)
        {
            healthBar.SetHealth(health);
        }

        if (health <= 0)
        {   
            SceneManager.LoadScene("Lose"); 
        }
    }
}
