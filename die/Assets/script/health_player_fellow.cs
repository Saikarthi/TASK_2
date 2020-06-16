using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class health_player_fellow : MonoBehaviour
{

    public GameObject g;
    private Vector2 fellow;
    public float x;
    public float y;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        fellow = g.transform.position;
        fellow.y += y;
        fellow.x -= x;
        transform.position = fellow;
    }
}
