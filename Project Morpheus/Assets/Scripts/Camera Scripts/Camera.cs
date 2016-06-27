using UnityEngine;
using System.Collections;

public class Camera : MonoBehaviour {

    public Transform target;
    public float smoothing;

    private Vector3 offset;
    private Vector3 targetCameraPos;

	// Use this for initialization
	void Start () {
        offset = transform.position - target.position;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        targetCameraPos = target.position + offset;
        transform.position = Vector3.Lerp(transform.position, targetCameraPos, smoothing * Time.deltaTime);
	}
}
