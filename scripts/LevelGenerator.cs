using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public GameObject brickPrefab;
    public Vector2Int brickCount;
    public Vector2 offset;
    
    void Awake()
    {
        populateBricks();
    }

    GameManager gameManager;
    void Start()
    {
        gameManager = GameObject.FindWithTag("Game Manager").GetComponent<GameManager>();
        gameManager.bricksleft = brickCount.x * brickCount.y;
    }

    public void populateBricks(){
        for(int i=0; i< brickCount.x; i++){
            for(int j=0; j<brickCount.y; j++){
                GameObject newBrick = Instantiate(brickPrefab, transform);
                newBrick.transform.position += new Vector3((float)(brickCount.x*.5f-i)*offset.x, j*offset.y,0);
            }
        }
    }

}
