using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionManager:MonoBehaviour
{


    public static void ToGame()
    {
        SceneManager.LoadScene("GameScene", LoadSceneMode.Single);
    }

    public static void ToCredits()
    {
        SceneManager.LoadScene("EndingScene", LoadSceneMode.Single);
    }


    public static void QuitGame()
    {
        Application.Quit();
    }
}