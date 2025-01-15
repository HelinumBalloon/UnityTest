using UnityEngine;
using System.Collections;
public class CodMove : MonoBehaviour
{
    private float moveSpeed;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(SpeedChange());
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += (Vector3.left * moveSpeed) * Time.deltaTime;
    }
    IEnumerator SpeedChange()
    {
        moveSpeed = Random.Range(2f, 5f);
        yield return new WaitForSeconds(0.5f);
    }
}
