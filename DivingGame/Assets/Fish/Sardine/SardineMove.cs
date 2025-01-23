using UnityEngine;
// For coroutine use.
using System.Collections;
public class SardineMove : MonoBehaviour
{
    private Vector3 diverVelocity;
    private int scaleFactor;
    private float frequency = 5f;
    private float amplitude = 2f;
    [SerializeField] private Animator animator;
    [SerializeField] private AnimationCurve XVelocityCurve;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        scaleFactor = Random.Range(3, 8);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        diverVelocity = GameObject.FindGameObjectWithTag("Diver").GetComponent<Rigidbody2D>().linearVelocity;
        float offset = amplitude * Mathf.Sin(Time.time * frequency);
        transform.position += (Vector3.left * scaleFactor * XVelocityCurve.Evaluate(diverVelocity.x)) * Time.fixedDeltaTime;
        transform.position += (Vector3.up * offset) * Time.fixedDeltaTime;
        if (transform.position.x < -20f)
        {
            Destroy(gameObject);
        }
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        StartCoroutine(Explosion());
    }
    IEnumerator Explosion()
    {
        animator.SetBool("Alive", false);
        // slightly longer waittime than animation time to play all
        yield return new WaitForSeconds(0.6f);
        Destroy(gameObject);
    }
}
