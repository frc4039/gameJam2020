using UnityEngine.Rendering.PostProcessing;
using UnityEngine;

public class applySettings : MonoBehaviour
{
    public PostProcessProfile normal;
    public PostProcessProfile off;
    void Start()
    {
        applyPostProcessing();
        applySensitivity();
    }
    public void applyPostProcessing()
    {
        if (PlayerPrefs.GetInt("postProcessing") == 0)
            Camera.main.GetComponent<PostProcessVolume>().profile = off;
        else
            Camera.main.GetComponent<PostProcessVolume>().profile = normal;
    }
    public void applySensitivity()
    {
        foreach(playerCursor cursor in Resources.FindObjectsOfTypeAll(typeof(playerCursor)))
        {
            cursor.speed = PlayerPrefs.GetInt("sensitivity");
        }
    }
}
