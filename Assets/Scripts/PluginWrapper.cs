using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PluginWrapper : MonoBehaviour {

    private AndroidJavaObject javaClass;
    bool cansnap = false;
    public GameObject hand;
    public GameObject objectA;
    Transform objectB;
    public bool angeschaut = false;

    public bool snapallowed;
    Vector3 npos;

    public GameObject snapzo;
    public GameObject objecttosnap;
    public GameObject snappos;
    bool enter = true;

    public GameObject pointer;
    public Vector3 wpos;

    GameObject oA;
    bool panelactive = false;
    public GameObject camera;


////////////////////////////////////////////////////////////////////////////

    void Start () {
        javaClass = new AndroidJavaObject("com.example.vrlibrary.Keys");
		Physics.IgnoreLayerCollision(9, 8);
		Physics.IgnoreLayerCollision(8, 8);
		objectB = hand.transform;
	}

	void Update () {
		if (snapzo != null) {
			cansnap = snapzo.GetComponent<snap_allowed>().snapallow;
		}
    }

	public void greifen(string ok){
		//greifen
		if ((ok == "1") && (angeschaut == true)) {
			if (hand.transform.childCount == 0) {
				objectA.transform.position = objectB.position;
				objectA.transform.rotation = Quaternion.Euler(0,0,0);
				objectA.transform.parent = objectB;
				objectA.GetComponent<Rigidbody>().useGravity = false;
            }
        }
		//loslassen
		else if ((ok == "1")&&(hand.transform.childCount == 1)){
			getpospointer ();
			hand.transform.DetachChildren ();
			objectA.GetComponent<Rigidbody> ().useGravity = true;
			npos.x = wpos.x;
			npos.z = wpos.z;
			npos.y = wpos.y+0.1f;
			objectA.transform.position = npos;
			//Objekt darf snappen --> snap
			if ((snapallowed = true)&&(objecttosnap==objectA)&&(cansnap == true)) {
				snap ();
			} 
            else 
            { objectA.GetComponent<Rigidbody> ().useGravity = true; }
		}
	}

	public void snap(){
		OnTriggerStay (snapzo.GetComponent<Collider> ());			
	}

	//snappen, wenn Objekt richtig und sich im Collider der Snap Zone befindet
	void OnTriggerStay(Collider other)
	{
		if( (enter)&& (snapallowed)) {
			objectA.GetComponent<Rigidbody> ().useGravity = false;
			objectA.GetComponent<Collider> ().enabled = false;
			objectA.transform.rotation = snappos.transform.rotation;
			objectA.transform.position = snappos.transform.position;
			objectA.GetComponent<Rigidbody> ().constraints = RigidbodyConstraints.FreezeAll;
			objectA.transform.localScale = snappos.transform.localScale;
		} 
	}

	public void anschauen(){
		angeschaut = true;
	}

	public void wegschauen(){
		angeschaut = false;
	}

	//Position, auf die man schaut
	public void getpospointer(){
		wpos = pointer.GetComponent<GvrReticlePointer> ().CurrentRaycastResult.worldPosition;
	}

	//Panel auf Objekt aktivieren / deaktivieren mit Knopfdruck über Kopfhörertasten
	public void infopanel(string oki) {
		if ((oki == "1")&&(hand.transform.childCount == 1)&&(panelactive == false)){
			oA = objectA.transform.Find ("PanelMenu").gameObject;
			oA.SetActive (true);
			panelactive = true;
			oA.transform.LookAt (camera.transform);
		
			
		} else	if ((panelactive == true)&&(hand.transform.childCount == 1)&&(oki == "1")){
			oA.SetActive (false);
			panelactive = false;
	    }
	}
}
