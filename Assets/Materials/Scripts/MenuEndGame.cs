using TMPro;
using UnityEngine;
using YG;

public class MenuEndGame : MonoBehaviour
{
    public static bool isEnd = false;
    public Hook hook;
    public GameObject[] buttons;
    public float speed = 1f;
    public RectTransform rectTransform;
    public Transform targetPosition;

    public TMP_Text bestScoreText;
    public TMP_Text bestScoreMenuText;

    private void Start()
    {
        isEnd = false;
        rectTransform = GetComponent<RectTransform>();
        Canvas canvas = GetComponentInParent<Canvas>();
        
        bestScoreMenuText.text = YandexGame.savesData.bestScore.ToString();
    }

    

    public void GameOver()
    {
        bestScoreText.text = YandexGame.savesData.bestScore.ToString();
        if (hook.score > YandexGame.savesData.bestScore)
        {
            YandexGame.savesData.bestScore = hook.score;
            YandexGame.SaveProgress();
            YandexGame.NewLeaderboardScores("Record", hook.score);

        }
        hook.gameObject.SetActive(false);
        foreach (GameObject button in buttons)
        {
            button.SetActive(false);
        }
        transform.SetAsLastSibling();
        //rectTransform.position = Vector2.Lerp(rectTransform.anchoredPosition, targetPosition, speed * Time.deltaTime);
        rectTransform.position = targetPosition.position;

    }
}
