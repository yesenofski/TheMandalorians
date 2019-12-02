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

		List<Profile> outProfiles = new List<Profile>();

		foreach (ProfileHelper helper in person) {
			outProfiles.Add(helper.Convert());
		}

		if (messages.Count == 0)
			messages.Add("Group");

		var outGroup = new Group(messages[0], _id);
		messages.RemoveAt(0);

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

public class GroupHelper3 {
	public GroupHelper createdGroup;

	public Group Convert() {
		return createdGroup.Convert();
	}
}