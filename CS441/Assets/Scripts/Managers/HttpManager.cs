using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.Text;
public class HttpManager : MonoSingleton<HttpManager> {

	private const string URL = "https://sword-edge.herokuapp.com";

	public bool loaded = false;

	// Start is called before the first frame update
	void Start() {

	}
	// Update is called once per frame
	void Update() {
	
 }

	public IEnumerator GetGroups() {

		UnityWebRequest req = new UnityWebRequest(URL + "/groups", "GET");
		req.downloadHandler = new DownloadHandlerBuffer();
		yield return req.SendWebRequest();
		if (req.isNetworkError || req.isHttpError) {
			Debug.LogError(req.error);
		} else {
			JsonUtility.FromJson<GroupCollectionHelper>(req.downloadHandler.text).Convert();

			loaded = true;
		}
	}

	[System.Serializable]
	struct MessageRequest {
		public string newMessage;
	};

	public IEnumerator SendGroupMessage(Group group, string message) {

		UnityWebRequest req = new UnityWebRequest(URL + "/groups/" + group.ID, "PUT");

		req.uploadHandler = new UploadHandlerRaw(Encoding.ASCII.GetBytes(
			JsonUtility.ToJson(new MessageRequest { newMessage = message }, true)
		));

		req.uploadHandler.contentType = "application/json";

		yield return req.SendWebRequest();
		if (req.isNetworkError || req.isHttpError) {
			Debug.LogError(req.error);
		} else {
			StartCoroutine(RefreshGroup(group));
		}
	}

	public IEnumerator CreateGroup(string groupName) {

		UnityWebRequest req = new UnityWebRequest(URL + "/groups", "POST");
		req.downloadHandler = new DownloadHandlerBuffer();

		const string json = "[{\"WTF\" : \"club\" , \"value\" : \"Garbage\"}]";

		req.uploadHandler = new UploadHandlerRaw(Encoding.UTF8.GetBytes(json));

		req.uploadHandler.contentType = "application/json";

		yield return req.SendWebRequest();
		if (req.isNetworkError || req.isHttpError) {
			Debug.LogError(req.error);
		} else {
			Group newGroup = JsonUtility.FromJson<GroupHelper3>(req.downloadHandler.text).Convert();
			AccountManager.Self.Account.Groups.Add(newGroup);

			StartCoroutine(SendGroupMessage(newGroup, groupName));
		}
	}

	public IEnumerator RefreshGroup(Group group) {

		UnityWebRequest req = new UnityWebRequest(URL + "/groups/" + group.ID, "GET");
		req.downloadHandler = new DownloadHandlerBuffer();

		yield return req.SendWebRequest();
		if (req.isNetworkError || req.isHttpError) {
			Debug.LogError(req.error);
		} else {
			Group newGroup = JsonUtility.FromJson<GroupHelper2>(req.downloadHandler.text).Convert();
			group.Messages = newGroup.Messages;
			group.Name = newGroup.Name;
			group.ID = newGroup.ID;
		}

		if (GameManager.Self.activePage == GameManager.Self.groupsPage) {
			GameManager.Self.groupsPage.Rebuild();
		} else {
			GameManager.Self.messagesPage.Rebuild();
		}
	}

#if UNITY_EDITOR
	public IEnumerator DeleteGroup(Group group) {

		UnityWebRequest req = new UnityWebRequest(URL + "/groups/" + group.ID, "DELETE");
		req.downloadHandler = new DownloadHandlerBuffer();

		yield return req.SendWebRequest();
		if (req.isNetworkError || req.isHttpError) {
			Debug.LogError(req.error);
		} else {
			print("DELETED");
		}
	}
#endif
}