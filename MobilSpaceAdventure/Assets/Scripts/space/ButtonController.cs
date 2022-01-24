using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
    public void Menu()
    {
        SceneManager.LoadScene("menu");
    }

    public void Game()
    {
        SceneManager.LoadScene("game");
    }

    public void Exit()
    {
        Application.Quit();
    }
}
