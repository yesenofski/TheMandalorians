using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroupsPage : PageController {
	public override HeaderInfo HeaderInfo { get; set; }

	[SerializeField]
	private GameObject GroupListItemPrefab;
	[SerializeField]
	private GameObject NewGroupListItemPrefab;

	[SerializeField]
	private GameObject ListContainer;

	public Group activeGroup = null;

	private GameObject newGroup;

	public override void Rebuild() {

		int childCount = ListContainer.transform.childCount;

		//if (ListContainer.transform.childCount > 0) return;
		int i = 0;
		print("acc" + AccountManager.Self.Account.Groups.Count);
		foreach (Group group in AccountManager.Self.Account.Groups) {
			//print(2);
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

	}

	public void ShowNewGroup() {
		//ListContainer.

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
		GameObject.Destroy(newGroup);

		if (groupName.Length == 0)
			groupName = "Group";

		GameObject group = GameObject.Instantiate<GameObject>(GroupListItemPrefab);
		group.transform.SetParent(ListContainer.transform, false);
		group.transform.SetAsFirstSibling();

		group.GetComponent<GroupListItemController>().Load(new Group(groupName, "0"), ListContainer.transform.childCount);
	}


	protected override void BuildHeaderInfo() {
		HeaderInfo = new HeaderInfo {
			Visible = true,
			Title = "Groups",
			LeftButtonIsText = true,
			LeftButtonContent = "☰",
			RightButtonIsText = true,
			RightButtonContent = "+"
		};
	}
}
