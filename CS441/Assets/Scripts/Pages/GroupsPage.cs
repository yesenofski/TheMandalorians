using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroupsPage : PageController {

	[SerializeField]
	private GameObject GroupListItemPrefab = null;
	[SerializeField]
	private GameObject NewGroupListItemPrefab = null;

	[SerializeField]
	private GameObject ListContainer = null;

	public Group activeGroup = null;

	private GameObject newGroup = null;

	public override void Rebuild() {
		int childCount = ListContainer.transform.childCount;

		int i = 0;

		foreach (Group group in AccountManager.Self.Account.Groups) {
			GameObject groupListItem;

			if (i >= childCount) {
				groupListItem = GameObject.Instantiate<GameObject>(GroupListItemPrefab);
			} else {
				groupListItem = ListContainer.transform.GetChild(i).gameObject;
			}

			if (groupListItem.GetComponent<GroupListItemController>().Load(group, i)) {
				groupListItem.transform.SetParent(ListContainer.transform, false);
			} else {
				GameObject.Destroy(groupListItem);
				Debug.LogWarning("WARNING: GroupListItem failed to load.");
			}

			i++;
		}

		for (; i < childCount; i++) {
			GameObject.Destroy(ListContainer.transform.GetChild(i).gameObject);
		}
	}

	public void ShowNewGroup() {

		if (newGroup != null) {
			SaveNewGroup();
		}

		newGroup = GameObject.Instantiate<GameObject>(NewGroupListItemPrefab);

		newGroup.transform.SetParent(ListContainer.transform, false);
		newGroup.transform.SetAsFirstSibling();

		var newController = newGroup.GetComponent<NewGroupListItemController>();
			
		newController.groupPage = this;
		newController.GroupNameInput.Select();


	}

	public void SaveNewGroup() {
		string groupName = newGroup.GetComponent<NewGroupListItemController>().GroupNameInput.text.Trim();
		newGroup.transform.SetParent(null);
		GameObject.Destroy(newGroup);

		if (groupName.Length == 0)
			groupName = "Group";

		StartCoroutine(HttpManager.Self.CreateGroup(groupName));

		//AccountManager.Self.Account.Groups.Insert(0, new Group(groupName, "0"));

		//Rebuild();
	}
}
