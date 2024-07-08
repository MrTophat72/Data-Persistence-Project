using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;


#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuUIHandeler : MonoBehaviour
{
    [SerializeField] TMP_InputField nameText;
    [SerializeField] TextMeshProUGUI highScoreText;
    public void StartNew()
    {
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {

#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }

    public void SetName()
    {
        AllManager.Instance.playerName = nameText.text;
    }

    public void ShowHighScore()
    {
        string highScoreName = AllManager.Instance.highScoreName;
        if (highScoreName != null)
        {
            highScoreText.text = "HighScore: \n" + AllManager.Instance.highScoreName + ": " + AllManager.Instance.highScore;
        }
        else
        {
            highScoreText.text = "HighScore";
        }
    }
}
