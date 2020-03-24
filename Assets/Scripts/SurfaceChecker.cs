using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.Experimental.XR;
using UnityEngine.XR.ARSubsystems;

public class SurfaceChecker : MonoBehaviour
{
    public ARRaycastManager arRayCastMng;
    private bool canSpawn = false;
    private Pose placementPose;
    public GameObject placementIndicator;
    public GameObject monster;
    public GameObject projectile;
    public GameObject[] monsters;
    private int numMonster = 5;
    public static int countMonster = 0;
    public static int score = 0;
    public static int playerHealth = 100;

    //public Audioclip GunShoot;
    //public AudioSource audioSource;

    // Start is called before the first frame update
    private void Awake()
    {
        monsters = new GameObject[numMonster];
        for (int i = 0; i < numMonster; i++) {
            monsters[i] = Instantiate(monster,new Vector3(0f, 0f, 0f), monster.transform.rotation);
            monsters[i].SetActive(false);
            StartCoroutine(LateCall(monsters[i]));
        }
    }

    void Start()
    {
        //audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdatePlacementPose();
        UpdateTargetIndicator();
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) {
            //player touch the screen, spawn the prefab
            StartCoroutine(ShootBullet());
        }
    }

    private void UpdateTargetIndicator() {
        if (canSpawn)
        {
            //update the pos/rotation based on the placementPose
            placementIndicator.transform.SetPositionAndRotation(placementPose.position, placementPose.rotation);
        }
    }

    private void UpdatePlacementPose() {
        Vector3 screenCenter = Camera.current.ViewportToScreenPoint(new Vector3(0.5f, 0.5f, 0f));
        List<ARRaycastHit> hits = new List<ARRaycastHit>();

        arRayCastMng.Raycast(screenCenter, hits, TrackableType.All);

        canSpawn = hits.Count > 0;

        if (canSpawn) {
            placementPose = hits[0].pose;

            Vector3 cameraForward = Camera.current.transform.forward;
            Vector3 cameraBearing = new Vector3(cameraForward.x, 0f, cameraForward.z).normalized;
            placementPose.rotation = Quaternion.LookRotation(cameraBearing);
        }
    }

    public IEnumerator LateCall(GameObject monster) {
       while (true)
        {
            if (canSpawn)
            {
                //yield return new WaitForSeconds(3f);
                Vector3 myVector = new Vector3(Random.Range(-2, 2), Random.Range(-2, 2), Random.Range(-2, 2));
                monster.transform.SetPositionAndRotation(placementPose.position + myVector, placementPose.rotation);
                monster.SetActive(true);
                yield break;
            }
            yield return new WaitForSeconds(0.8f);
        }
    }

    IEnumerator ShootBullet()
    {
        Debug.Log("shoot");
        //audioSource.PlayOneShot(GunShoot);
        Vector3 rotation = new Vector3(Random.Range(-180, 180), Random.Range(-180, 180), Random.Range(-180, 180));
        GameObject bullet = Instantiate(projectile, Camera.current.transform.position, Quaternion.Euler(rotation));
        bullet.GetComponent<Rigidbody>().AddForce(Camera.current.transform.forward * 100);
        yield return new WaitForSeconds(5);
        Destroy(bullet);
    }
}
