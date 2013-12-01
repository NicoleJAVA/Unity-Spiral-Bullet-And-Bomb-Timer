using UnityEngine;
using System.Collections;

public class CubeController : MonoBehaviour 
{
	public GameObject cubeGUI;
	GameFlowController tmpGFC;
	void Start()
	{
		//get GameFlowController (GUI)
		tmpGFC = cubeGUI.GetComponent<GameFlowController>();
	}
	void Update ()
	{
		//box dropping
		if(this.transform.position.y < -3)
		{
			//decrease GUI box count
			tmpGFC.cubeNum--;
			
			this.gameObject.SetActive(false);
			//Destroy(this.gameObject);
		}
	}
}
