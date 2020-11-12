using UnityEngine.Events;
using UnityEngine;

public class endGame : MonoBehaviour
{
    public float endLine;
    public UnityEvent endGameEvent;
    void Update()
    {
        if (transform.position.y < endLine)
        {
            endGameEvent.Invoke();
            GetComponent<stayOnScreen>().arrow.SetActive(false);
            Destroy(gameObject);
        }
    }
}
