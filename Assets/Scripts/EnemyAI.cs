using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public Transform ball;
    public Transform defensePoint;
    public Vector3 targetPosition;

    private float speed = 10;

    public float attackSpeed = 10;
    public float defenseSpeed = 20;

    private void Update()
    {
        bool ballInRange = ball.position.x >= 0;

        if (ballInRange)
        {
            targetPosition = ball.position;
            speed = attackSpeed;
        }
        else
        {
            targetPosition = defensePoint.position;
            speed = defenseSpeed;
        }
        var finalPostion = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        GetComponent<Rigidbody2D>().MovePosition(finalPostion);
    }
}
