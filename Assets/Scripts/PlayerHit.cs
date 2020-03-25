using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHit : MonoBehaviour
{
    public GameObject scriptManager;
    public AudioSource playerKilled;
    private void Awake()
    {
        scriptManager = GameObject.Find("Script Manager");
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {   // Collision between Monster and Player
        if (other.gameObject.tag == "monster")
        {
            other.gameObject.SetActive(false);
            StartCoroutine(scriptManager.GetComponent<SurfaceChecker>().LateCall(other.gameObject));
            playerKilled.Play();
            SurfaceChecker.playerHealth = SurfaceChecker.playerHealth - 10;
            UserData.score = 0;
            SceneManager.LoadScene(3);
            
        }
    }
}
