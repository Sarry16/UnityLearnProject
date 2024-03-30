using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Persistence : MonoBehaviour
{
    public static Persistence Instance;

    public string currentPlayer;
    public string playerName;
    public int score;
    public bool dataFound;

    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    class GameData
    {
        public string name;
        public int score;
    }

    public void SaveData()
    {
        var data = new GameData();
        data.name = currentPlayer;
        data.score = score;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/high.json", json);
    }

    public void LoadData()
    {
        string path = Application.persistentDataPath + "/high.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            var data = JsonUtility.FromJson<GameData>(json);
            playerName = data.name;
            score = data.score;
            dataFound = true;
        } else
        {
            dataFound = false;
        }
    }
}
