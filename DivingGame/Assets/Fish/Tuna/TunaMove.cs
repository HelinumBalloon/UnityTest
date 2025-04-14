using UnityEngine;
using System.Collections;
public class TunaMove : MonoBehaviour
{
    private GameObject diver;
    private Vector3 direction;
    private int moveSpeed;
    private bool isFrozen;
    [SerializeField] private Animator animator;
    [SerializeField] private AnimationCurve YVelocityCurve;
    [SerializeField] private Rigidbody2D tunaBody;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        diver = GameObject.FindGameObjectWithTag("Diver");
        StartCoroutine(SpeedChange());
        tunaBody = GetComponent<Rigidbody2D>();
    }
    
    void FixedUpdate()
    {
        if (isFrozen)
        {
            return;
        }
        direction = transform.position - diver.transform.position;
        transform.position += (Vector3.left * moveSpeed) * Time.fixedDeltaTime;
		if (transform.position.x < -20f || Mathf.Abs(transform.position.y) > 15f)
        {
            Destroy(gameObject);
        }
    }
    IEnumerator SpeedChange()
    {
        while (true)
        {
            moveSpeed = Random.Range(12, 20);
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
        isFrozen = true;
        tunaBody.constraints = RigidbodyConstraints2D.FreezeAll;
        animator.SetBool("Alive", false);
        yield return new WaitForSeconds(0.6f);
        Destroy(gameObject);
    }
}
