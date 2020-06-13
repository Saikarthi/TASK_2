using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyfellow : MonoBehaviour
{
    private Transform t;
    

    public float speed;
  //  public float stopdis;

    // Start is called before the first frame update
    void Start()
    {
      
        t = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, t.position) > 0)
        {
            transform.position = Vector2.MoveTowards(transform.position, t.position, speed * Time.deltaTime);
        }

    }
}
