using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Secuenciador : MonoBehaviour {
	public posiblesValores[] secuencia;
	public float tiempoParaCambiar;
	public float tiempoParaIniciar = 1;
	private int indiceSecuencia;
	public Button botonIzquierda;
	public Button botonDerecha;
	public float tiempoEspera = 0.5f;
	public Text resultado;

	public Color colorActivado;
	public Color colorDesactivado;

	public string mensajeGanar = "Ganaste";
	public string mensajePerder = "Perdiste";

	private bool presiono;
	

	// Use this for initialization
	void Start () {
		StartCoroutine (cambiarSecuencia ());
	}

	IEnumerator cambiarSecuencia () {
		while (true) {
						//Si quedan elementos por proccesar
						if (indiceSecuencia < secuencia.Length) {
								switch (secuencia [indiceSecuencia]) {
								case posiblesValores.izquierda:
										botonIzquierda.image.color = colorActivado;
										botonDerecha.image.color = colorDesactivado;
										break;
								case posiblesValores.derecha:
										botonDerecha.image.color = colorActivado;
										botonIzquierda.image.color = colorDesactivado;
										break;
								}
						} else {
								resultado.text = mensajeGanar;
								break;
						}

						yield return new WaitForSeconds (tiempoParaCambiar);

						//verificar si no se equivoco
						if (presiono) {
								indiceSecuencia++;
						} else {
							resultado.text = mensajePerder;
							break;
						}

			botonDerecha.image.color = colorDesactivado;
			botonIzquierda.image.color = colorDesactivado;
			
			yield return new WaitForSeconds (tiempoEspera);

			presiono = false;
		}
	}
	
	
	public void presionar(string valor)
	{
		if (secuencia [indiceSecuencia].ToString() == valor) {
			presiono = true;
		}
	}
}

public enum posiblesValores
{
	izquierda,
	derecha
}