using UnityEngine;
using System.Collections;

public class GameFlowController : MonoBehaviour 
{
	public int cubeNum;
	public GUIText winGUI;
	public GUIText loseGUI;
	public GameObject player;
	// Use this for initialization
	void Start () 
	{
		cubeNum = 10;
		this.guiText.text = "Cubes: " + cubeNum;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(cubeNum>0)
			this.guiText.text = "Cubes: " + cubeNum;
		else
		{
			winGUI.guiText.enabled = true;
			this.guiText.enabled = false;
		}
		
		if(player.transform.position.y < -3)
		{
			loseGUI.guiText.enabled = true;
			this.guiText.enabled = false;
		}
	}
}
