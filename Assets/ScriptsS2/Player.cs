using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] float moveAmt;
    private float cameraWidthInWorld;
    private float cameraHeightInWorld;
    private Text score;


    
    void Start()
    {
        player = GameObject.Find("Player");
        moveAmt = 7f;
        cameraHeightInWorld = Camera.main.orthographicSize;
        cameraWidthInWorld = cameraHeightInWorld * Camera.main.aspect;
        GameObject.Find("Canvas").GetComponent<Canvas>().enabled = false;
        score = GameObject.Find("Score").GetComponent<Text>();
    }

    void Update()
    {
        Vector3 input = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
        Vector3 direction = input.normalized;
        Vector3 velocity = direction * Time.deltaTime * moveAmt;
        player.transform.Translate(velocity);

        if(transform.position.x > cameraWidthInWorld + player.transform.localScale.x / 2)
        {
            transform.position = new Vector2(-cameraWidthInWorld + player.transform.localScale.x / 2, transform.position.y);
        }
        else if(transform.position.x < -cameraWidthInWorld - player.transform.localScale.x / 2)
        {
            transform.position = new Vector2(cameraWidthInWorld - player.transform.localScale.x / 2, transform.position.y);
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Obstacle")
        {
            Destroy(player);
            score.text = "Score: " + Mathf.FloorToInt(Time.timeSinceLevelLoad).ToString();
            GameObject.Find("Canvas").GetComponent<Canvas>().enabled = true;
            
        }
    }
}
