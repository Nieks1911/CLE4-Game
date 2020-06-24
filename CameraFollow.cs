using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public Transform target;
    public Vector3 offset;
    public float smoothTime = 0.3f;

    private Vector3 velocity;

    private void Awake()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void LateUpdate() {
        transform.position = Vector3.SmoothDamp(transform.position, target.position + offset, ref velocity, smoothTime);
    }

    public void ChangeCam(bool BossB)
    {
        if (BossB)
        {
            target = GameObject.FindGameObjectWithTag("BossRoom").GetComponentInChildren<GhostPos>().transform;
            gameObject.GetComponent<Camera>().orthographicSize = 14;
        }
        else
        {
            target = GameObject.FindGameObjectWithTag("Player").transform;
            gameObject.GetComponent<Camera>().orthographicSize = 8;
        }
    }
}
