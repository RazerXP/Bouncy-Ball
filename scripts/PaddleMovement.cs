using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleMovement : MonoBehaviour
{
    public float speed;
    public float maxX;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float movementX = Input.GetAxisRaw("Horizontal");
        if(transform.position.x < maxX && movementX > 0)
            transform.position += new Vector3(speed*movementX*Time.deltaTime, 0, 0);
        else if(transform.position.x > -maxX && movementX < 0)
            transform.position += new Vector3(speed*movementX*Time.deltaTime, 0, 0);
    }
}
