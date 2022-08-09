using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuUI : MonoBehaviour
{
    public TextMeshProUGUI bestScoreText;
    public TextMeshProUGUI playerName;

    // Start is called before the first frame update
    void Start()
    {
        bestScoreText.text = "Best Score: " + ScoreManager.Instance.bestScoreName +" - " + ScoreManager.Instance.bestScore;
        playerName.text = ScoreManager.Instance.playerName;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void ExitGame()
    {
        ScoreManager.Instance.SaveData();
        //ScoreManager.Instance.SaveColor();
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
