using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 30;

    private void Update()
    {
        var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;

        if (mousePos.x > 0)
        {
            mousePos.x = 0;
        }
        var finalPostion = Vector3.MoveTowards(transform.position, mousePos, speed * Time.deltaTime);
        GetComponent<Rigidbody2D>().MovePosition(finalPostion);
    }
}
