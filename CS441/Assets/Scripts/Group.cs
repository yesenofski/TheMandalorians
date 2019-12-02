using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Group
{
	public string ID { get; set; }

	public string Name { get; set; }

	//public List<Profile> Members;
	public List<string> Messages = new List<string>();

	// public List<Profile> Members;

	public Group(string name, string id) {
		Name = name;
		ID = id;

	}
}
