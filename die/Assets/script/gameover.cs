using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameover : MonoBehaviour
{
    public GameObject a, b,c,player;
    public score s;
    public Health h;
    public GameObject saveme,restart;
    private int loadscene;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(h.health >= 50)
        {
            saveme.SetActive(false);
            restart.SetActive(true);
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
    public void Restart1()
    {
        loadscene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(loadscene);
    }
}
