using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewGroupListItemController : MonoBehaviour {

	public GroupsPage groupPage;

	public InputField GroupNameInput;

	// Start is called before the first frame update
	void Start() {

	}

	// Update is called once per frame
	void Update() {

	}

	public void SaveGroup() {
		groupPage.SaveNewGroup();
	}
}
