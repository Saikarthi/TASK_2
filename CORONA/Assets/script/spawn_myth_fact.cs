﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class spawn_myth_fact : MonoBehaviour
{
    public GameObject[] g;

    private int how_many_time;
    public Button b;
   
   //for not click in joystick

   public GameObject joy1,joy2,joy3;
    // Start is called before the first frame update
    void Start()
    {
        how_many_time = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(how_many_time >= 2)
        {
            b.interactable = false;
        }
    }
   public void Spawnm_f()
    {
        how_many_time += 1;
        joy1.SetActive(false);
        joy2.SetActive(false);
        joy3.SetActive(false);
        Time.timeScale = 0f;
        
        int randomSpawn = Random.Range(0, g.Length);
        g[randomSpawn].SetActive(true);
    }

    public void r()
    {
        
        Time.timeScale = 1f;
         joy1.SetActive(true);
        joy2.SetActive(true);
        joy3.SetActive(true);
    }
}
