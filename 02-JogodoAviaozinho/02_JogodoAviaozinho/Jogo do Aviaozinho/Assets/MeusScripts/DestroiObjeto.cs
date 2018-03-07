using UnityEngine;
using System.Collections;

public class DestroiObjeto : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Invoke("ApagaObjeto", 2f);
	} 

	void ApagaObjeto(){

		Destroy(this.gameObject);

	}
}
