using UnityEngine;
using UnityEngine.SceneManagement;

public class ManagerScene : MonoBehaviour
{
    public void SceneChanger(string sceneTarget)
    {
        SceneManager.LoadScene(sceneTarget);
    }
}