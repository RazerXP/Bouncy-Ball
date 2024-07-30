using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BottomCollector : MonoBehaviour
{
    public float slowSpeedDuration;
    float ballspeed;
    GameManager gameManager;
    AudioSource audioSource;
    void Start()
    {
        ballspeed = GameObject.FindWithTag("Ball").GetComponent<BallMovement>().BallSpeed;
        gameManager = GameObject.FindWithTag("Game Manager").GetComponent<GameManager>();
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    void OnTriggerEnter2D(Collider2D other){
        respawnball(other, false);
    }

    public void respawnball(Collider2D other,bool islevelup){
        other.gameObject.transform.position = new Vector3(0,0,0);
        other.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0,-ballspeed/3);
        if(islevelup) StartCoroutine(respawnSpeed(other));
        else if(gameManager.lifeLost() == 1){
            audioSource.Play();
            StartCoroutine(respawnSpeed(other));
        }
    }

    IEnumerator respawnSpeed(Collider2D other){
        yield return new WaitForSeconds(slowSpeedDuration);
        Vector2 speed = other.gameObject.GetComponent<Rigidbody2D>().velocity;
        other.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(speed.x, speed.y/Math.Abs(speed.y)*ballspeed);
    }
}
