using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class manager : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject endMenuLoss;
    public GameObject endMenuWin;
    public KeyCode pauseKey = KeyCode.Escape;
    public GameObject cursor1;
    public GameObject cursor2;
    public GameObject sceneTransition;
    public bool paused;
    public int player1Points;
    public int player2Points;
    public AudioClip winClip;
    public AudioClip lossClip;
    public AudioClip pauseClip;
    public AudioClip resumeClip;
    bool gameEnded = false;
    void Update()
    {
        if (Input.GetKeyDown(pauseKey) && !paused && !gameEnded)
            pauseGame();
        else if (Input.GetKeyDown(pauseKey) && paused && !gameEnded)
            resumeGame();
    }
    public void pauseGame()
    {
        paused = true;
        Time.timeScale = 0;
        cursor1.SetActive(false);
        cursor2.SetActive(false);
        pauseMenu.SetActive(true);
        FindObjectOfType<soundPlayer>().playSound(pauseClip);
    }
    public void resumeGame()
    {
        paused = false;
        Time.timeScale = 1;
        cursor1.SetActive(true);
        cursor2.SetActive(true);
        pauseMenu.SetActive(false);
        FindObjectOfType<soundPlayer>().playSound(resumeClip);
    }
    public void mainMenu()
    {
        Invoke("loadMenu", .5f);
        sceneTransition.SetActive(true);
        Time.timeScale = 1;
        gameEnded = true;
    }
    void loadMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void gameEndLoss()
    {
        Time.timeScale = 0;
        cursor1.SetActive(false);
        cursor2.SetActive(false);
        endMenuLoss.SetActive(true);
        gameEnded = true;
        FindObjectOfType<soundPlayer>().playSound(lossClip);
    }
    public void gameEndWin()
    {
        Time.timeScale = 0;
        cursor1.SetActive(false);
        cursor2.SetActive(false);
        endMenuWin.SetActive(true);
        gameEnded = true;
        Text text = endMenuWin.GetComponentInChildren<Text>();
        if (player1Points > player2Points)
        {
            text.color = new Color(1, 0, 0);
            text.text = "Red Won!";
        }
        if (player1Points < player2Points)
        {
            text.color = new Color(0, 0, 1);
            text.text = "Blue Won!";
        }
        if (player1Points == player2Points)
        {
            text.color = new Color(1, 1, 1);
            text.text = "Draw!";
        }

        FindObjectOfType<soundPlayer>().playSound(winClip);
    }
    public void nextLevel()
    {
        Invoke("loadNextLevel", .5f);
        sceneTransition.SetActive(true);
        Time.timeScale = 1;
        gameEnded = true;
    }
    void loadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void sameLevel()
    {
        Invoke("loadSameLevel", .5f);
        sceneTransition.SetActive(true);
        Time.timeScale = 1;
        gameEnded = true;
    }
    void loadSameLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
