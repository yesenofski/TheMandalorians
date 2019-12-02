using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccountManager : MonoSingleton<AccountManager>
{
    // Start is called before the first frame update

	public Account Account { get; set; }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	public bool Login(string username) {
		Debug.Log("Username: " + username);

		Account = new Account(username);

		StartCoroutine(HttpManager.Self.GetGroups());

		return true;
	}

    public void addGroupName(string groupName)
    {
        Account.addNewGroup(groupName);
    }
}
