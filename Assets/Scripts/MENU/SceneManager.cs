using UnityEngine;
using UnityEngine.SceneManagement;

public class ManagerScene : MonoBehaviour
{
    public void SceneChanger(string sceneTarget)
    {
        SceneManager.LoadScene(sceneTarget);
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