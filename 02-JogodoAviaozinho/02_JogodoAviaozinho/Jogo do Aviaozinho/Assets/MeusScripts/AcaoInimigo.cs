using UnityEngine;
using System.Collections;

public class AcaoInimigo : MonoBehaviour {

	GameObject objetoFelpudo;
	bool marcouPonto;
	void Start () {
		GetComponent<Rigidbody2D>().velocity = new Vector2(-4,0);;
		objetoFelpudo = GameObject.FindGameObjectWithTag("Player");
	}

	void Update()
	{ 
		if (transform.position.x < -25)
		{ 
			Destroy(gameObject);
		}else{
			if (transform.position.x < objetoFelpudo.transform.position.x)
			{ 
				if (!marcouPonto){
					marcouPonto=true; 
					GetComponent<Rigidbody2D>().velocity = new Vector2(-7.5f,5);

					GetComponent<Rigidbody2D>().isKinematic=false; 
					GetComponent<Rigidbody2D>().AddTorque(-50f); 
					GetComponent<SpriteRenderer>().color = new Color(1f,0.3f,0.3f,0.75f);
					objetoFelpudo.SendMessage("Pontua");
				} 
			}
		}
	}
}
