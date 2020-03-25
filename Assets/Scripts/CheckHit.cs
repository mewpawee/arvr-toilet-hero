using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CheckHit : MonoBehaviour
{
    public GameObject scriptManager;
<<<<<<< HEAD
    public AudioSource monsterHit;
=======
    public int TargetScore = 120;
    public int YourScore = 0;
   
>>>>>>> new-gui-ar
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
<<<<<<< HEAD
            monsterHit.Play();
=======
            YourScore += 1;

>>>>>>> new-gui-ar
            collision.gameObject.SetActive(false);
            StartCoroutine(scriptManager.GetComponent<SurfaceChecker>().LateCall(collision.gameObject));
            SurfaceChecker.score++;
            UserData.score += 1;
            if (YourScore > TargetScore) {
                SceneManager.LoadScene(2);
            }
        }
    }
}

