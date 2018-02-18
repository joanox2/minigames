﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxingEnemyController : MonoBehaviour {

    public GameManager gameManager;
    public BoxingPlayerController boxingPlayer;
    private int move;
    public float speed = 1;
    public int lastMove;

    public void init(GameManager gm)
    {
        gameManager = gm;
    }
    // Use this for initialization
    void Start()
    {
        StartCoroutine(MiUpdate());
    }

    IEnumerator MiUpdate()
    {
        yield return new WaitForSeconds(6);
        while (true)
        {
            GenerateRandom();
            yield return new WaitForSeconds(1);  
            transform.GetChild(0).gameObject.SetActive(true);
            yield return new WaitForSeconds(1);
            transform.GetChild(0).gameObject.SetActive(false);
            transform.GetChild(1).gameObject.SetActive(true);
            if (boxingPlayer.transform.position.x == transform.position.x)
            {
               GameObject.Find("Player").SetActive(false);
               gameManager.EndGame(IMiniGame.MiniGameResult.LOSE);
            }
            yield return new WaitForSeconds(1);
            transform.GetChild(1).gameObject.SetActive(false);
        }    
    }

    void GenerateRandom()
    {
        move = Random.Range(1, 3);
            
        
        if (lastMove == 1)
        {
            move = 2;
        }
        if (lastMove == -1)
        {
            move = 1;
        }
       
        switch (move)
        {
            case 1:
                transform.Translate(Vector3.right * speed);
                lastMove++;
                break;

            case 2:
                transform.Translate(Vector3.left * speed);
                lastMove--;
                break;
        }
    }
}
