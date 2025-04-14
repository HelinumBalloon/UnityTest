using UnityEngine;

public class SturgeonMove : MonoBehaviour
{
    
    private float scaleFactor;
    public Rigidbody2D sturgeonRigidbody;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        scaleFactor = Random.Range(6, 15);
        sturgeonRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position += (Vector3.left * scaleFactor) * Time.fixedDeltaTime;
        if (transform.position.x < -35f || Mathf.Abs(transform.position.y) > 25f)
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        sturgeonRigidbody.constraints = RigidbodyConstraints2D.FreezeRotation;
        sturgeonRigidbody.AddForce((-transform.up * scaleFactor * 3f) * Time.fixedDeltaTime, ForceMode2D.Impulse);
    }
}
