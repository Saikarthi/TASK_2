using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public float health =0f;

    public Image greeen,red;
    private float a = 0f, b = 0.5f, c = 1f;

    public health_update h;



    // Start is called before the first frame update
    void Start()
    {
        health = 0;
        a = 0f;
        b = 0.5f;
        c = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(health);
        

    }

    public void OnCollisionEnter2D(Collision2D co)
    {
        if (co.gameObject.tag == "virus")
        {
            health += 5;
            
            if (health < 0)
            {
                health = 0;
            }
            if (health > 50)
            {
                health = 50;
            }
            h.die();
            Debug.Log("dieing soon");
            Destroy(co.gameObject);
            var temp = red.color;
            temp.a = c;
            red.color = temp;
            Invoke("red1", 0.1f);
        }
        if (co.gameObject.tag == "mask")
        {
            health -= 10;
            
            if (health < 0)
            {
                health = 0;
            }
            if (health > 50)
            {
                health = 50;
            }
            h.die();
            Destroy(co.gameObject);
            var temp = greeen.color;
            temp.a = c;
            greeen.color = temp;
            Invoke("g", 0.1f);

        }

    }
    public void g()
    {

        var temp = greeen.color;
        temp.a = b;
        greeen.color = temp;
        Invoke("g1", 0.1f);
    }
    public void g1()
    {
        var temp = greeen.color;
        temp.a = a;
        greeen.color = temp;
       
    }
    public void red1()
    {

        var temp = red.color;
        temp.a = b;
        red.color = temp;
        Invoke("red2", 0.1f);
    }
    public void red2()
    {
        var temp = red.color;
        temp.a = a;
        red.color = temp;

    }
}
