using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MessagesPage : PageController {

	[SerializeField]
	private GameObject MessageListItemPrefab = null;

	[SerializeField]
	private GameObject ListContainer = null;

	[SerializeField]
	private Text title = null;

	[SerializeField]
	private ScrollRect scrollRect = null;

	[SerializeField]
	private InputField messageInput = null;

	private int rebuildViewUpdateTimer = 0;

	public override void Rebuild() {

		if (GameManager.Self.groupsPage.activeGroup == null)
			return;
  
		rebuildViewUpdateTimer = 4;

		title.text = GameManager.Self.groupsPage.activeGroup.Name;

		int childCount = ListContainer.transform.childCount;

		int i = 0;
		foreach (string message in GameManager.Self.groupsPage.activeGroup.Messages) {
			
			GameObject messageListItem;

			if (i >= childCount) {
				messageListItem = GameObject.Instantiate<GameObject>(MessageListItemPrefab);
			} else {
				messageListItem = ListContainer.transform.GetChild(i).gameObject;
			}

			//print(messageListItem.GetComponent<MessageListItemController>().MessageText.text);


			if (messageListItem.GetComponent<MessageListItemController>().Load(this, message, i)) {
				messageListItem.transform.SetParent(ListContainer.transform, false);
			} else {
				GameObject.Destroy(messageListItem);
				Debug.LogWarning("WARNING: MessageListItem failed to load.");
			}

			i++;
		}

		for (; i < childCount; i++) {
			GameObject.Destroy(ListContainer.transform.GetChild(i).gameObject);
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
		#if UNITY_EDITOR
		if (messageInput.text == ".del") {
			StartCoroutine(HttpManager.Self.DeleteGroup(GameManager.Self.groupsPage.activeGroup));
			return;
		}
		#endif

		string message = messageInput.text + "\n<color=#AAAAAAFF><size=30> - " + AccountManager.Self.Account.profile.Name + "</size></color>";
		StartCoroutine(HttpManager.Self.SendGroupMessage(GameManager.Self.groupsPage.activeGroup, message));
		messageInput.SetTextWithoutNotify("");
	}
}
