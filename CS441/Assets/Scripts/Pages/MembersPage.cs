using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MembersPage : PageController
{

	[SerializeField]
	private GameObject MemberListItemPrefab = null;

	[SerializeField]
	private GameObject ListContainer = null;

	public override void Rebuild() {
		for (int i = 0; i < 20; i++) {
			GameObject memberListItem = GameObject.Instantiate<GameObject>(MemberListItemPrefab);

			if (memberListItem.GetComponent<MemberListItemController>().Load()) {
				memberListItem.transform.SetParent(ListContainer.transform, false);
			} else {
				GameObject.Destroy(memberListItem);
				Debug.LogWarning("WARNING: MemberListItem failed to load.");
			}
		}
	}
}
