using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject panelStartGame;
    public GameObject panelGamePlay;
    public GameObject panelPauseGame;
    public GameObject panelGameOver;
    public Text txtScore;
    public Text txtScoreEnd;
    public Text txtBestScore;
    // Start is called before the first frame update
    void Start()
    {
        panelStartGame.SetActive(true);
        panelGamePlay.SetActive(false);
        panelPauseGame.SetActive(false);
        panelGameOver.SetActive(false);
        GameManager.Ins.state = GameState.Starting;
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void StartGame()
    {
        panelStartGame.SetActive(false);
        
        panelGamePlay.SetActive(true);
        GameManager.Ins.state = GameState.Playing;
        Invoke("GameInit", 1f);
        
        
    }
    public void GameInit()
    {
        GameManager.Ins.PlatformInit();
    }
    public void GetScore()
    {
        txtScore.text = "Score: " + GameManager.Ins.Score;
    }
    public void PauseGame()
    {
        panelPauseGame.SetActive(true);
        Time.timeScale = 0;
    }
    public void EndGame()
    {
        panelGameOver.SetActive(true);
        GameManager.Ins.state = GameState.Gameover;
        txtScoreEnd.text= GameManager.Ins.Score.ToString();
        int bestScore = PlayerPrefs.GetInt(PrefKey.BestScore.ToString());
        txtBestScore.text = bestScore.ToString();
        Time.timeScale = 0;
    }
    public void Resume()
    {
        panelPauseGame.SetActive(false);
        Time.timeScale = 1;
    }
    public void RePlay()
    {
        SceneManager.LoadScene(0);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
