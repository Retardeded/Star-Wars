using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionsHandler : MonoBehaviour {

    [SerializeField] float loadDelay = 1f;
    [SerializeField] GameObject deathFX;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter(Collider other)
    {
        deathFX.SetActive(true);
        StartDeathSequence();
    }

    private void StartDeathSequence()
    {
        Invoke("ReloadLevel", loadDelay);
        SendMessage("Death");
    }
    private void ReloadLevel()
    {
        SceneManager.LoadScene(1);
    }
}
