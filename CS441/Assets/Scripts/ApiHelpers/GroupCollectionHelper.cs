using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GroupCollectionHelper
{
	public int count;

	public List<GroupHelper> groups;


	public void Convert() {

		List<Group> outGroups = new List<Group>(count);

		foreach(GroupHelper helper in groups) {
			outGroups.Add(helper.Convert());
		}
		
		AccountManager.Self.Account.Groups = outGroups;
	}
}
