using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collide_check : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnCollisionEnter2D(Collision2D co)
    {
        if(co.gameObject.tag =="Player")
        {
            Debug.Log("1");
            Destroy(this.gameObject);
        }
    }
}
