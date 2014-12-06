using UnityEngine;
using System.Collections;

public class LoadScene : MonoBehaviour {
	public void loadSceneByName(string name)
	{
		Application.LoadLevel (name);
	}

    public void reloadScene()
    {
        Application.LoadLevel(Application.loadedLevel);
    }
}
