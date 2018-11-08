using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BallContro4players : MonoBehaviour
{

    private Rigidbody2D rb2d;
    public static string sceneName;
    public static string lastHit = "";

    void GoBall()
    {
        sceneName = SceneManager.GetActiveScene().name;
		lastHit = "";
        float rand = Random.Range(0, 2);
        if (rand < 1)
        {
            rb2d.AddForce(new Vector2(0, 200));
        }
        else
        {
            rb2d.AddForce(new Vector2(-0, -200));
        }
    }

    // Use this for initialization
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        Invoke("GoBall", 2);
    }

    void ResetBall()
    {
        if (sceneName == "3Players")
        {
            transform.position = new Vector2((float)-0.8666,(float)-0.021);
        }
        else{
            transform.position = Vector2.zero;
			rb2d.velocity = new Vector2(0, 0);

        }

        //rb2d.velocity = new Vector2(0, 1);
        GoBall();
    }

    void RestartGame()
    {
        ResetBall();
        Invoke("GoBall", 1);
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.collider.CompareTag("Player") || coll.collider.CompareTag("PaddleBottom")
            || coll.collider.CompareTag("PaddleRight") || coll.collider.CompareTag("PaddleLeft"))
        {
            Vector2 vel;
            vel.x =  (rb2d.velocity.x / 2.0f) + (coll.collider.attachedRigidbody.velocity.x / 3.0f);
            vel.y = rb2d.velocity.y;
            rb2d.velocity = vel;
            float rand = Random.Range(1, 10);
            if (rand > 8)
            {
				//?
            }

        }
        if (sceneName == "SampleScene")
        {
            if (coll.collider.CompareTag("TopWall"))
            {
                GameManager.Score("BottomWall");
                RestartGame();
            }
            else if (coll.collider.CompareTag("BottomWall"))
            {
                GameManager.Score("TopWall");
                RestartGame();
            }
        }
        else
        {
            if (coll.collider.CompareTag("PaddleBottom"))
            {
                lastHit = "BottomWall";

            }
            if (coll.collider.CompareTag("PaddleRight"))
            {
                lastHit = "RightWall";

            }
            if (coll.collider.CompareTag("PaddleLeft"))
            {
                lastHit = "LeftWall";

            }
            if (coll.collider.CompareTag("LeftWall"))
            {
				if (lastHit == "") {
					GameManager.Score ("BottomWall");
					GameManager.Score ("RightWall");
				} else {
					GameManager.Score (lastHit);
				}
                ResetBall();
            }
            else if (coll.collider.CompareTag("BottomWall"))
            {
				if (lastHit == "") {
					GameManager.Score ("LeftWall");
					GameManager.Score ("RightWall");
				} else {
					GameManager.Score (lastHit);
				}
                ResetBall();
            }
            else if(coll.collider.CompareTag("RightWall")){
				if (lastHit == "") {
					GameManager.Score ("BottomWall");
					GameManager.Score ("LeftWall");
				} else {
					GameManager.Score (lastHit);
				}
                ResetBall();
            }
        }

    }

}