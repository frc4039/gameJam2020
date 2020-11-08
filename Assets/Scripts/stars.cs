using UnityEngine;

public class stars : MonoBehaviour
{
    public Transform[] stars1;
    public Color normalColor;
    public Color selectedColor;
    public Vector3 cursor;
    public Camera mainCamera;
    public LineRenderer drawingLine;

    Transform transform1;
    LineRenderer line;
    public void Start()
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
        //temporary, multiple inputs required
        cursor = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        cursor.z = 0;

        Transform selected = stars1[0];
        float distance = Vector3.Distance(cursor, stars1[0].position);

        foreach (Transform pos in stars1)
        {
            pos.GetComponent<SpriteRenderer>().color = normalColor;
            float newDistance = Vector3.Distance(cursor, pos.position);
            if (newDistance < distance)
            {
                distance = newDistance;
                selected = pos;
            }
        }
        selected.GetComponent<SpriteRenderer>().color = selectedColor;

        if (Input.GetMouseButtonDown(0))
        {
            line = Instantiate(drawingLine);
            transform1 = selected;
        }
        if (Input.GetMouseButton(0))
        {
            line.SetPosition(0, transform1.position);
            line.SetPosition(1, cursor);
            line.startColor = normalColor;
            line.endColor = line.startColor;
        }
        if (Input.GetMouseButtonUp(0))
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
    }
}
