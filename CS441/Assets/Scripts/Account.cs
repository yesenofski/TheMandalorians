using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Account
{
	//public string Name { get; set; }

	public Profile profile;


	public List<Group> Groups = new List<Group>();

	// TODO: Give raw account data
	public Account(string name) {
		Debug.Log("new acc");
		profile = new Profile(name);
	}

    public void addNewGroup(string groupName)
    {
        Groups.Add(new Group(groupName, "0"));
    }

}
