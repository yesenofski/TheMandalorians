using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Group
{
	public string Name { get; set; }

	//public List<Profile> Members;
	public List<string> Messages;

	// public List<Profile> Members;

	public Group(string name) {
		Name = name;

		Messages = new List<string>();

		for (int i = 0; i < 5; i++) {
			Messages.Add("Message #" + i);
		}
	}

}
