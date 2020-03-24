using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckHit : MonoBehaviour
{
    public GameObject scriptManager;
    public AudioSource monsterHit;
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

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "monster")
        {
            monsterHit.Play();
            collision.gameObject.SetActive(false);
            StartCoroutine(scriptManager.GetComponent<SurfaceChecker>().LateCall(collision.gameObject));
            SurfaceChecker.score++;
        }
    }
}

