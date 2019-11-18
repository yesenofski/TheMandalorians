﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Account
{
	//public string Name { get; set; }

	public Profile profile;


	public List<Group> Groups = new List<Group>();

	// TODO: Give raw account data
	public Account(string name) {
		//profile.Name = name;

		Groups.Add(new Group("CS441"));
		Groups.Add(new Group("Set-Up Team"));
		Groups.Add(new Group("Neighborhood Group"));
		Groups.Add(new Group("Family"));
		Groups.Add(new Group("Bars Squad"));
		Groups.Add(new Group("Fraternity"));
	}

    public void addNewGroup(string groupName)
    {
        Groups.Add(new Group(groupName));
    }

}
