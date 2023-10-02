using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartButton : MonoBehaviour
{
    private Button startButton;
    private const string MAIN_SCENE_NAME = "SampleScene";

    // Start is called before the first frame update
    private void Start()
    {
        startButton = GetComponent<Button>();
        startButton.onClick.AddListener(StartGame);
    }

    private void StartGame()
    {
        SceneManager.LoadScene(MAIN_SCENE_NAME);
    }
}
