using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallController : MonoBehaviour
{
    public int force;
    Rigidbody2D rigid;
    public float ballPos;
    int scoreP1;
    int scoreP2;
    int scoreRally;
    Text scoreUIP1;
    Text scoreUIP2;
    Text scoreUIRally;
    GameObject endPanel;
    Text winnerText;
    AudioSource audio;
    public AudioClip hitSound;

    
    

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        Vector2 arah = new Vector2(2, 0).normalized;
        rigid.AddForce(arah * force);
        scoreP1 = 0;
        scoreP2 = 0;
        scoreRally = 0;
        scoreUIP1 = GameObject.Find("Score1").GetComponent<Text>();
        scoreUIP2 = GameObject.Find("Score2").GetComponent<Text>();
        scoreUIRally = GameObject.Find("ScoreRally").GetComponent<Text>();
        endPanel = GameObject.Find("PanelSelesai");
        endPanel.SetActive(false);
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D coll)
    { 
        audio.PlayOneShot(hitSound);
        if (coll.gameObject.name == "TepiKanan")
        {
            scoreRally = 0;
            scoreP1 += 1;
            ShowScore();
            if (scoreP1 == 5)
            {
                endPanel.SetActive(true);
                winnerText = GameObject.Find("Pemenang").GetComponent<Text>();
                winnerText.text = "Player 1";
                Destroy(gameObject);
                return;
            }
            ResetBall();
            Vector2 arah = new Vector2(2, 0).normalized;
            rigid.AddForce(arah * force);
        }
        if (coll.gameObject.name == "TepiKiri")
        {
            scoreRally = 0;
            scoreP2 += 1;
            ShowScore();
            if (scoreP2 == 5)
            {
                endPanel.SetActive(true);
                winnerText = GameObject.Find("Pemenang").GetComponent<Text>();
                winnerText.text = "Player 2";
                Destroy(gameObject);
                return;
            }
            ResetBall();
            Vector2 arah = new Vector2(-2, 0).normalized;
            rigid.AddForce(arah * force);
        }

        if (coll.gameObject.name == "Pemukul1" || coll.gameObject.name == "Pemukul2")
        {
            scoreRally += 1;
            ShowScore();
            float sudut = (transform.position.y - coll.transform.position.y) * 5f;
            Vector2 arah = new Vector2(rigid.velocity.x, sudut).normalized;
            rigid.velocity = new Vector2(0, 0);
            rigid.AddForce(arah * force * 2);
        }
    }

    void ResetBall()
    {
        transform.localPosition = new Vector2(0, ballPos);
        rigid.velocity = new Vector2(0, 0);
    }

    void ShowScore()
    {
        Debug.Log("Score Rally: " + scoreRally  + "Score P1: " + scoreP1 + " Score P2: " + scoreP2);
        scoreUIP1.text = scoreP1 + "";
        scoreUIP2.text = scoreP2 + "";
        scoreUIRally.text = scoreRally + "";
    }
}
