using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GroupListItemController : MonoBehaviour
{

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

	public bool Load(Group groupIn, int index) {
		group = groupIn;

		GroupName.text = " " + group.Name;

		GroupImage.color = Color.HSVToRGB((index % 9) / 9.0f, 0.6f, 1);

		return true;
	}

	public void OpenGroup() {
		
		GameManager.Self.groupsPage.activeGroup = group;
		GameManager.Self.groupsPage.Shift("left");
		
	}
}
