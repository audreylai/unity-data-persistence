using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DataManager : MonoBehaviour
{
  public static DataManager Instance;
  public string currentPlayerName;

  // Highscore vars
  public string highscorePlayerName;
  public int highscore;
  public List<HighscoreData> highscoreList;

  private void Awake()
  {
    if (Instance != null)
    {
      Destroy(gameObject);
      return;
    }
    Instance = this;
    DontDestroyOnLoad(gameObject);
    LoadHighscore();
    LoadHighscoreList();
  }

  [System.Serializable]
  public class HighscoreData
  {
    public string playerName;
    public int score;
  }

  [System.Serializable]
  class HighscoresData
  {
    public List<HighscoreData> highscoreList;
  }

  public void SaveHighscore(int score)
  {
    HighscoreData data = new HighscoreData();
    data.playerName = currentPlayerName;
    data.score = score;

    string json = JsonUtility.ToJson(data);
    File.WriteAllText(Application.persistentDataPath + "/highscore.json", json);
    highscoreList.Add(data);
    SaveHighscoreList();
  }

  public void LoadHighscore()
  {
    string path = Application.persistentDataPath + "/highscore.json";
    if (File.Exists(path))
    {
      string json = File.ReadAllText(path);
      HighscoreData data = JsonUtility.FromJson<HighscoreData>(json);

      highscorePlayerName = data.playerName;
      highscore = data.score;
    }
  }

  public void SaveHighscoreList()
  {
    HighscoresData data = new HighscoresData();
    data.highscoreList = highscoreList;

    string json = JsonUtility.ToJson(data);
    File.WriteAllText(Application.persistentDataPath + "/highscores.json", json);
  }

  public void LoadHighscoreList()
  {
    string path = Application.persistentDataPath + "/highscores.json";
    if (File.Exists(path))
    {
      string json = File.ReadAllText(path);
      HighscoresData data = JsonUtility.FromJson<HighscoresData>(json);

      highscoreList = data.highscoreList;
    }
  }

}
