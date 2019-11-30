using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GroupListItemController : MonoBehaviour
{
    
    private GroupsPage groupPage;

	public Image GroupImage;

	public Text GroupName;

	private Group group;

	public GameObject NotificationBox;
	public Text NotificationCount;

	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	public bool Load(GroupsPage groupPageIn, Group groupIn) {
        groupPage = groupPageIn;
		group = groupIn;

		GroupName.text = "  " + group.Name;

		return true;
	}

	public void OpenGroup() {
		groupPage.activeGroup = group;
		groupPage.Shift("left");
		
	}
}
