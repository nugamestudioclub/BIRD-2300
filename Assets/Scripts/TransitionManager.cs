using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionManager : MonoBehaviour
{


    public void ToGame()
    {
        SceneManager.LoadScene("GameScene", LoadSceneMode.Single);
    }

    public void ToCredits()
    {
        SceneManager.LoadScene("EndingScene", LoadSceneMode.Single);
    }


    public void QuitGame()
    {
        Application.Quit();
    }
}