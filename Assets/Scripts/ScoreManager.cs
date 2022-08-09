using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    public int bestScore = 0;
    public string bestScoreName = "null";
    public string playerName;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        LoadData();
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void SetPlayerName( string playerName_)
    {
        this.playerName = playerName_;
        Debug.Log(playerName_);
    }

    [System.Serializable]
    class SavedData
    {
        public int bestScore;
        public string bestScoreName;
        public string playerName;
    }

    public void SaveData()
    {
        SavedData data = new SavedData();
        data.bestScore = bestScore;
        data.bestScoreName = bestScoreName;
        data.playerName = playerName;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "savefile.json", json);
    }

    public void LoadData()
    {
        string path = Application.persistentDataPath + "savefile.json";

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SavedData data = JsonUtility.FromJson<SavedData>(json);

            bestScore = data.bestScore;
            bestScoreName = data.bestScoreName;
            playerName = data.playerName;
        }
    }
}
