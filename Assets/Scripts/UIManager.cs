using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    [SerializeField] private TextMeshProUGUI pointsText;
    [SerializeField] public Image NextLvlBackground;
    [SerializeField] private TextMeshProUGUI levelTextScore;
    [SerializeField] private Button NextSceneButton;
    [SerializeField] private TextMeshProUGUI EndScreenScore;
    [SerializeField] private Image endImage;
    internal List<int> LevelScores =  new List<int>();
    private int score;
    private int colorCount;
    private string currentScene;
    private string sceneToLoad;
    private void Awake()
    {
        Instance = this;
    }
    public void fetchScoreAndColorCount(int score ,int colorCount)
    {
        this.score = score;
        this.colorCount = colorCount;
    }
    public void fetchCurrentSceneAdnSceneToLoad(string currentScene, string sceneToLoad)
    {
        this.currentScene = currentScene;
        this.sceneToLoad = sceneToLoad;
    }
    private void Start()
    {
        NextLvlBackground.gameObject.SetActive(false);
        levelTextScore.gameObject.SetActive(false);
        NextSceneButton.gameObject.SetActive(false);
        EndScreenScore.gameObject.SetActive(false);
        endImage.gameObject.SetActive(false);
        UpdatePoints(0);
    }
    public void UpdatePoints(int points)
    {
        pointsText.text = $"Points: {points}";
    }
    public void ShowEndLevelScreen()
    {
        score += (colorCount+1);
        LevelScores.Add(score);
        NextLvlBackground.gameObject.SetActive(true);
        levelTextScore.gameObject.SetActive(true);
        NextSceneButton.gameObject.SetActive(true);
        pointsText.gameObject.SetActive(false);
        SceneManager.UnloadSceneAsync(currentScene);
        PlayerUIManger.instance.colorsPanel.SetActive(false);
        StartCoroutine(animScore());
    }
    IEnumerator animScore()
    {
        float lerpDuration = 0.03f*score;
        float timeElapsed = 0;
        while (Time.deltaTime < lerpDuration)
        {
            levelTextScore.text = $"Score : {Math.Round(Mathf.Lerp(0, score, timeElapsed/lerpDuration),2)}";
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        levelTextScore.text = $"Score: {score}";
    }
    public void ShowEndScreen()
    {
        float scoreSum = 0;
        foreach (var v in LevelScores)
            scoreSum += v;
        EndScreenScore.gameObject.SetActive(true);
        endImage.gameObject.SetActive(true);
        EndScreenScore.text = $"Final Score: {scoreSum}";
    }
    public void sceneSwitcher()
    {
        NextLvlBackground.gameObject.SetActive(false);
        levelTextScore.gameObject.SetActive(false);
        NextSceneButton.gameObject.SetActive(false);
        if (sceneToLoad == "End")
        {
            SceneManager.UnloadSceneAsync("PlayerScene");
            SceneManager.LoadSceneAsync(sceneToLoad, LoadSceneMode.Additive);
            ShowEndScreen();
            pointsText.gameObject.SetActive(false);
        }
        else
        {
            pointsText.gameObject.SetActive(true);
            SceneManager.UnloadSceneAsync("PlayerScene");
            SceneManager.LoadSceneAsync("PlayerScene", LoadSceneMode.Additive);
            SceneManager.LoadSceneAsync(sceneToLoad, LoadSceneMode.Additive);
            GManager.Instance.CallPlayerPosChange();
        }
        UpdatePoints(0);
    }
}
