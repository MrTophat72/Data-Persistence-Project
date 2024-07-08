using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;

public class AllManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static AllManager Instance;
    public string playerName;
    public int playerScore;
    public string highScoreName;
    public int highScore;
    [SerializeField] TextMeshProUGUI highScoreText;
    private void Awake()
    {
        if (Instance != null)
        {

            Destroy(gameObject);
            ShowHighScore();
            return;
            
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadName();
        ShowHighScore();
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

    [System.Serializable]
    class SaveData
    {
        public string name;
        public int highScore;
    }

    public void SaveName()
    {
        SaveData data = new SaveData();
            data.name = highScoreName;
            data.highScore = highScore;
            string json = JsonUtility.ToJson(data);
            File.WriteAllText(Application.persistentDataPath + "/SavedData.json", json);
    }

    public void LoadName()
    {
        string path = Application.persistentDataPath + "/SavedData.json";
        
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            if (data.name != null)
            {
                highScore = data.highScore;
                highScoreName = data.name;
            }
        } 
        
    }

    
}
