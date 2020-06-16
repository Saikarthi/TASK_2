using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class m_f : MonoBehaviour
{
    public Button m, f;
    public GameObject g;
    public Health h;
    public health_update d;
    public spawn_myth_fact s;
    public GameObject c, w;
    


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void myth()
    {
        m.interactable = false;
        f.interactable = false;
        if(g.gameObject.tag == "myth")
        {
            h.health -= 25;
            if (h.health < 0)
            {
                h.health = 0;
            }
            if (h.health > 50)
            {
                h.health = 50;
            }
            d.die();
            s.r();
            c.SetActive(true);
            
            Invoke("g1", 1f);
            g.SetActive(false);

        }
        else
        {
            s.r();
            w.SetActive(true);

            Invoke("w1", 1f);
            g.SetActive(false);

        }
    }
    public void fact()
    {
        m.interactable = false;
        f.interactable = false;
        if (g.gameObject.tag == "fact")
        {
            h.health -= 25;
            if (h.health < 0)
            {
                h.health = 0;
            }
            if (h.health > 50)
            {
                h.health = 50;
            }
            d.die();
            s.r();
            c.SetActive(true);

            Invoke("g1", 1f);
            g.SetActive(false);
        }
        else
        {
            s.r();
            w.SetActive(true);

            Invoke("w1", 1f);
            g.SetActive(false);
        }

    }
    public void g1()
    {
        m.interactable = true;
        f.interactable = true;
        c.SetActive(false);

       
    }
    public void w1()
    {
        m.interactable = true;
        f.interactable = true;
        w.SetActive(false);
       
    }


}
