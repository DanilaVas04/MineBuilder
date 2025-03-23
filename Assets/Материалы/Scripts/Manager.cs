using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    public void RestartGame()
    {
        SceneManager.LoadSceneAsync("Main");
    }
}
