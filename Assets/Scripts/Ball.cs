﻿using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
using UnityEngine;

public class Ball : MonoBehaviour {

    private bool isMouseDown = false;

    private Vector3 lastMousePosition = Vector3.zero;

    public bool IsVisible
    {
        get { return gameObject.activeInHierarchy; }
        set { gameObject.SetActive(value);}
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isMouseDown = true;
        }
        if (Input.GetMouseButtonUp(0))
        {
            isMouseDown = false;
            lastMousePosition = Vector3.zero;
        }
        if (isMouseDown)
        {
            if (lastMousePosition != Vector3.zero)
            {
                Vector3 offset = Camera.main.ScreenToWorldPoint(Input.mousePosition) - lastMousePosition;
                this.transform.position += offset;
            }
            lastMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        }
    }

    public void OnCollisonEnter2D(Collision2D collision)
    {
        if (Game.Instance.gameState != GameState.Ready)
        {
            string tag = collision.transform.tag;
            if (tag == "Border")
            {
                Debug.Log("碰到" + tag + "了");
            }
        }
    }
    

}
