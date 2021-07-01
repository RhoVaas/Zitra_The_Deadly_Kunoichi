using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralSamuraiScript : MonoBehaviour
{
    public GameObject Jugador;
	private Animator animator;
	Rigidbody2D rb2b;
	Vector3 posicionInicial;

    public float healthPoints;
    private float LastAttack;
    public float dañoHecho;
	public int rutina;
	public float cronometro;
	public int direccionEnemigo;
	public float velocidad;
	public bool atacando;

	public float radioAtaque;
	public float radioVision;
	public GameObject rango;
	public GameObject hit;	
	public float knockbackForceX;
	public float knockbackForceY;

	private void Start() {
		Jugador = GameObject.FindGameObjectWithTag("Player");
		posicionInicial = transform.position;
		rb2b = GetComponent<Rigidbody2D>();
		animator = this.GetComponent<Animator>();
	}

    public void Comportamiento(){
		if(Mathf.Abs(transform.position.x - Jugador.transform.position.x) > radioVision && !atacando){

			animator.SetBool("generalCorre", false);
			cronometro += 1 * Time.deltaTime;
			if(cronometro >= 4){
				rutina = Random.Range(0,2);
				cronometro = 0;
			}
			switch(rutina){
				case 0:
					animator.SetBool("generalCorre", false);
					break;

				case 1:
					direccionEnemigo = Random.Range(0,2);
					rutina++;
					break;
			
				case 2:
					switch(direccionEnemigo){
						case 0:
							transform.rotation = Quaternion.Euler(0,0,0);
							transform.Translate(Vector3.right * velocidad * Time.deltaTime);
							break;
					
						case 1:
							transform.rotation = Quaternion.Euler(0,180,0);
							transform.Translate(Vector3.right * velocidad * Time.deltaTime);
							break;
					}
				animator.SetBool("generalCorre", true);
				break;
			}

		}else{
			if(Mathf.Abs(transform.position.x - Jugador.transform.position.x) > radioAtaque && !atacando){
				if(transform.position.x < Jugador.transform.position.x){
					animator.SetBool("generalCorre", true);
					transform.Translate(Vector3.right * velocidad * Time.deltaTime);
					transform.rotation = Quaternion.Euler(0,0,0);
					Atacar();
					LastAttack = Time.time;
				}else{
					animator.SetBool("generalCorre", true);
					transform.Translate(Vector3.right * velocidad * Time.deltaTime);
					transform.rotation = Quaternion.Euler(0,180,0);
					Atacar();
					LastAttack = Time.time;
				}
			}
			else{
				if(!atacando){
					if(transform.position.x < Jugador.transform.position.x){
						transform.rotation = Quaternion.Euler(0,0,0);
					}else{
						transform.rotation = Quaternion.Euler(0,180,0);
					}
					animator.SetBool("generalCorre", false);
				}
			}
		}
		
	}

	public void FinalAnimacion(){
		animator.SetBool("generalAtaca", false);
		atacando = false;
		rango.GetComponent<BoxCollider2D>().enabled = true;
	}

	public void ColliderWeaponTrue(){
		hit.GetComponent<BoxCollider2D>().enabled = true;
	}

	public void ColliderWeaponFalse(){
		hit.GetComponent<BoxCollider2D>().enabled = false;
	}

	private void Update()
	{
		Comportamiento();
	}

    public void Atacar(){
		Debug.Log("Atacar");
		animator.SetBool("generalAtaca", true);
	}
}
