using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Hockey : MonoBehaviour
{
    public TMP_Text player_score;
    public TMP_Text enemy_score;

    int player_points = 0;
    int enemy_points = 0;

    private void Update()
    {

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Contains("Goal"))
        {
            transform.position = new Vector3(0, 0, 0);
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }

        if(collision.gameObject.name.Contains("Enemy Goal"))
        {
            player_points += 1;
            player_score.text = player_points.ToString();
        }

        if (collision.gameObject.name.Contains("Player Goal"))
        {
            enemy_points += 1;
            enemy_score.text = enemy_points.ToString();
        }
    }
}
