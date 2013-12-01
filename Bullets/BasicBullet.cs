using UnityEngine;
using System.Collections;

public class BasicBullet : MonoBehaviour
{
	public float speed = 5.0f;
	public float DestroyTime = 10.0f;
	public Vector3 velocity;
	
	public void changeVelocity(Vector3 v)
	{
		velocity = v;
	}

	void Start ()
	{
		Destroy (gameObject, DestroyTime);
	}


	void FixedUpdate ()
	{
		// TO DO
		velocity = Quaternion.AngleAxis(30, Vector3.forward) * velocity;
		transform.position += velocity * Time.deltaTime;
		
		
	}
	
}
