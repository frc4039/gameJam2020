using UnityEngine.UI;
using UnityEngine;

public class ShowPoints : MonoBehaviour
{
    public Text text1;
    public Text text2;
    private void Update()
    {
        text1.text = FindObjectOfType<manager>().player1Points.ToString();
        text2.text = FindObjectOfType<manager>().player2Points.ToString();
    }
}
