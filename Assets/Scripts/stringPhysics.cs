using UnityEngine;

public class stringPhysics : MonoBehaviour
{
    public Rigidbody2D ball;
    public float acceleration;
    LineRenderer lineRenderer;
    bool canAddForce;
    bool canDestroy = false;
    float force = 1;
    private void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }
    void OnTriggerEnter2D()
    {
        canAddForce = true;
    }
    private void Update()
    {
        if (canAddForce)
        {
            Vector3 midPoint = new Vector3((lineRenderer.GetPosition(0).x + lineRenderer.GetPosition(2).x) / 2, (lineRenderer.GetPosition(0).y + lineRenderer.GetPosition(2).y) / 2, 1);
            if (ball.position.y < midPoint.y)
                canDestroy = true;
            if (ball.position.y > midPoint.y && canDestroy)
            {
                canAddForce = false;
                canDestroy = false;
                Destroy(gameObject);
            }
            force = midPoint.y - ball.position.y;
            ball.AddForce(transform.up * force * Time.deltaTime * acceleration);
            lineRenderer.SetPosition(1, new Vector3(ball.transform.position.x, ball.transform.position.y - .65f, 1));
        }
    }
}
