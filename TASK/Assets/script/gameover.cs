using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameover : MonoBehaviour
{
    public GameObject a, b,c,player;
    public score s;
    public Health h;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(h.health >= 50)
        {
            s.enabled = false;
            player.SetActive(false);
            c.SetActive(true);
            a.SetActive(true);
            Invoke("game",1f);
        }
    }
    public void game()
    {
        
        b.SetActive(true);

    }
}
