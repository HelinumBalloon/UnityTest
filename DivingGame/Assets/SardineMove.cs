using UnityEngine;

public class SardineMove : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float frequency = 5f;
    public float amplitude = 5f;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float offset = amplitude * Mathf.Sin(Time.time * frequency);
        transform.position += (Vector3.left * moveSpeed + Vector3.up * offset) * Time.deltaTime;
    }
}
