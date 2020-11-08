using UnityEngine;

public class stringPhysics : MonoBehaviour
{
    public Rigidbody2D ball;
    public float acceleration;
    LineRenderer lineRenderer;
    BoxCollider2D boxCollider;
    bool canAddForce;
    float force = 1;
    private void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        boxCollider = GetComponent<BoxCollider2D>();
    }
    void OnTriggerEnter2D()
    {
        canAddForce = true;
        Invoke("cantAddForce", 1f);
        Destroy(boxCollider);
    }
    void cantAddForce()
    {
        Destroy(gameObject);
    }
    private void LateUpdate()
    {
        if (canAddForce)
        {
            force += acceleration * Time.deltaTime;
            ball.AddForce(new Vector2(0, force) * Time.deltaTime);
            lineRenderer.SetPosition(1, new Vector3(ball.transform.position.x, ball.transform.position.y - .65f, 1));
        }
    }
}
