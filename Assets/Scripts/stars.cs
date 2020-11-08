using UnityEngine;

public class stars : MonoBehaviour
{
    public Transform[] stars1;
    public Color normalColor;
    public Color selectedColor;
    public Vector3 cursor;
    public Camera mainCamera;

    Transform transform1;
    private void Start()
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
            transform1 = selected;
        }
        if (Input.GetMouseButton(0))
        {
            //temporary
            Debug.DrawLine(transform1.position, cursor);
        }
        if (Input.GetMouseButtonUp(0))
        {
            if (!transform1.Equals(selected))
            {
                Debug.DrawLine(transform1.position, selected.position, normalColor, 10);
            }
        }
    }
}
