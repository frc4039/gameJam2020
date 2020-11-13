using UnityEngine;

public class menuStringPhysics : MonoBehaviour
{
    public Rigidbody2D ball;
    public float acceleration;
    LineRenderer lineRenderer;
    bool canAddForce;
    bool canDestroy = false;
    float force = 1;
    Vector3 midPoint;
    private void Start()
    {
        //finding the lineRenderer component
        lineRenderer = GetComponent<LineRenderer>();
        midPoint = lineRenderer.GetPosition(1);
    }
    void OnTriggerEnter2D()
    {
        //when the ball enters the space the string is occupying
        canAddForce = true;
    }
    private void Update()
    {
        if (canAddForce)
        {
            //setting the midpoint of the line to line up with the bottom of the ball
            lineRenderer.SetPosition(1, new Vector3(ball.transform.position.x, ball.transform.position.y - .65f, 1));
            //using y = mx + b to calculate forces
            float X = lineRenderer.GetPosition(0).x;
            float Y = lineRenderer.GetPosition(0).y;
            float M = (lineRenderer.GetPosition(0).y - lineRenderer.GetPosition(2).y) / (lineRenderer.GetPosition(0).x - lineRenderer.GetPosition(2).x);
            float B = Y - M * X;
            //perpendicular line passing through the ball's position
            float x = ball.position.x;
            float y = ball.position.x;
            float b = y - (-1 / M) * x;
            float pointOnStringX;
            float pointOnStringY;
            pointOnStringY = M * ((-1 / M) * x + b) + B;
            pointOnStringX = (pointOnStringY - B) / M;
            float yForX = M * ball.position.x + B;
            if (ball.position.y < yForX)
                canDestroy = true;
            if (ball.position.y > yForX)
                force = -Vector3.Distance(ball.position, new Vector3(pointOnStringX, pointOnStringY, 0));
            else
                force = Vector3.Distance(ball.position, new Vector3(pointOnStringX, pointOnStringY, 0));
            if (ball.position.y > yForX && canDestroy)
            {
                canAddForce = false;
                canDestroy = false;
            }
            ball.AddForce(transform.up * force * Time.deltaTime * acceleration);
        }
        if (!canAddForce)
        {
            lineRenderer.SetPosition(1, midPoint);
        }
    }
}
