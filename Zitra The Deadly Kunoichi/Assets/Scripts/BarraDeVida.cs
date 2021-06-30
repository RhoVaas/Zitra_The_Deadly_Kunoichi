using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarraDeVida : MonoBehaviour
{
    public Image barraDeVida;

    public float vidaActual;

    public float vidaMaxima;

    JugadorHealth vidaJugador;

    void Start(){
        vidaJugador = GetComponent<JugadorHealth>();
        vidaMaxima = vidaJugador.maximoSalud;
    }

    void Update(){
        vidaActual = vidaJugador.salud;
        barraDeVida.fillAmount = vidaActual / vidaMaxima;
    }


}
