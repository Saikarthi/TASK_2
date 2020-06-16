using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class h_upadate_ui : MonoBehaviour
{
    public Health h;
    public TextMeshProUGUI t;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        t.text = h.health.ToString("0");
    }
}
