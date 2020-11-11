using UnityEngine;

public class stars : MonoBehaviour
{
    public Transform[] stars1;
    public Color normalColor;
    public Color selectedColor;
    public Vector3 cursor;
    public LineRenderer drawingLine;
    public LineRenderer stringLine;
    public string ballObjectName;
    public bool clicking;
    public bool generatePositionsAtStartOfGame;

    Camera mainCamera;
    Transform transform1;
    LineRenderer line;
    LineRenderer stringRenderer;
    bool lastFrameClicking;
    Vector3 defaultScale;
    private void Start()
    {
        defaultScale = stars1[0].localScale;
        mainCamera = Camera.main;
        if (generatePositionsAtStartOfGame)
            StarPositions();
    }
    public void StarPositions()
    {
        //generate star positions
        float x = Screen.width;
        float y = Screen.height;

        float screenRatio = x / y;

        foreach (Transform pos in stars1)
        {
            pos.GetComponent<SpriteRenderer>().color = normalColor;
            Vector3 newPosition;
            newPosition.x = Random.Range(-mainCamera.orthographicSize * screenRatio, mainCamera.orthographicSize * screenRatio);
            newPosition.y = Random.Range(-mainCamera.orthographicSize, mainCamera.orthographicSize);
            newPosition.z = 1;
            pos.position = newPosition;
        }
    }
    private void Update()
    {
        //selected star transform
        Transform selected = stars1[0];
        float distance = Vector3.Distance(cursor, stars1[0].position);
        //choosing closest star to cursor
        foreach (Transform pos in stars1)
        {
            deSelect(pos);
            float newDistance = Vector3.Distance(cursor, pos.position);
            if (newDistance < distance)
            {
                distance = newDistance;
                selected = pos;
            }
        }
        select(selected);
        //checking if a string of this color exists
        bool canDraw;
        if (stringRenderer == null)
            canDraw = true;
        else
            canDraw = false;

        //making temporary preview line
        if (clicking && !lastFrameClicking && canDraw)
        {
            if (line == null)
                line = Instantiate(drawingLine);
            transform1 = selected;
            
        }
        if (clicking && canDraw)
        {
            if (line != null)
            {
                line.SetPosition(0, transform1.position);
                line.SetPosition(1, cursor);
                line.startColor = normalColor;
                line.endColor = line.startColor;
            }
        }
        if (!clicking && lastFrameClicking && canDraw)
        {
            if (line != null)
                Destroy(line.gameObject);
            if (!transform1.Equals(selected))
            {
                //making bouncing string
                stringRenderer = Instantiate(stringLine);
                Vector3 midPoint = new Vector3((transform1.position.x + selected.position.x) / 2, (transform1.position.y + selected.position.y) / 2, 1);
                stringRenderer.transform.position = midPoint;
                stringRenderer.GetComponent<BoxCollider2D>().size = new Vector2(Vector3.Distance(transform1.position, selected.position), stringRenderer.GetComponent<BoxCollider2D>().size.y);
                stringRenderer.transform.LookAt(transform1);
                stringRenderer.transform.Rotate(0, 90, 0);
                stringRenderer.SetPosition(0, transform1.position);
                stringRenderer.SetPosition(1, midPoint);
                stringRenderer.SetPosition(2, selected.position);
                stringRenderer.startColor = normalColor;
                stringRenderer.endColor = stringRenderer.startColor;
                stringRenderer.GetComponent<stringPhysics>().ball = GameObject.Find(ballObjectName).GetComponent<Rigidbody2D>();
            }
        }
        lastFrameClicking = clicking;
    }
    void select(Transform transform)
    {
        //selecting a star
        transform.localScale = defaultScale * 1.2f;
        transform.GetComponent<SpriteRenderer>().color = selectedColor;
    }
    void deSelect(Transform transform)
    {
        transform.localScale = defaultScale;
        transform.GetComponent<SpriteRenderer>().color = normalColor;
    }
}
