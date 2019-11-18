using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessagesPage : PageController {
	public override HeaderInfo HeaderInfo { get; set; }

	[SerializeField]
	private GameObject MessageListItemPrefab;

	[SerializeField]
	private GameObject ListContainer;

	protected override void Rebuild() {

		int childCount = ListContainer.transform.childCount;

		int i = 0;
		foreach (string message in PageManager.Self.groupPage.activeGroup.Messages) {
			//print(2);
			GameObject messageListItem;

			if (i >= childCount) {
				messageListItem = GameObject.Instantiate<GameObject>(MessageListItemPrefab);
			} else {
				messageListItem = ListContainer.transform.GetChild(i).gameObject;
			}




			if (messageListItem.GetComponent<MessageListItemController>().Load(this, message)) {
				messageListItem.transform.SetParent(ListContainer.transform, false);
			} else {
				GameObject.Destroy(messageListItem);
				Debug.LogWarning("WARNING: MessageListItem failed to load.");
			}

			i++;
		}

	}

	protected override void BuildHeaderInfo() {
		HeaderInfo = new HeaderInfo {
			Visible = true,
			Title = "Messages",
			LeftButtonIsText = true,
			LeftButtonContent = "☰",
			RightButtonIsText = true,
			RightButtonContent = "+"
		};
	}
}
