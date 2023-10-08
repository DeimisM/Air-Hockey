using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.SceneManagement;
using UnityEditor.Search;
using JetBrains.Annotations;

public class Hockey : MonoBehaviour
{
    int playerScore;
    int enemyScore;

    public TMP_Text playerScoreText;
    public TMP_Text enemyScoreText;

    public TMP_Text displayText;

    //public AudioSource source;
    public AudioClip wallHit;
    public AudioClip hit;
    public AudioClip goal;

    public float respawnCooldown;
    float respawnTimer;

    public Transform deathPoint;
    public bool shouldRepspawn;

    Vector3 respawnPosition;

    private void Update()
    {
         if (shouldRepspawn)
         {
            respawnTimer -= Time.deltaTime;
            if (respawnTimer <= 0)
            {
                transform.position = respawnPosition;
                respawnTimer = respawnCooldown;
                shouldRepspawn = false;

                displayText.text = "";
            }
         }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //GetComponent<AudioSource>().Play();

        if(collision.gameObject.name.Contains("Enemy Goal"))
        {
            playerScore++;
            playerScoreText.text = playerScore.ToString();

            respawnPosition = Vector3.right;

            displayText.text = "Player Goal!";
        }

        if (collision.gameObject.name.Contains("Player Goal"))
        {
            enemyScore++;
            enemyScoreText.text = enemyScore.ToString();

            respawnPosition = Vector3.left;

            displayText.text = "Enemy Goal!";
        }

        if (collision.gameObject.name.Contains("Goal"))
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;

            GetComponent<AudioSource>().PlayOneShot(goal);
            transform.position = deathPoint.position;
            shouldRepspawn = true;

            if(playerScore >= 7 || enemyScore >= 7)
            {
                SceneManager.LoadScene("Menu");
            }
        }

        if (collision.gameObject.name.Contains("Wall"))
        {
            GetComponent<AudioSource>().PlayOneShot(wallHit);
        }

        if (collision.gameObject.name.Contains("Entity"))
        {
            GetComponent<AudioSource>().PlayOneShot(hit);
        }
    }
}
