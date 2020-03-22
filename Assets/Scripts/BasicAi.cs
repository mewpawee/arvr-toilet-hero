using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicAi : MonoBehaviour
{
    void Update()
    {
        Transform cameraPosition = Camera.current.transform;
        this.transform.LookAt(cameraPosition);
        this.transform.Translate(Vector3.forward * 5 * Time.deltaTime);
    }
}
