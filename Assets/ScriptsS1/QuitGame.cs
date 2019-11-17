using UnityEngine;
using UnityEngine.UI;

public class QuitGame : MonoBehaviour
{
    private Button quitGame;
    // Start is called before the first frame update
    void Start()
    {
        quitGame = GameObject.Find("Quit Game").GetComponent<Button>();
        quitGame.onClick.AddListener(GameQuit);
    }

    private void GameQuit()
    {
        //Debug.Log("Quit Game");
        Application.Quit();
    }
}
