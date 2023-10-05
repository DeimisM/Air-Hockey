using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Hockey : MonoBehaviour
{
    int playerScore;
    int enemyScore;

    public TMP_Text playerScoreText;
    public TMP_Text enemyScoreText;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        GetComponent<AudioSource>().Play();

        if (collision.gameObject.name.Contains("Goal"))
        {
            transform.position = new Vector3(0, 0, 0);
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }

        if(collision.gameObject.name.Contains("Enemy Goal"))
        {
            playerScore++;
            playerScoreText.text = playerScore.ToString();

            transform.position = Vector3.right;
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }

        if (collision.gameObject.name.Contains("Player Goal"))
        {
            enemyScore++;
            enemyScoreText.text = enemyScore.ToString();

            transform.position = Vector3.left;
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }
    }
}
