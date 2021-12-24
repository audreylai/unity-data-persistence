using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

[DefaultExecutionOrder(1000)]
public class MenuUIManager : MonoBehaviour
{
  public TMP_InputField playerNameInput;
  public Button startButton;
  public Button highscoresButton;
  // Start is called before the first frame update
  void Start()
  {
    startButton.onClick.AddListener(StartGame);
    highscoresButton.onClick.AddListener(ViewHighscores);
  }
  
  void StartGame() {
    DataManager.Instance.currentPlayerName = playerNameInput.text;
    SceneManager.LoadScene(1);
  }

  void ViewHighscores() {
    SceneManager.LoadScene(2);
  }

}
