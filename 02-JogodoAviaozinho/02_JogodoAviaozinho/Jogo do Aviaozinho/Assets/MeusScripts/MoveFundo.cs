using UnityEngine;
using System.Collections;

public class MoveFundo : MonoBehaviour { 

	private float larguraTela;

	void Start () { 
		GetComponent<Rigidbody2D>().velocity = new Vector2(-3,0);
		SpriteRenderer grafico = GetComponent<SpriteRenderer>();

		float larguraImagem = grafico.sprite.bounds.size.x;
		float alturaImagem = grafico.sprite.bounds.size.y;

		//		print(larguraImagem);
		//		print(alturaImagem);

		float alturaTela = Camera.main.orthographicSize*2f;

		//		Camera's half-size when in orthographic mode.
		//		This is half of the vertical size of the viewing volume. 
		//		Horizontal viewing size varies depending on viewport's aspect ratio.

		larguraTela = alturaTela/Screen.height*Screen.width;  
		//		The current height of the screen window in pixels

		Vector2 novaEscala = transform.localScale;
		novaEscala.x = larguraTela / larguraImagem + 0.25f; 
		novaEscala.y = alturaTela / alturaImagem;
		transform.localScale = novaEscala; 

		if (this.name == "imagemFundoB"){
			transform.position = new Vector2(larguraTela,0f);
		}
	}  

	void Update () { 
		if(transform.position.x <= -larguraTela){
			transform.position = new Vector2(larguraTela,0f); 
		}
	} 
}