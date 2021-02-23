using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class help : MonoBehaviour
{
    public GameObject a, b;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("intro2", 7);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void intro2()
    {
        a.SetActive(false);
        b.SetActive(true);
        Invoke("playgame", 7);
    }
    public void playgame()
    {
        SceneManager.LoadScene(1);
    }
}