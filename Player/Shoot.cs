using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour
{
	public AudioClip shootAudio;
	private AudioSource audioSource;
	public GameObject bulletPrefab;
	public GameObject fireParticle;
	/****/
	public GameObject bombPrefab;
	public float fireRate = 0.1f;
	
	private float nextFire = 0.0f;
	private bool shooting = false;
	private int gunMode = 1;
	
	void Start()
	{
		audioSource = GetComponent<AudioSource>();
		
	}

	// Update is called once per frame
	void Update ()
	{
		//use mouse to fire
		if (Input.GetButtonDown ("Fire1"))
			shooting = true;
		if (Input.GetButtonUp ("Fire1"))
			shooting = false;
		
		//use keyboard to change gun type
		if (Input.GetKey("1"))
			gunMode = 1;
		else if(Input.GetKey("2"))
			gunMode = 2;
		else if(Input.GetKey("3"))
			gunMode = 3;
		else if(Input.GetKey("4"))
			gunMode = 4;
		else if(Input.GetKey("5"))
			gunMode = 5;
		
		if (shooting)
		{
			if(gunMode == 1  && Time.time > nextFire)
			{
				fireParticle.SetActive(false);
				audioSource.PlayOneShot(shootAudio);
				GameObject bullet = (GameObject)Instantiate(bulletPrefab,this.transform.position + this.transform.forward + this.transform.up, Quaternion.identity);
				
				BasicBullet bulletComp = bullet.GetComponent<BasicBullet>();
				bulletComp.changeVelocity(this.transform.forward * 10f);
				nextFire = Time.time + fireRate;
			}
			else if(gunMode == 2)
			{
				fireParticle.SetActive(true);
			}
			//TO DO
			else if(gunMode == 3 && Time.time > nextFire)
			{
				fireParticle.SetActive(false);
				audioSource.PlayOneShot(shootAudio);
				for(int i =0; i<3; i++){
					GameObject bullet1 = (GameObject)Instantiate(bulletPrefab,this.transform.position + this.transform.forward + this.transform.up, Quaternion.identity);
				}
					nextFire = Time.time + fireRate;		
			}
			else if(gunMode == 4)
			{
				fireParticle.SetActive(true);
			}
			else if(gunMode == 5 && Time.time > nextFire)
			{
				fireParticle.SetActive(false);
				GameObject bomb1 = (GameObject)Instantiate(bombPrefab,this.transform.position+this.transform.forward, Quaternion.identity);
				BasicBomb bombComp = bomb1.GetComponent<BasicBomb>();
				bombComp.changeVelocity(this.transform.forward * 10f );
				nextFire = Time.time + fireRate;
			}
			
			
			
		}
		else
		{
			if(gunMode == 2)
			{
				fireParticle.SetActive(false);
			}
			if(gunMode == 4)
			{
				fireParticle.SetActive(false);
			}
		
		}
	}
	
	void OnTriggerStay(Collider other)
	{
		//for Flamethrower
		if(gunMode == 2)
		{
			if (other.attachedRigidbody)
        	other.attachedRigidbody.AddForce(this.transform.forward * 50f);
		}
		if(gunMode == 4)
		{
			if (other.attachedRigidbody)
        	other.attachedRigidbody.AddForce(this.transform.forward * 50f);
		}
	
	
	}
}
