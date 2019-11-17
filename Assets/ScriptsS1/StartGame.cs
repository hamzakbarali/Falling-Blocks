using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    private Button startGame;
    // Start is called before the first frame update
    void Start()
    {
        startGame = GameObject.Find("Start Game").GetComponent<Button>();
        startGame.onClick.AddListener(GameStart);
    }

    private void GameStart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
