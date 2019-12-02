using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoSingleton<GameManager>
{
	public string Username { get; set; } = ""; // TODO: Move to AccountManager

	public LoginPage loginPage;
	public GroupsPage groupsPage;
	public MessagesPage messagesPage;
	public MembersPage memberPage;

	public PageController activePage;


	protected override void DerivedAwake() {
		DontDestroyOnLoad(gameObject);

		Application.targetFrameRate = 60;

		

	}

	// Start is called before the first frame update
	void Start()
    {
		activePage = loginPage;
		//PageManager.Self.Start("Login Page");
		//statem
	}

    // Update is called once per frame
    void Update()
    {
        
    }
}
