using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleSystem : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void StartGame(){
        SceneManager.LoadScene("GameScene");
    }

    public void EndGame(){
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #elif UNITY_WEBPLAYER
            Application.OpenURL("http://www.yahoo.co.jp/");
        #else
            Application.Quit();
        #endif
    }

    public void MoveManual(){
        SceneManager.LoadScene("Manual");
    }

    public void BackManual()
    {
        SceneManager.LoadScene("Title");
    }

}
