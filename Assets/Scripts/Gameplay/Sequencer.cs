    using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Sequencer : MonoBehaviour {
	public possibleValues[] sequence;
	public float timeToChange = 3;
	public float timeToStart = 1;
	private int sequenceIndex;
	public Button leftButton;
	public Button rigthButton;
	public float timeToWait = 0.5f;
	public Text resultLabel;

	public Color colorActive;
	public Color colorInactive;

	public string winMessage;
	public string loseMessage;

	private bool wasPressed;
	

	// Use this for initialization
	void Start () {
		StartCoroutine (changeSequence ());
	}

	IEnumerator changeSequence () {
		while (true) {
			//If there are elements yet to process
			if (sequenceIndex < sequence.Length) {
					switch (sequence [sequenceIndex]) {
					case possibleValues.left:
							leftButton.image.color = colorActive;
							rigthButton.image.color = colorInactive;
							break;
					case possibleValues.rigth:
							rigthButton.image.color = colorActive;
							leftButton.image.color = colorInactive;
							break;
					}
			} else {
					resultLabel.text = winMessage;
					break;
			}

			yield return new WaitForSeconds (timeToChange);

			//Veriify if user pressd the correct button
			if (wasPressed) {
					sequenceIndex++;
			} else {
				resultLabel.text = loseMessage;
				break;
			}

            rigthButton.image.color = colorInactive;
            leftButton.image.color = colorInactive;

			yield return new WaitForSeconds (timeToWait);

			wasPressed = false;
		}
	}
	
	
	public void press(string value)
	{
		if (sequence [sequenceIndex].ToString() == value) {
			wasPressed = true;
		}
	}
}

public enum possibleValues
{
	left,
	rigth
}