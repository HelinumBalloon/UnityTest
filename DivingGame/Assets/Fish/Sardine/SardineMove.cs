using UnityEngine;
// For coroutine use.
using System.Collections;
public class SardineMove : MonoBehaviour
{
    private float moveSpeed;
    private float frequency = 5f;
    private float amplitude = 2f;
    public Animator animator;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //coroutines execute according to WaitForSeconds (see below) 
        StartCoroutine(SpeedChange());
    }

    // Update is called once per frame
    void Update()
    {
        float offset = amplitude * Mathf.Sin(Time.time * frequency);
        transform.position += (Vector3.left * moveSpeed + Vector3.up * offset) * Time.deltaTime;
        if (transform.position.x < -20f)
        {
            Destroy(gameObject);
        }
    }

    IEnumerator SpeedChange()
    {
        moveSpeed = Random.Range(3f, 8f);
        yield return new WaitForSeconds(0.5f);
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
