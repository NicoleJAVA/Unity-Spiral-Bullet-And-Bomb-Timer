using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour 
{
	public Transform cameraTransform;
	public Transform targetTransform;
	public float height = 1.0f;
	public float distance = 1.0f;

	// Use this for initialization
	void Start () 
	{
	}
	
	// Update is called once per frame
	void Update () 
	{
		Vector3 offset = new Vector3(-distance*this.transform.forward.x,height,-distance*this.transform.forward.z);
		cameraTransform.position = this.transform.position + offset;
		cameraTransform.LookAt(targetTransform);
		print(targetTransform);
	}
}
