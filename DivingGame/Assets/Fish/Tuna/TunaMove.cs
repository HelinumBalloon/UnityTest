using UnityEngine;
using System.Collections;
public class TunaMove : MonoBehaviour
{
    private GameObject diver;
    private Vector3 direction;
    private int moveSpeed;
    [SerializeField] private Animator animator;
    [SerializeField] private AnimationCurve YVelocityCurve;
    [SerializeField] private Rigidbody2D tunaBody;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        diver = GameObject.FindGameObjectWithTag("Diver");
        StartCoroutine(SpeedChange());
    }
    
    void FixedUpdate()
    {
        direction = transform.position - diver.transform.position;
        transform.position += (Vector3.left * moveSpeed) * Time.fixedDeltaTime;
    }
    IEnumerator SpeedChange()
    {
        while (true)
        {
            moveSpeed = Random.Range(15, 20);
			tunaBody.linearVelocity = Vector3.up * YVelocityCurve.Evaluate(direction.y);
            yield return new WaitForSeconds(0.5f);
        }
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
