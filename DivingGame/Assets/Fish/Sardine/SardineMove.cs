using UnityEngine;
// For coroutine use.
using System.Collections;
using System.Collections.Generic;
public class SardineMove : MonoBehaviour
{
    private Vector3 diverVelocity;
    private float scaleFactor;
    private float frequency = 5f;
    private float amplitude = 2f;
    [SerializeField] private Animator animator;
    [SerializeField] private AnimationCurve XVelocityCurve;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        scaleFactor = Random.Range(4, 8);
        StartCoroutine(PredatorCheck());
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        diverVelocity = GameObject.FindGameObjectWithTag("Diver").GetComponent<Rigidbody2D>().linearVelocity;
        float offset = amplitude * Mathf.Sin(Time.time * frequency);
        transform.position += (Vector3.left * scaleFactor * XVelocityCurve.Evaluate(diverVelocity.x)) * Time.fixedDeltaTime;
        transform.position += (Vector3.up * offset) * Time.fixedDeltaTime;
        if (transform.position.x < -20f || Mathf.Abs(transform.position.y) > 15f)
        {
            Destroy(gameObject);
        }
    }
    IEnumerator PredatorCheck()
    {
        while (true)
        {
            GameObject[] predatorList = GameObject.FindGameObjectsWithTag("BasicPredator");
            if (predatorList.Length > 0)
            {
                List<float> predatorDistances = new List<float>();
                foreach (GameObject predator in predatorList)
                {
                    float predatorDistance = Vector3.Distance(predator.transform.position, transform.position);
                    predatorDistances.Add(predatorDistance);
                }
                float minPredatorDistance = Mathf.Min(predatorDistances.ToArray());
                if (minPredatorDistance < 8f)
                {
                    scaleFactor *= 1.3f;
                }
            }

            yield return new WaitForSeconds(1f);
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
