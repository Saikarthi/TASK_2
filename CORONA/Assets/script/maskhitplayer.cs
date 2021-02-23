using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class maskhitplayer : MonoBehaviour
{
    public Image i;
    private float a = 0f, b = 0.5f, c = 1f;
 

    public void OnCollisionEnter2D(Collision2D co)
    {
        if(co.gameObject.tag == "Player")
        {
            Debug.Log("firat");

            var temp = i.color;
            temp.a = c;
            i.color = temp;
            Invoke("red", 0.1f);
            
        }
    }
    public void red()
    {
       
        var temp = i.color;
        temp.a = b;
        i.color = temp;
        Invoke("rod", 0.1f);
    }
    public void rod()
    {
        var temp = i.color;
        temp.a = a;
        i.color = temp;
        Destroy(this.gameObject, 0.1f);
    }


}
