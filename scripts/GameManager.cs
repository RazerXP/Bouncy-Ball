using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [HideInInspector] public int score = 0;
    [HideInInspector] public int bricksleft;
    private int curr_level = 1;
    public int lives = 3;
    public int levelupbuff = 50;
    public Text scoreText;
    public Text lifeText;
    public GameObject gameoverpanel;
    public GameObject ball;
    public Text finalScore;
    public GameObject levelGenerator;
    public GameObject bottomCollector;
    public ParticleSystem particlesys;
    public AudioSource audioSource;
    
    [ContextMenu("Inc Score")]
    public void addScore(Brick brick){
        score += 1;
        scoreText.text = score.ToString();
        bricksleft--;
        if(bricksleft <= 0) levelup();
        particlesys.transform.position = brick.transform.position;
        particlesys.Play();
        audioSource.Play();
    }

    [ContextMenu("Life Lost")]
    public int lifeLost(){
        lives -= 1;
        lifeText.text = lives.ToString();
        if(lives <= 0) {
            gameoverpanel.SetActive(true);
            Destroy(ball);
            finalScore.text = "Score : " + score.ToString();
            return 0;
        }
        return 1;
    }

    [ContextMenu("Restart Game")]
    public void restartGame(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    [ContextMenu("Level Up")]
    public void levelup(){
        score += levelupbuff*curr_level++;
        for(int i=levelGenerator.transform.childCount-1; i>=0; i--) Destroy(levelGenerator.transform.GetChild(i).gameObject);
        levelGenerator.transform.localScale *= 0.85f;
        LevelGenerator lg = levelGenerator.GetComponent<LevelGenerator>();
        lg.brickCount = new Vector2Int(lg.brickCount.x + 2, lg.brickCount.y + 1);
        lg.offset = new Vector2(lg.offset.x *0.85f, lg.offset.y * 0.85f);
        lg.populateBricks();
        bricksleft = lg.brickCount.x * lg.brickCount.y;
        bottomCollector.GetComponent<BottomCollector>().respawnball(ball.GetComponent<Collider2D>(), true);

    }

    [ContextMenu("Remove bricks but one")]
    public void removeallbricks(){
        for(int i=levelGenerator.transform.childCount-2; i>=0; i--) Destroy(levelGenerator.transform.GetChild(i).gameObject);
        bricksleft=1;
    }

}
