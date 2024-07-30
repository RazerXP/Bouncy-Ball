using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public float BallSpeed;
    AudioSource audioSource;
    void Start()
    {
        Rigidbody2D rb = gameObject.GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.down * BallSpeed;
        audioSource = gameObject.GetComponent<AudioSource>();
    }
    void OnCollisionEnter2D(Collision2D other){
        if(other.gameObject.CompareTag("paddle")){
            audioSource.Play();
        }
    }
}
