using UnityEngine;
using System.Collections;

public class CameraFollowingPlayerManager : MonoBehaviour {
    public Transform target;
    public float smoothing;

    private Vector3 offset;

    // Use this for initialization
    void Start()
    {
        offset = transform.position - target.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 targetCameraPos = target.position + offset;
        transform.position = Vector3.Lerp(transform.position, targetCameraPos, smoothing * Time.deltaTime);
    }
}

