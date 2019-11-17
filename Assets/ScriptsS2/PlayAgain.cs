using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PlayAgain : MonoBehaviour
{
    [SerializeField] Button playAgain;
    // Start is called before the first frame update
    void Start()
    {
        playAgain = GameObject.Find("Play Again").GetComponent<Button>();
        playAgain.onClick.AddListener(Restart);
    }

    private void Restart()
    {
        GameObject.Find("Canvas").GetComponent<Canvas>().enabled = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        
    }
}
