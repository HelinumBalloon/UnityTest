using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class HerringMove : MonoBehaviour
{
    private GameObject diver;
    private float scaleFactor;
    private float distance;
    private float amplitude;
    private int frequency;
    [SerializeField] private Animator animator;
    [SerializeField] private AnimationCurve XVelocityCurve;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        diver = GameObject.FindGameObjectWithTag("Diver");
        amplitude = Random.Range(1f, 2.5f);
        frequency = Random.Range(2, 6);
        StartCoroutine(PredatorCheck());
        scaleFactor = 1f;
    }
    void FixedUpdate()
    {
        distance = Vector3.Distance(transform.position, diver.transform.position);
        float offset = amplitude * Mathf.Sin(Time.time * frequency);
        transform.position += (Vector3.left * scaleFactor * XVelocityCurve.Evaluate(distance)) * Time.fixedDeltaTime;
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
                if (minPredatorDistance < 10f)
                {
                    scaleFactor *= 1.3f;
                    yield return new WaitForSeconds(1f);
                    scaleFactor /= 1.3f;
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
        yield return new WaitForSeconds(0.6f);
        Destroy(gameObject);
    }
}
