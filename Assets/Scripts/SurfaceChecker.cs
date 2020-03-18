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
    public GameObject spawningObject;
    public GameObject projectile;
    private int limitMonster = 5;
    public static int countMonster = 0;
    // Start is called before the first frame update
    void Start()
    {
        
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
        if (canSpawn && countMonster < limitMonster) {
            StartCoroutine(SpawnMonster(spawningObject));
        }
    }

    private void UpdateTargetIndicator() {
        if (canSpawn)
        {
            //show the placement indicator
            //update the pos/rotation based on the placementPose
            placementIndicator.SetActive(true);
            placementIndicator.transform.SetPositionAndRotation(placementPose.position, placementPose.rotation);
        }
        else {
            //hide the placement indicator
            placementIndicator.SetActive(false);
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

    IEnumerator SpawnMonster(GameObject monster) {
        while (canSpawn && countMonster < limitMonster)
        {
            Vector3 myVector = new Vector3(Random.Range(-2, 2), Random.Range(-2, 2), Random.Range(-2, 2));
            Instantiate(monster, placementPose.position + myVector, placementPose.rotation);
            yield return new WaitForSeconds(0.2f);
            countMonster++;
        }
    }

    IEnumerator ShootBullet()
    {
        Debug.Log("shoot");
        GameObject bullet = Instantiate(projectile, Camera.current.transform.position, Quaternion.identity) as GameObject;
        bullet.GetComponent<Rigidbody>().AddForce(Camera.current.transform.forward * 100);
        yield return new WaitForSeconds(5);
        Destroy(bullet);
    }
}
