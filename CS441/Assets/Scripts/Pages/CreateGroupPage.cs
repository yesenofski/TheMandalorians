using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateGroupPage : PageController
{
	public override HeaderInfo HeaderInfo { get; set; }

	[SerializeField]
	private InputField Groupname;

	public override void Rebuild() {
		return;
	}

	protected override void BuildHeaderInfo() {
        HeaderInfo = new HeaderInfo {
            Visible = true,
            Title = "New Group",
            LeftButtonIsText = true,
            LeftButtonContent = "<",
            RightButtonIsText = true,
            RightButtonContent = " "
        };
	}

}
