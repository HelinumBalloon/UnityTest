using UnityEngine;
using System.Collections;
public class CodMove : MonoBehaviour
{
    private GameObject diver;
    private Vector3 direction;
    private int moveSpeed;
    private int bType;
    [SerializeField] private Animator animator;
    [SerializeField] private AnimationCurve YVelocityCurve;
    [SerializeField] private Rigidbody2D codBody;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        diver = GameObject.FindGameObjectWithTag("Diver");
        StartCoroutine(SpeedChange());
        bType = Random.Range(0, 2);
    }

    void FixedUpdate()
    {
        direction = transform.position - diver.transform.position;
        transform.position += (Vector3.left * moveSpeed) * Time.fixedDeltaTime;
        //Mathf.Min prevents having to account for extremely large ratios in the animation curve
        if (bType == 0)
        {
            codBody.AddForce(-transform.up * YVelocityCurve.Evaluate(Mathf.Min((direction.y/direction.x),10f)) * Time.fixedDeltaTime);
        }
        else
        {
            codBody.AddForce(transform.up * YVelocityCurve.Evaluate(Mathf.Min((direction.y/direction.x),10f)) * Time.fixedDeltaTime);
        }
        if (transform.position.x < -20f || Mathf.Abs(transform.position.y) > 15f)
        {
            Destroy(gameObject);
        }
    }
    IEnumerator SpeedChange()
    {
        while (true)
        {
            moveSpeed = Random.Range(5, 9);
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
