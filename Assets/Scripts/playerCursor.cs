using UnityEngine;

public class playerCursor : MonoBehaviour
{
    public KeyCode upKey = KeyCode.W;
    public KeyCode rightKey = KeyCode.D;
    public KeyCode downKey = KeyCode.S;
    public KeyCode leftKey = KeyCode.A;
    public KeyCode stringDrawKey = KeyCode.Space;
    public stars output;
    public float speed;

    bool touch = false;
    void Update()
    {
        output.clicking = Input.GetKey(stringDrawKey);

        float x = 0;
        float y = 0;

        if (Input.GetKey(downKey))
            y = -1;
        if (Input.GetKey(upKey))
            y = 1;
        if (Input.GetKey(leftKey))
            x = -1;
        if (Input.GetKey(rightKey))
            x = 1;
        if (Input.GetKey(leftKey) && Input.GetKey(rightKey))
            x = 0;
        if (Input.GetKey(downKey) && Input.GetKey(upKey))
            y = 0;

        y *= Time.unscaledDeltaTime * speed;
        x *= Time.unscaledDeltaTime * speed;

        if (Input.touchCount > 0)
        {
            touch = true;
            Vector3 position = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
            transform.position = position;
            output.clicking = true;
        }
        else if (touch)
        {
            output.clicking = false;
        }

        transform.position += new Vector3(x, y, 0);
        output.cursor = transform.position;

        float screenX = Screen.width;
        float screenY = Screen.height;
        float screenRatio = screenX / screenY;

        if (transform.position.y > Camera.main.orthographicSize)
            transform.position = new Vector3(transform.position.x, Camera.main.orthographicSize, 1);
        else if (transform.position.y < -Camera.main.orthographicSize)
            transform.position = new Vector3(transform.position.x, -Camera.main.orthographicSize, 1);
        if (transform.position.x > Camera.main.orthographicSize * screenRatio)
            transform.position = new Vector3(Camera.main.orthographicSize * screenRatio, transform.position.y, 1);
        else if (transform.position.x < -Camera.main.orthographicSize * screenRatio)
            transform.position = new Vector3(-Camera.main.orthographicSize * screenRatio, transform.position.y, 1);
    }
}
