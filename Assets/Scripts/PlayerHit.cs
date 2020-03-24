using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHit : MonoBehaviour
{
    public GameObject scriptManager;

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
    {
        if (other.gameObject.tag == "monster")
        {
            other.gameObject.SetActive(false);
            StartCoroutine(scriptManager.GetComponent<SurfaceChecker>().LateCall(other.gameObject));
            SurfaceChecker.playerHealth = SurfaceChecker.playerHealth - 10;
        }
    }
}
