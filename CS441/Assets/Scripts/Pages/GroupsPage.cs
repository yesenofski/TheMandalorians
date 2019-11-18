using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroupsPage : PageController {
	public override HeaderInfo HeaderInfo { get; set; }

	[SerializeField]
	private GameObject GroupListItemPrefab;

	[SerializeField]
	private GameObject ListContainer;

	public Group activeGroup = null;

	protected override void Rebuild() {

		int childCount = ListContainer.transform.childCount;

		//if (ListContainer.transform.childCount > 0) return;
		print(GroupListItemPrefab.GetInstanceID());
		int i = 0;
		foreach (Group group in AccountManager.Self.Account.Groups) {
			//print(2);
			GameObject groupListItem;

			if (i >= childCount) {
				groupListItem = GameObject.Instantiate<GameObject>(GroupListItemPrefab);
			} else {
				groupListItem = ListContainer.transform.GetChild(i).gameObject;
			}




			if (groupListItem.GetComponent<GroupListItemController>().Load(this, group)) {
				groupListItem.transform.SetParent(ListContainer.transform, false);
			} else {
				GameObject.Destroy(groupListItem);
				Debug.LogWarning("WARNING: GroupListItem failed to load.");
			}

			i++;
		}

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
