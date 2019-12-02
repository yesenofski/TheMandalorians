using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ProfileHelper
{
	public string _id;
	public string fname;
	public string lname;
	public string IDImage;
	public int __v;


	public Profile Convert() {

		return new Profile(fname);


	}
}
