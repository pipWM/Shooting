using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour {
    public int score = 0;
    public int missCount = 5;
    public bool GameOverIs = false;
    private GameObject ScoreText;
    private GameObject MissText;
    private GameObject GameOverText;
    private GameObject RetryButton;
    private GameObject TitleButton;


    // Use this for initialization
    void Start () {
        ScoreText = GameObject.Find("Score");
        MissText = GameObject.Find("Miss");
        GameOverText = GameObject.Find("GameOver");
        RetryButton = GameObject.Find("RetryButton");
        TitleButton = GameObject.Find("TitleButton");
        RetryButton.SetActive(false);
        TitleButton.SetActive(false);
        if (ScoreText == null) Debug.Log("Null");
	}
	
	// Update is called once per frame
	void Update () {
        ScoreText.GetComponent<Text>().text = "Score: " + score.ToString("D6");
        MissText.GetComponent<Text>().text =  "Miss:            " + missCount.ToString();
        if(missCount <= 0){
            GameOver();
        }
	}

    public void AddScore (){
        this.score += 100;
    }

    public void Retry(){
        SceneManager.LoadScene("GameScene");
    }

    public void TitleBack(){
        SceneManager.LoadScene("Title");
    }

    public void Miss(){
        if(!GameOverIs)this.missCount -= 1;
    }

    void GameOver(){
        GameOverIs = true;
        GameOverText.GetComponent<Text>().text = "GameOver";
        RetryButton.SetActive(true);
        TitleButton.SetActive(true);
    }
}
