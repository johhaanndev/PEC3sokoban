using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void GoToLevelsMenu()
    {
        SceneManager.LoadScene("LevelsMenu");
    }

    // 1 method for each level scene
    public void Exit()
    {
        Application.Quit();
    }

    public void GoToLevel1()
    {
        SceneManager.LoadScene("level1");
    }

    public void GoToLevel2()
    {
        SceneManager.LoadScene("level2");
    }

    public void GoToLevel3()
    {
        SceneManager.LoadScene("level3");
    }

    public void GoToLevel4()
    {
        SceneManager.LoadScene("level4");
    }

    public void GoToLevel5()
    {
        SceneManager.LoadScene("level5");
    }

    public void GoToLevel6()
    {
        SceneManager.LoadScene("level6");
    }

    public void GoToLevel7()
    {
        SceneManager.LoadScene("level7");
    }

    public void GoToLevel8()
    {
        SceneManager.LoadScene("level8");
    }

    public void GoToLevel9()
    {
        SceneManager.LoadScene("level9");
    }

    public void GoToLevel10()
    {
        SceneManager.LoadScene("level10");
    }
}
