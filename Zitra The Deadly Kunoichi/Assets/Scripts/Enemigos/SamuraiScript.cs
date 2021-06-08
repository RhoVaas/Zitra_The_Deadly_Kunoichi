using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SamuraiScript : MonoBehaviour
{
	public GameObject Jugador;
	private Animator animator;
	public float healthPoints;
	private float LastAttack;
	public float dañoHecho;
	public float velocidad;
	public float knockbackForceX;
	public float knockbackForceY;

	private void Update()
	{
		animator = this.GetComponent<Animator>();
		Vector3 direction = Jugador.transform.position - transform.position;
		if (direction.x >= 0.0f) transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
		else transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);

		if (Time.time > LastAttack + 0.25f) animator.SetBool("samuraiAtaca", false);

		float distance = Mathf.Abs(Jugador.transform.position.x - transform.position.x);

		if (distance < 1.0f && Time.time > LastAttack + 0.25f)
		{
			Atacar();
			LastAttack = Time.time;
		}
	}

	private void Atacar(){
		Debug.Log("Atacar");
		animator.SetBool("samuraiAtaca", true);
	}
}
