using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public Text ScoreText;
    public float timeLeft;
    public int timeRemaining;
    public Text TimerText;
    public ParticleSystem Appear;

    private float Score;
    private float TimerValue;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeLeft -= Time.deltaTime;
        timeRemaining = Mathf.FloorToInt(timeLeft % 60);
        TimerText.text = "Timer: " + timeRemaining.ToString();

        ScoreText.text = "Score: " + Score.ToString();

        if (Score == 60)
        {
            if (timeLeft <= TimerValue)
            {
                SceneManager.LoadScene("Win");
            }
        }
        else if (timeLeft <= 0)
        {
            SceneManager.LoadScene("Lose");
        }


    }

    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log("collide");
        if (collision.gameObject.tag == "Coin")
        {
            //Debug.Log("coin");

            Destroy(collision.gameObject);
            Appear.Play();
            Score += 10;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Fire") ;
        {
            SceneManager.LoadScene("Lose");
        }
    }
}
