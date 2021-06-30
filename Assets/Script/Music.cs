using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Music : MonoBehaviour
{
    void Awake()
    {
        int numOfMusic = FindObjectsOfType<Music>().Length;
        if(numOfMusic > 1)
        {
            DestroyObject(gameObject);
        } else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
    void Start()
    {
        Invoke("Load", 2f);
    }
    void Load()
    {
        SceneManager.LoadScene(1);
    }
}

