using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BackToMenu : MonoBehaviour
{
  public Button button;

  // Start is called before the first frame update
  void Start()
  {
    button.onClick.AddListener(onClick);
  }

  public void onClick()
  {
    SceneManager.LoadScene(0);
  }
}
