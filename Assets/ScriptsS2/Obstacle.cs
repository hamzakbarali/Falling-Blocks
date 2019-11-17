using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] GameObject obstacle;
    public float fallAmt;
    

    void Start()
    {
        obstacle = GameObject.Find("Obstacle");
        fallAmt = 5f;
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = Vector3.down.normalized * fallAmt * Time.deltaTime;
        transform.Translate(direction);
    }

    
}
