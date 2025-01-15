using UnityEngine;
// For coroutine use.
using System.Collections;
public class SardineMove : MonoBehaviour
{
    private float moveSpeed;
    private float frequency = 5f;
    private float amplitude = 2f;
    
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
    }

    IEnumerator SpeedChange()
    {
        moveSpeed = Random.Range(3f, 8f);
        yield return new WaitForSeconds(0.5f);
    }
}
