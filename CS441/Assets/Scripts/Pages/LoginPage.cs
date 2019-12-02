using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoginPage : PageController
{

	private bool waiting = false;

	[SerializeField]
	private InputField Username = null;

	private void Start() {
		GetComponent<Animator>().SetTrigger("Activate");
	}

	private void Update() {
		if (HttpManager.Self.loaded && waiting) {
			Shift("left");
			waiting = false;
			HttpManager.Self.loaded = false;
		}
	}

	public override void Rebuild() {
		return;
	}

	public void Login() {

		if (AccountManager.Self.Login(Username.text.Length == 0 ? "Anonymous" : Username.text)) {
			//PageManager.Self.Next("Groups Page");
			waiting = true;
		}
	}

}
