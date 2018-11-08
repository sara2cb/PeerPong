using System.Threading;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
//using System.Collections.Generic;
//using System.Collections;

public class PaddleControls4PlayersY : MonoBehaviour
{
    public KeyCode moveLeft = KeyCode.A;
    public KeyCode moveRight = KeyCode.D;
    public float boundYtop = 2f;
    public float boundYbottom = 2f;
    private Rigidbody2D rb2d; Scene m_Scene;
    string sceneName;

    //[SerializeField]
    private float speed=10.0f;
    /*
    void FixedUpdate()
    {
        if (this.isLocalPlayer)
        {
            float movement = Input.GetAxis("Horizontal");
            GetComponent<Rigidbody2D>().velocity = new Vector2(movement * speed, 10.0f);
        }
    }
    */

    void Start()
    {
       /*m_Scene = SceneManager.GetActiveScene();
        sceneName = m_Scene.name;
#pragma warning disable CS0618 // El tipo o el miembro están obsoletos
        Application.LoadLevel(name: sceneName);
#pragma warning restore CS0618 // El tipo o el miembro están obsoletos
        NetworkManager.singleton.ServerChangeScene(sceneName);*/
        rb2d = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        /*if (!isLocalPlayer)
        {
           return;
        }*/

        var vel = rb2d.velocity;
        if (Input.GetKey(moveLeft))
        {
            vel.y = speed;
        }
        else if (Input.GetKey(moveRight))
        {
            vel.y = -speed;
        }
        else
        {
            vel.y = 0;
        }
        rb2d.velocity = vel;

        var pos = transform.position;
        if (pos.y > boundYtop)
        {
            pos.y = boundYtop;
        }
        else if (pos.y < boundYbottom)
        {
            pos.y = boundYbottom;
        }
        transform.position = pos;
    }
}
