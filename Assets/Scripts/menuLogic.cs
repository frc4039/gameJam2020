using UnityEngine.SceneManagement;
using UnityEngine;

public class menuLogic : MonoBehaviour
{
    public GameObject sceneTransition;
    public void play()
    {
        sceneTransition.SetActive(true);
        Invoke("loadScene", .5f);
    }
    public void quit()
    {
        Application.Quit();
    }
    void loadScene()
    {
        SceneManager.LoadSceneAsync(1);
    }
}
