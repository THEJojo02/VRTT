using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabableObject : MonoBehaviour {

	public GameObject player;
	public GameObject hand;
	public GameObject objecttograb;



	public void setobject(){
		if (hand.transform.childCount == 0) {
			player.GetComponent<PluginWrapper> ().objectA = objecttograb;
		}

	
	}


}
