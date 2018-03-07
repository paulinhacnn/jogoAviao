using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ControlaJogador : MonoBehaviour {

	private bool comecouJogo;
	private bool acabouJogo; 
	private int pontuacao;
	public Text textoScore;
	GameObject objetoGameEngine;

	Vector2 forcaImpulso = new Vector2(0,500);

	public GameObject objetoParticulasPenas;
 
	void Start () {
		objetoGameEngine = GameObject.FindGameObjectWithTag("MainCamera");

		float larguraTela = (Camera.main.orthographicSize*2f)/Screen.height*Screen.width;   
		transform.position = new Vector2(-larguraTela/4,0f); 
 
		textoScore.transform.position = new Vector2(Screen.width/2,Screen.height - 250);  
		textoScore.text = "Toque para iniciar!";
		textoScore.fontSize = 35; 
	} 

	void Update () { 
		if(!acabouJogo){
			if(Input.GetButtonDown("Fire1")){  
				if(!comecouJogo){
					comecouJogo=true;
					GetComponent<Rigidbody2D>().isKinematic = false; 

					textoScore.text = pontuacao.ToString();
					textoScore.fontSize = 100;
					textoScore.color = new Color(0.95f,1.0f,0.35f);  
				}
				GameObject particula = Instantiate(objetoParticulasPenas);
				particula.transform.position = this.transform.position; 
				GetComponent<Rigidbody2D>().velocity = Vector2.zero;
				GetComponent<Rigidbody2D>().AddForce(forcaImpulso); 
			}

			transform.rotation = Quaternion.Euler(0,0,GetComponent<Rigidbody2D>().velocity.y * 3f);

			float posicaoFelpudoEmPixels = Camera.main.WorldToScreenPoint(transform.position).y;

			if(posicaoFelpudoEmPixels > Screen.height || posicaoFelpudoEmPixels <0){ 
				if(!acabouJogo){
					GetComponent<SpriteRenderer>().color = new Color(1f,0.75f,0.75f,1.0f);
					acabouJogo = true;
					FimDejogo();
				}
//				Destroy(this.gameObject);
			}
		} 
	} 
	void OnCollisionEnter2D()
	{ 
		if(!acabouJogo){
			GetComponent<Collider2D>().enabled = false;
			GetComponent<Rigidbody2D>().velocity = Vector2.zero;
			GetComponent<Rigidbody2D>().AddForce(new Vector2(-400,0));
			GetComponent<Rigidbody2D>().AddTorque(300f);
			GetComponent<SpriteRenderer>().color = new Color(1f,0.75f,0.75f,1.0f);
			acabouJogo = true;
			Invoke("FimDejogo", 1);
		}
	} 
	void FimDejogo()
	{
		objetoGameEngine.SendMessage("FinalizarJogo");
		Invoke("RecarregaCena", 2);
	} 

	void Pontua(){
		pontuacao++;
		textoScore.text = pontuacao.ToString();
		print(pontuacao);
	}

	void RecarregaCena(){
		Application.LoadLevel("Minha Cena");
	}
}
