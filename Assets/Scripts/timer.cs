using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class timer : MonoBehaviour
{
    public int timerTime;
    public int lowTime;
    public Color normalColor;
    public Color lowColor;
    public Text timerText;
    public UnityEvent onTimerZero;

    float time;
    void Start()
    {
        time = timerTime;
        timerText.color = normalColor;

        if (lowTime > timerTime)
            lowTime = timerTime;
    }

    void Update()
    {
        if (time > 0)
        {
            time -= Time.deltaTime;
            timerText.text = time.ToString("0");
        }

        if (time.ToString("0") == lowTime.ToString("0"))
            timerText.color = lowColor;

        if (time <= 0)
        {
            //Debug.Log("Time's Up!");
            onTimerZero.Invoke();
            Destroy(gameObject);
        }
    }
}
