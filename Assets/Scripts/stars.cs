using UnityEngine;

public class stars : MonoBehaviour
{
    public Transform[] stars1;
    public Color normalColor;
    public Color selectedColor;
    public Vector3 cursor;
    public LineRenderer drawingLine;
    public bool clicking;

    Camera mainCamera;
    Transform transform1;
    LineRenderer line;
    bool lastFrameClicking;
    Vector3 defaultScale;
    private void Start()
    {
        defaultScale = stars1[0].localScale;
        mainCamera = Camera.main;
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
            newPosition.z = 0;
            pos.position = newPosition;
        }
    }
    private void Update()
    {
        Transform selected = stars1[0];
        float distance = Vector3.Distance(cursor, stars1[0].position);

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

        if (clicking && !lastFrameClicking)
        {
            line = Instantiate(drawingLine);
            transform1 = selected;
        }
        if (clicking)
        {
            line.SetPosition(0, transform1.position);
            line.SetPosition(1, cursor);
            line.startColor = normalColor;
            line.endColor = line.startColor;
        }
        if (!clicking && lastFrameClicking)
        {
            Destroy(line.gameObject);
            if (!transform1.Equals(selected))
            {
                //for now, need actual string with physics
                LineRenderer renderer = Instantiate(drawingLine);
                renderer.SetPosition(0, transform1.position);
                renderer.SetPosition(1, selected.position);
                renderer.startColor = normalColor;
                renderer.endColor = renderer.startColor;
                Destroy(renderer.gameObject, 5);
            }
        }
        lastFrameClicking = clicking;
    }
    void select(Transform transform)
    {
        transform.localScale = defaultScale * 1.2f;
        transform.GetComponent<SpriteRenderer>().color = selectedColor;
    }
    void deSelect(Transform transform)
    {
        transform.localScale = defaultScale;
        transform.GetComponent<SpriteRenderer>().color = normalColor;
    }
}
