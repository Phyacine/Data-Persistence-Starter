using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class PlayerDataHandler : MonoBehaviour
{

    public static PlayerDataHandler instance;

    public string currentPlayer;
    public string topPlayer;
    public int topScore;
    public int currentScore;

    // Start is called before the first frame update
    void Start()
    {
        if(instance != null)
        {
            Destroy(instance);
        }
        instance = this;
        DontDestroyOnLoad(gameObject);

        LoadScore();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    [System.Serializable]
    class SaveData
    {
        public int TopScore;
        public string TopPlayerName;
    }
    public void SaveScore()
    {
        SaveData data = new SaveData();
        data.TopScore = topScore;
        data.TopPlayerName = topPlayer;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);

    }

    public void LoadScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            topScore = data.TopScore;
            topPlayer = data.TopPlayerName;
        }
    }
}
