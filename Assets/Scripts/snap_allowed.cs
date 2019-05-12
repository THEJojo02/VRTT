using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class snap_allowed : MonoBehaviour {

	Vector3 center;
	public GameObject left;
	public bool allowsnap;
    public GameObject snapzo;
    public GameObject objecttosnap;
    public GameObject snappos;
    public bool snapallow;
    public GameObject player;
    Vector3 pos;


////////////////////////////////////////////////////////////////////

    void Update () {
		pos= player.GetComponent<PluginWrapper> ().wpos ;
		if ( snapallow == true ) {
			player.GetComponent<PluginWrapper> ().snapzo = snapzo;
			player.GetComponent<PluginWrapper> ().objecttosnap = objecttosnap;
			player.GetComponent<PluginWrapper> ().snappos = snappos;
			player.GetComponent<PluginWrapper> ().snapallowed = true;
		} else {player.GetComponent<PluginWrapper> ().snapallowed = false;
			}
	}

	public void bahnanschauen(){	
		snapallow = true;	
	}

	public void bahnwegschauen(){
		snapallow = false;
	}
}
