﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEnemy : MonoBehaviour
{
    public float speed;
    public bool isSearch;

    bool isUp;
    bool isDown;
    bool isRight;
    bool isLeft;
    float startPositionY;
    float startPositionX;
    float nowPosition;

    void Start()
    {
        isSearch = true;
        isUp = true;
        isDown = false;
        isLeft = false;
        isRight = false;
        startPositionY = transform.position.y;
        startPositionX = transform.position.x;

    }


    private void FixedUpdate()
    {

        if (Input.GetKey(KeyCode.Space))
        {
            Debug.Log(transform.position);
        }

        Search();
    }

    void Search()
    {
        if (isSearch)
        {
            if (isUp)
            {
                Debug.Log("上");
                nowPosition = transform.position.y;
                transform.eulerAngles = new Vector3(0f, 0f, 90f);
                if (nowPosition - startPositionY < 5)
                    transform.position += new Vector3(0, speed * Time.deltaTime, 0);
                else
                {
                    startPositionX = transform.position.x;
                    isUp = false;
                    isRight = true;
                }
            }
            if (isRight)
            {
                Debug.Log("右");
                nowPosition = transform.position.x;
                transform.eulerAngles = new Vector3(0f, 0f, 0f);
                if (nowPosition - startPositionX < 5)
                    transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
                else
                {
                    startPositionY = transform.position.y;
                    isRight = false;
                    isDown = true;
                }
            }
            if (isDown)
            {
                Debug.Log("下");
                nowPosition = transform.position.y;
                transform.eulerAngles = new Vector3(0f, 0f, -90f);
                if (nowPosition - startPositionY > -5)
                    transform.position += new Vector3(0, -speed * Time.deltaTime, 0);
                else
                {
                    startPositionX = transform.position.x;
                    isDown = false;
                    isLeft = true;
                }
            }
            if (isLeft)
            {
                Debug.Log("左");
                nowPosition = transform.position.x;
                transform.eulerAngles = new Vector3(0f, 0f, -180f);
                if (nowPosition - startPositionX > -5)
                    transform.position += new Vector3(-speed * Time.deltaTime, 0, 0);
                else
                {
                    startPositionY = transform.position.y;
                    isLeft = false;
                    isUp = true;
                }
            }
        }
    }
}
