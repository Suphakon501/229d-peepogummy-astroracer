using UnityEngine;

public class Meteor : MonoBehaviour
{
    private Vector3 targetPosition;
    private Rigidbody rb;
    public float mass = 1f; // มวลของอุกกาบาต
    public float force = 500f; // แรงที่กระทำต่ออุกกาบาต (เช่น แรงโน้มถ่วงของดาวเคราะห์)

    public void Initialize(Vector3 target, float speed)
    {
        targetPosition = target;
        rb = GetComponent<Rigidbody>();

        if (rb == null)
        {
            rb = gameObject.AddComponent<Rigidbody>();
        }

        rb.mass = mass; // กำหนดมวลให้ Rigidbody
        rb.useGravity = false; // ปิดระบบแรงโน้มถ่วงของ Unity
    }

    void FixedUpdate()
    {
    
        float acceleration = force / mass;

        Vector3 direction = (targetPosition - transform.position).normalized;

       
        rb.AddForce(direction * acceleration, ForceMode.Acceleration);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<SpaceCarController>()?.TakeDamage(20);
            Destroy(gameObject);
        }
        else if (other.CompareTag("Ground")) 
        {
            Destroy(gameObject);
        }
    }
}
