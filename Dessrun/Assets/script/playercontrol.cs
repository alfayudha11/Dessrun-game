using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playercontrol : MonoBehaviour
{
    Rigidbody2D rb2d;
    public float RunSpeed;
    private int JumpCount = 0;
    private bool canJump = true;
    Animator anim;
    public bool isGameOver=false;
    public GameObject GameOverPanel,scoreText;
    public Text FinalScoreText, HighScoreText;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        StartCoroutine("IncreaseSpeed");
    }

    // Update is called once per frame
    void Update()
    {
        if (!isGameOver)
        {
            transform.position = Vector3.right * RunSpeed * Time.deltaTime + transform.position;
        }
        
        if (JumpCount == 2)
        {
            canJump = false;
        }

        if (Input.GetKeyDown("space") )
        {
            rb2d.velocity = Vector3.up * 7.5f; 
            anim.SetTrigger("jump"); 
            JumpCount += 1;
        }
    }

    public void GameOver()
    {
        isGameOver = true;
        anim.SetTrigger("die");
        StartCoroutine("ShowGameOverPanel");
        StopCoroutine("IncreaseSpeed");

    }

   private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            JumpCount = 0;
            canJump = true;
        }
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            GameOver();
        }
        if (collision.gameObject.CompareTag("BottomDetector"))
        {
            GameOver();
        }
    }
    IEnumerator IncreaseSpeed()
    {
        yield return new WaitForSeconds(10);
        if (RunSpeed < 8)
        {
            RunSpeed += 0.2f;
        }
        if (GameObject.Find("GroundSpawner").GetComponent<ObstacleSpwan>().obstacleSpawnInterval > 1)
        {
            GameObject.Find("GroundSpawner").GetComponent<ObstacleSpwan>().obstacleSpawnInterval -= 0.1f;
        }
        
    }
     IEnumerator ShowGameOverPanel()
    {
        yield return new WaitForSeconds(2);
        GameOverPanel.SetActive(true);
        scoreText.SetActive(false);

        FinalScoreText.text ="score :" + GameObject.Find("SoreDetector").GetComponent<scoresytem>().score;
        HighScoreText.text = "High Score :" + PlayerPrefs.GetInt("HighScore");
     
    }

}
