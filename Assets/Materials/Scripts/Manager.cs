using UnityEngine;
using UnityEngine.SceneManagement;
using YG;

public class Manager : MonoBehaviour
{
    public void RestartGame()
    {
        SceneManager.LoadSceneAsync("Main");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            YandexGame.ResetSaveProgress();
        }
    }
}
