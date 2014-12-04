using UnityEngine;
using System.Collections;

public class CargarEscena : MonoBehaviour {
	public void cargarEscenaPorNombre(string nombre)
	{
		Application.LoadLevel (nombre);
	}
}
