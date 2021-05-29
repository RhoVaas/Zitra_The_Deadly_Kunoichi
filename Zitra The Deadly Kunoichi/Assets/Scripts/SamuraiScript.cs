using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SamuraiScript : MonoBehaviour
{
	public GameObject Jugador;

	private void Update()
	{
		Vector3 direction = Jugador.transform.position - transform.position;
		if (direction.x >= 0.0f) transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
		else transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
	}
}
