using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI.TableUI;

public class HighscoreTable : MonoBehaviour
{
  public TableUI table;
  // Start is called before the first frame update
  void Start()
  {
    if (DataManager.Instance != null)
    {
      foreach (DataManager.HighscoreData entry in DataManager.Instance.highscoreList){
        table.Rows++;
        int row = DataManager.Instance.highscoreList.IndexOf(entry)+1;
        table.GetCell(row, 0).text = entry.playerName;
        table.GetCell(row, 1).text = entry.score.ToString();
      }
    }
  }
}
