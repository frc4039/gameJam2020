using UnityEngine;
using UnityEngine.UI;

public class settingsMenu : MonoBehaviour
{
    public Text sensitivityText;
    bool postProcessingBool;
    bool subTitlesBool;

    void Start()
    {
        if (PlayerPrefs.GetInt("postProcessing") == 0)
            postProcessingBool = false; 
        else
            postProcessingBool = true;

        if (PlayerPrefs.GetInt("subTitles") == 0)
            subTitlesBool = false;
        else
            subTitlesBool = true;

        sensitivityText.text = PlayerPrefs.GetInt("sensitivity", 10).ToString();
    }
    public void postProcessing()
    {
        if (postProcessingBool)
        {
            PlayerPrefs.SetInt("postProcessing", 0);
            postProcessingBool = false;
        }
        else if (!postProcessingBool)
        {
            PlayerPrefs.SetInt("postProcessing", 1);
            postProcessingBool = true;
        }
        FindObjectOfType<applySettings>().applyPostProcessing();
    }
    public void subTitles()
    {
        if (subTitlesBool)
        {
            PlayerPrefs.SetInt("subTitles", 0);
            subTitlesBool = false;
        }
        else if (!subTitlesBool)
        {
            PlayerPrefs.SetInt("subTitles", 1);
            subTitlesBool = true;
        }
    }
    public void changeSensitivity(bool up)
    {
        if (up)
            PlayerPrefs.SetInt("sensitivity", PlayerPrefs.GetInt("sensitivity") + 1);
        else
            PlayerPrefs.SetInt("sensitivity", PlayerPrefs.GetInt("sensitivity") - 1);

        if (PlayerPrefs.GetInt("sensitivity") < 10)
            PlayerPrefs.SetInt("sensitivity", 10);
        if (PlayerPrefs.GetInt("sensitivity") > 25)
            PlayerPrefs.SetInt("sensitivity", 25);

        sensitivityText.text = PlayerPrefs.GetInt("sensitivity").ToString();
        FindObjectOfType<applySettings>().applySensitivity();
    }
}
