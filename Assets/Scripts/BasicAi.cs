using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicAi : MonoBehaviour
{
    void Update()
    {
        //Vector3 offset = new Vector3(0f,-5f,0f);
        Transform cameraTransform = Camera.current.transform;
        //cameraTransform.position = cameraTransform.position + offset;
        this.transform.LookAt(cameraTransform);
        this.transform.Translate(Vector3.forward * 5 * Time.deltaTime);
    }

}
