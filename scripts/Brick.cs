using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Brick : MonoBehaviour
{
    GameManager gameManager;
    void Start()
    {
        gameManager = GameObject.FindWithTag("Game Manager").GetComponent<GameManager>();
    }
    void OnTriggerEnter2D(Collider2D other){
        Destroy(gameObject);
        Vector2 speed = other.gameObject.GetComponent<Rigidbody2D>().velocity;
        other.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(speed.x, -speed.y);
        gameManager.addScore(this);
    }
}
