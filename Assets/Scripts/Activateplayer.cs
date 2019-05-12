using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activateplayer : MonoBehaviour {
	public GameObject player;
	// Use this for initialization
	void Start () {
		player.SetActive (true);
		player.GetComponent<PluginWrapper> ().enabled = true;
	}
	

}
