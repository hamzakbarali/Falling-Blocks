using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameName : MonoBehaviour
{
    private Text gameName; 
    // Start is called before the first frame update
    void Start()
    {
        gameName = GameObject.Find("Game Name").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(ChangeGameNameColor());
    }

    private IEnumerator ChangeGameNameColor()
    {
        Color curColor = new Color32(255, 255, 255, 255);
        if (gameName.color.Equals(curColor))
        {
            yield return new WaitForSeconds(1f);
            gameName.color = new Color32(2,2,2,255);
        }
        else
        {
            yield return new WaitForSeconds(1f);
            gameName.color = new Color32(255, 255, 255, 255);
        }
    }
}
