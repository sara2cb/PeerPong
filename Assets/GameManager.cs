using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static int PlayerScore1 = 0;
    public static int PlayerScore2 = 0;
    public static int PlayerScore3 = 0;
	public static int shift = 0;
    public static string sceneName;

    public GUISkin layout;

    GameObject theBall;

    // Use this for initialization
    void Start()
    {
        sceneName =  SceneManager.GetActiveScene().name;
        theBall = GameObject.FindGameObjectWithTag("Ball");
    }

    public static void Score(string wallID)
    {
        if (sceneName == "SampleScene")
        {
            if (wallID == "TopWall")
            {
                PlayerScore1++;
            }
            else if (wallID == "BottomWall")
            {
                PlayerScore2++;
            }
        }
        else if (sceneName == "4Players")
        {
            if (wallID == "TopWall" || wallID == "BottomWall")
            {
                PlayerScore1++;
            }
            else
            {
                PlayerScore2++;
            }
        }
        else
        {
            if (wallID == "BottomWall")
            {
                PlayerScore1++;
            }
            else if (wallID == "RightWall"){
                PlayerScore2++;
            }
            else{
                PlayerScore3++;
            }
        }

    }

    void OnGUI()
    {
		if (sceneName == "StartMenu") {
			GUI.skin = layout;
			GUI.Label (new Rect (Screen.width/2 -100, 80, 400, 100), "Peer Pong");
			if (GUI.Button (new Rect (Screen.width/ 2 - 150, 140, 100, 100), "2 Players")) {
				SceneManager.LoadScene("SampleScene");
			}
			if (GUI.Button (new Rect (Screen.width/2 + -40, 140, 100, 100), "3 Players")) {
				SceneManager.LoadScene("3Players");
			}
            if (GUI.Button(new Rect(Screen.width / 2 + 70, 140, 100, 100), "2 Teams"))
            {
                SceneManager.LoadScene("4Players");
            }

            //if not on the start screen
        } else {


			GUI.skin = layout;
			if (sceneName == "3Players") {
				shift = -80;
			}

			GUI.Label (new Rect (Screen.width / 2 - 150 - 12 + shift, 00, 100, 100), "SCORE");
            if (sceneName == "4Players")
            {
                GUI.Label(new Rect(Screen.width / 2 - 150 - 12 + shift, 20, 100, 100), "Team 1: " + PlayerScore1);
                GUI.Label(new Rect(Screen.width / 2 - 150 - 12 + shift, 40, 100, 100), "Team 2: " + PlayerScore2);
            }
            else
            {
                GUI.Label(new Rect(Screen.width / 2 - 150 - 12 + shift, 20, 100, 100), "Player 1: " + PlayerScore1);
                GUI.Label(new Rect(Screen.width / 2 - 150 - 12 + shift, 40, 100, 100), "Player 2: " + PlayerScore2);
            }            
			if (sceneName == "3Players") {
				GUI.Label (new Rect (Screen.width / 2 - 150 - 12 + shift, 60, 100, 100), "Player 3: " + PlayerScore3);
			}


			if (GUI.Button (new Rect (Screen.width / 2 - 60, 00, 120, 23), "QUIT")) {
				PlayerScore1 = 0;
				PlayerScore2 = 0;
				if (sceneName == "3Players") {
					PlayerScore3 = 0;
				}
				theBall.SendMessage ("RestartGame", 0.5f, SendMessageOptions.RequireReceiver);
				SceneManager.LoadScene("StartMenu");
			}
			if (PlayerScore1 == 10) {
                if (sceneName == "4Players")
                {
                    GUI.Label(new Rect(Screen.width / 2 + 50, 40, 2000, 1000), "TEAM ONE WINS");
                }
                else
                {
                    GUI.Label(new Rect(Screen.width / 2 + 50, 40, 2000, 1000), "PLAYER ONE WINS");
                }
				theBall.SendMessage ("ResetBall", null, SendMessageOptions.RequireReceiver);
				if (GUI.Button (new Rect (Screen.width / 2 + 60, 00, 120, 23), "RESTART")) {
					PlayerScore1 = 0;
					PlayerScore2 = 0;
					PlayerScore3 = 0;
					theBall.SendMessage ("RestartGame", 0.5f, SendMessageOptions.RequireReceiver);
				}
			} else if (PlayerScore2 == 10) {
                if (sceneName == "4Players")
                {
                    GUI.Label(new Rect(Screen.width / 2 + 50, 40, 2000, 1000), "TEAM TWO WINS");
                }
                else
                {
                    GUI.Label(new Rect(Screen.width / 2 + 50, 40, 2000, 1000), "PLAYER TWO WINS");
                }
                theBall.SendMessage ("ResetBall", null, SendMessageOptions.RequireReceiver);
				if (GUI.Button (new Rect (Screen.width / 2 + 60, 00, 120, 23), "RESTART")) {
					PlayerScore1 = 0;
					PlayerScore2 = 0;
					PlayerScore3 = 0;
					theBall.SendMessage ("RestartGame", 0.5f, SendMessageOptions.RequireReceiver);
				}
			} else if (PlayerScore3 == 10) {
				GUI.Label (new Rect (Screen.width / 2 + 50, 40, 2000, 1000), "PLAYER THREE WINS");
				theBall.SendMessage ("ResetBall", null, SendMessageOptions.RequireReceiver);
				if (GUI.Button (new Rect (Screen.width / 2 + 60, 00, 120, 23), "RESTART")) {
					PlayerScore1 = 0;
					PlayerScore2 = 0;
					PlayerScore3 = 0;
					theBall.SendMessage ("RestartGame", 0.5f, SendMessageOptions.RequireReceiver);
				}
			}
		}
    }

}