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

		UnityWebRequest req = new UnityWebRequest(URL + "/groups/", "GET");
		req.downloadHandler = new DownloadHandlerBuffer();
		yield return req.SendWebRequest();
		if (req.isNetworkError || req.isHttpError) {
			print(req.error);
		} else {
			print(req.downloadHandler.text);


			var helper = JsonUtility.FromJson<GroupCollectionHelper>(req.downloadHandler.text);
			helper.Convert();

			loaded = true;
		}
	}

	[System.Serializable]
	struct MessageRequest {
		public string newMessage;
	};

	public IEnumerator SendGroupMessage(Group group, string message) {
		print("Sending Message");

		message = message + "\n<color=#AAAAAAFF><size=30> - " + AccountManager.Self.Account.profile.Name + "</size></color>";

		UnityWebRequest req = new UnityWebRequest(URL + "/groups/" + group.ID, "PUT");

		string json = JsonUtility.ToJson(new MessageRequest{ newMessage = message }, true);

		

		print(json);
		
		req.uploadHandler = new UploadHandlerRaw(Encoding.ASCII.GetBytes(
			json
		));

		req.uploadHandler.contentType = "application/json";

		yield return req.SendWebRequest();
		if (req.isNetworkError || req.isHttpError) {
			print(req.error);
		} else {
			StartCoroutine(UpdateGroup(group));
		}
	}

	public IEnumerator CreateGroup(string groupName) {
		print("Creating Group");

		UnityWebRequest req = new UnityWebRequest(URL + "/groups/", "POST");

		//string json = JsonUtility.ToJson(new MessageRequest { newMessage = message });

		//print(json);

		//req.uploadHandler = new UploadHandlerRaw(Encoding.UTF8.GetBytes(json));

		yield return req.SendWebRequest();
		if (req.isNetworkError || req.isHttpError) {
			print(req.error);
		} else {
			print(req.responseCode);
			//print
		}
	}

	public IEnumerator UpdateGroup(Group group) {
		print("Creating Group");

		UnityWebRequest req = new UnityWebRequest(URL + "/groups/" + group.ID, "GET");
		req.downloadHandler = new DownloadHandlerBuffer();

		//string json = JsonUtility.ToJson(new MessageRequest { newMessage = message });

		//print(json);

		//req.uploadHandler = new UploadHandlerRaw(Encoding.UTF8.GetBytes(json));

		yield return req.SendWebRequest();
		if (req.isNetworkError || req.isHttpError) {
			print(req.error);
		} else {
			print(req.responseCode);
			print(req.downloadHandler.text);
			print(GameManager.Self.groupsPage.activeGroup.Messages.Count);
			Group newGroup = JsonUtility.FromJson<GroupHelper2>(req.downloadHandler.text).Convert();
			group.Messages = newGroup.Messages;
			//group.

			print(GameManager.Self.groupsPage.activeGroup.Messages.Count);
			//group.Messages = newGroup.Messages;
			//group.Name = newGroup.Name;
		}

		GameManager.Self.messagesPage.Rebuild();
	}
}