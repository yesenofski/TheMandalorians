using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MessagesPage : PageController {
	public override HeaderInfo HeaderInfo { get; set; }

	[SerializeField]
	private GameObject MessageListItemPrefab;

	[SerializeField]
	private GameObject ListContainer;

	[SerializeField]
	private Text title;

	[SerializeField]
	private ScrollRect scrollRect;

	[SerializeField]
	private InputField messageInput;

	private int rebuildViewUpdateTimer = 0;

	public override void Rebuild() {

		print("Message rebuild");

		rebuildViewUpdateTimer = 4;

		title.text = GameManager.Self.groupsPage.activeGroup.Name;

		int childCount = ListContainer.transform.childCount;

		int i = 0;
		foreach (string message in GameManager.Self.groupsPage.activeGroup.Messages) {
			//print(2);
			GameObject messageListItem;

			if (i >= childCount) {
				messageListItem = GameObject.Instantiate<GameObject>(MessageListItemPrefab);
			} else {
				messageListItem = ListContainer.transform.GetChild(i).gameObject;
			}




			if (messageListItem.GetComponent<MessageListItemController>().Load(this, message, i)) {
				messageListItem.transform.SetParent(ListContainer.transform, false);
			} else {
				GameObject.Destroy(messageListItem);
				Debug.LogWarning("WARNING: MessageListItem failed to load.");
			}

			i++;
		}


	}

	private void Update() {
		if (rebuildViewUpdateTimer > 0) {
			rebuildViewUpdateTimer--;

			if (rebuildViewUpdateTimer == 0) {
				ListContainer.GetComponent<VerticalLayoutGroup>().CalculateLayoutInputVertical();
				scrollRect.verticalNormalizedPosition = 0.0f;
			}
		}
	}

	public void Send() {
		StartCoroutine(HttpManager.Self.SendGroupMessage(GameManager.Self.groupsPage.activeGroup, messageInput.text));
		messageInput.SetTextWithoutNotify("");
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
