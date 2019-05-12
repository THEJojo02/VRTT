using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelActivate : MonoBehaviour {

	
	public void activatePanel(GameObject Panel){
		Panel.SetActive (true);
	}

	public void deactivatePanel(GameObject Panel){
		Panel.SetActive (false);
	}
}
