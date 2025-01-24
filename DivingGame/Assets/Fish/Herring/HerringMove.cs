using UnityEngine;
using System.Collections;
public class HerringMove : MonoBehaviour
{
    private GameObject diver;
    private float distance;
    private int bType;
    private float YBenchmark;
    [SerializeField] private Animator animator;
    [SerializeField] private AnimationCurve XVelocityCurve;
    [SerializeField] private AnimationCurve YVelocityCurve;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        diver = GameObject.FindGameObjectWithTag("Diver");
        bType = Random.Range(0, 2);
    }
    void FixedUpdate()
    {
        distance = Vector3.Distance(transform.position, diver.transform.position);
        transform.position += (Vector3.left * XVelocityCurve.Evaluate(distance)) * Time.fixedDeltaTime;
        if (distance < 5f)
        {
            StartCoroutine(YMovement());
        }
        if (transform.position.x < -20f || Mathf.Abs(transform.position.y) > 15f)
        {
            Destroy(gameObject);
        }
    }

    IEnumerator YMovement()
    {
        YBenchmark = Random.Range(0f, 0.75f);
        if (bType == 0)
        {
            transform.position += (Vector3.up * YVelocityCurve.Evaluate(YBenchmark+Time.fixedDeltaTime));
        }
        else
        {
            transform.position += (Vector3.down * YVelocityCurve.Evaluate(YBenchmark+Time.fixedDeltaTime));
        }
        yield return new WaitForSeconds(0.25f);
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
