using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GroupHelper {

	public string _id;

	public List<ProfileHelper> person;

	public List<string> messages;

	public int quantity;

	public Group Convert() {

		Debug.Log(messages.Count);

		List<Profile> outProfiles = new List<Profile>();

		foreach (ProfileHelper helper in person) {
			outProfiles.Add(helper.Convert());
		}

		var outGroup = new Group(_id, _id);
		outGroup.Messages = messages;
		return outGroup;
	}
}

// Reeeally need to standardize these API return structures
public class GroupHelper2 {
	public GroupHelper group;

	public Group Convert() {
		return group.Convert();
	}
}
