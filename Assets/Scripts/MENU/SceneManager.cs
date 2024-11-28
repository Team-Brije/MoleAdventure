using UnityEngine;
using UnityEngine.SceneManagement;

public class ManagerScene : MonoBehaviour
{
    int levelint;
    public GameDataController controller;
    public void SceneChanger(string sceneTarget)
    {
        SceneManager.LoadScene(sceneTarget);
    }

    public void ContinueGame()
    {
        int level = controller.LoadLevel();
        switch (level)
        {
            case 0:
                SceneManager.LoadScene("NIVEL1");
                break;
            case 1:
                SceneManager.LoadScene("NIVEL2");
                break;
            case 2:
                SceneManager.LoadScene("NIVEL3");
                break;
            default:
                SceneManager.LoadScene("NIVEL1");
                break;
        }
    }

    public void SwitchObject(GameObject obj)
    {
        gameObject.SetActive(false);
        obj.SetActive(true);
    }

    public void QuitApp()
    {
        Application.Quit();
    }
}