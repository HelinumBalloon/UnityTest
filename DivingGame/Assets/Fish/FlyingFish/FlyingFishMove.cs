using UnityEngine;
using System.Collections;
public class FlyingFishMove : MonoBehaviour
{
    private int scaleFactor;
    private float amplitude;
    private float frequency;
    [SerializeField] private Animator animator;
    [SerializeField] private AnimationCurve FlyVelocityCurve;
    [SerializeField] private Rigidbody2D flyingFishBody;
    void Start()
    {
        scaleFactor = Random.Range(12, 18);
        amplitude = 20f / transform.position.y;
        frequency = Mathf.Sqrt(transform.position.y);
        StartCoroutine(PredatorCheck());
    }

    void FixedUpdate()
    {
        float offset = amplitude * Mathf.Sin(Time.time * frequency);
        transform.position += (Vector3.left * scaleFactor) * Time.fixedDeltaTime;
        transform.position += (Vector3.up * (offset + scaleFactor/10f)) * Time.fixedDeltaTime;
        if (transform.position.x < -20f || Mathf.Abs(transform.position.y) > 25f)
        {
            Destroy(gameObject);
        }
    }

    IEnumerator PredatorCheck()
    {
        while (true)
        {
            GameObject[] predatorList = GameObject.FindGameObjectsWithTag("BasicPredator");
            flyingFishBody.AddForce(transform.up * predatorList.Length * FlyVelocityCurve.Evaluate(transform.position.y) * Time.fixedDeltaTime);
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
