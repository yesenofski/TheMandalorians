using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MessageListItemController : MonoBehaviour {

	private MessagesPage messagePage;

	public Text MessageText;

	private string message;

	// Start is called before the first frame update
	void Start() {

	}

	// Update is called once per frame
	void Update() {

	}

	public bool Load(MessagesPage messagePageIn, string messageIn) {
		messagePage = messagePageIn;
		message = messageIn;

		MessageText.text = "  " + message;

		return true;
	}

	public void OpenMessage() {
		//messagePage.activeMessage = message;
		messagePage.Shift("left");


	}
}
