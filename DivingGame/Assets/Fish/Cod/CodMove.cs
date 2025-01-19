using UnityEngine;
using System.Collections;
public class CodMove : MonoBehaviour
{
    private float moveSpeed;
    public Animator animator;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(SpeedChange());
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += (Vector3.left * moveSpeed) * Time.deltaTime;
        if (transform.position.x < -20f)
        {
            Destroy(gameObject);
        }
    }
    IEnumerator SpeedChange()
    {
        moveSpeed = Random.Range(2f, 5f);
        yield return new WaitForSeconds(0.5f);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        StartCoroutine(Explosion());
    }
    IEnumerator Explosion()
    {
        animator.SetBool("Alive", false);
        yield return new WaitForSeconds(0.6f);
        Destroy(gameObject);
    }
}
