using UnityEngine;
using System.Collections;
public class AnchovyMove : MonoBehaviour
{
    private GameObject diver;
    private Vector3 diverVelocity;
    private float distance;
    private float YFactor;
    private int bType;
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
        diverVelocity = diver.GetComponent<Rigidbody2D>().linearVelocity;
        YFactor = distance/(diverVelocity.y + 1f);
        transform.position += (Vector3.left * XVelocityCurve.Evaluate(distance)) * Time.deltaTime;
        if (bType == 0)
        {
            transform.position += (Vector3.up * YVelocityCurve.Evaluate(YFactor)) * Time.deltaTime;
        }
        else
        {
            transform.position += (Vector3.down * YVelocityCurve.Evaluate(YFactor)) * Time.deltaTime;
        }
        if (transform.position.x < -20f || Mathf.Abs(transform.position.y) > 15f)
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
