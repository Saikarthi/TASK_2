using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    public float speed;
    public Animator anim;
    public bool flipright=true;
    public bool leftright;


    public void flip(bool lr)
    {
        if (leftright != flipright)
        {
            flipright = !flipright;
            Vector2 thescale = transform.localScale;
            thescale.x *= -1;
            transform.localScale = thescale;
        }
       
        
    }

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.UpArrow))
        {
            anim.enabled = true;
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                leftright = true;
                flip(leftright);
              
                Vector3 position = this.transform.position;
                position.x -= speed;
                this.transform.position = position;
            }
           
            if (Input.GetKey(KeyCode.RightArrow))
            {
                leftright = false;
                flip(leftright);
                
                Vector3 position = this.transform.position;
                position.x += speed;
                this.transform.position = position;
            }
         
            if (Input.GetKey(KeyCode.DownArrow))
            {
                Vector3 position = this.transform.position;
                position.y -= speed;
                this.transform.position = position;
            }
            if (Input.GetKey(KeyCode.UpArrow))
            {
                Vector3 position = this.transform.position;
                position.y += speed;
                this.transform.position = position;
            }
        }
        else
        {
            anim.enabled = false;
            leftright = false;
        }

    }
}
