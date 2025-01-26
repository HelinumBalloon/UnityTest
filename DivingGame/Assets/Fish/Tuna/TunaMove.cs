using UnityEngine;
using System.Collections;
public class TunaMove : MonoBehaviour
{
    private GameObject diver;
    private Vector3 direction;
    private int moveSpeed;
    [SerializeField] private Animator animator;
    [SerializeField] private AnimationCurve YVelocityCurve;
    [SerializeField] private Rigidbody2D tunaBody;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        diver = GameObject.FindGameObjectWithTag("Diver");
        StartCoroutine(SpeedChange());
    }
    
    void FixedUpdate()
    {
        direction = transform.position - diver.transform.position;
        transform.position += (Vector3.left * moveSpeed) * Time.fixedDeltaTime;
        tunaBody.linearVelocity = Vector3.up * YVelocityCurve.Evaluate(direction.y);
    }
    IEnumerator SpeedChange()
    {
        while (true)
        {
            moveSpeed = Random.Range(10, 15);
            yield return new WaitForSeconds(0.5f);
        }
    }
}
