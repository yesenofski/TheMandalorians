using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MessageListItemController : MonoBehaviour {

	public Text MessageText;

	private string message;

	[SerializeField]
	private Image line = null;

	// Start is called before the first frame update
	void Start() {

	}

	// Update is called once per frame
	void Update() {

	}

	public bool Load(MessagesPage messagePageIn, string messageIn, int index) {
		message = messageIn;
		//print(messageIn);
		MessageText.text = message;
		//gameObject.SetActive(false);
		//gameObject.SetActive(true);

		line.color = Color.HSVToRGB((index % 9) / 9.0f, 0.6f, 1);

		return true;
	}
}
