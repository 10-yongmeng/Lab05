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
                SceneManager.LoadScene("win");
            }
        }
        else if (timeLeft <= 0)
        {
            SceneManager.LoadScene("lose");
        }


    }

    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log("collide");
        if (collision.gameObject.tag == "environment")
        {
            SceneManager.LoadScene("lose");
        }
        if (collision.gameObject.tag == "Coin")
        {
            //Debug.Log("coin");
            Destroy(collision.gameObject);
            Score += 10;
        }
    }
}
