using UnityEngine;
using System.Collections;

public class GameEngine : MonoBehaviour {

	public GameObject inimigo; 

	void Start()
	{  
		InvokeRepeating("CriaInimigo",1,1.5f);
	}
	
	void CriaInimigo(){ 
		float alturaAleatoria = 10f * Random.value - 5;
		GameObject novoInimigo = Instantiate(inimigo);
		novoInimigo.transform.position = new Vector2(15f, alturaAleatoria); 
	}

	void FinalizarJogo(){

		CancelInvoke("CriaInimigo"); 
		  
	} 
}
