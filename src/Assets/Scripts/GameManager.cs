﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager _instance;
    //il faut que les énigmes soit toutes finis pour sortir du labyrinthe
    public GameObject door;
    public int puzzleToDo=3;
    public int puzzleDone=0;
    public bool end=false;
    void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(this);

        }
        else
            Destroy(this);
    }
    private IEnumerator OnEventActivate()
    {
        puzzleDone++;
        if (puzzleDone == puzzleToDo)
        {
            end = true;
        }
        yield return 0;

    }
    public void Coroutine()
    {
        StartCoroutine(OnEventActivate());
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag!=null && other.tag=="Player" && puzzleDone == puzzleToDo)
        {
            Destroy(door);
            Invoke("DoorEnd", 6f);
        }
    }
    void DoorEnd()
    {
        end = true;
    }
}
