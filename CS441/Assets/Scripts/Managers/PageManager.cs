﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PageManager : MonoSingleton<PageManager> {
	public HeaderController HeaderController;

	public GameObject Canvas;

	public LoginPage loginPage;
	public GroupsPage groupPage;
	public MessagesPage messagePage;
	public MembersPage memberPage;

	[SerializeField]
	private PageController currentPage;

	// For page batching
	//private Dictionary<System.Type, PageController> pages = new Dictionary<System.Type, PageController>();

	private Dictionary<string, GameObject> pagePrefabs = new Dictionary<string, GameObject>();

	private Stack<PageController> pageStack = new Stack<PageController>();

	protected override void DerivedAwake() {
		LoadPrefab("Login Page");
		LoadPrefab("Groups Page");
		LoadPrefab("CreateGroup Page");
		LoadPrefab("Members Page");

	}

	// Start is called before the first frame update
	void Start() {

	}

	// Update is called once per frame
	void Update() {

	}

	private void LoadPrefab(string pageName) {
		GameObject prefab = Resources.Load<GameObject>("Prefabs/Pages/" + pageName);
		Debug.Assert(!(prefab is null), pageName);
		pagePrefabs.Add(pageName, prefab);
	}

	private PageController MakePage(string pageName) {
		GameObject pagePrefab = pagePrefabs[pageName];
		Debug.Assert(!(pagePrefab is null));

		pagePrefab = GameObject.Instantiate<GameObject>(pagePrefab);
		pagePrefab.transform.SetParent(Canvas.transform, false);
		pagePrefab.name = pageName;

		//(pagePrefab.transform as RectTransform)

		return pagePrefab.GetComponent<PageController>();
	}

	private void SwitchTo(PageController page) {
		print("switch");
		if (!(currentPage is null)) {
			currentPage.gameObject.SetActive(false);
			print("oops " + currentPage);
		}

		currentPage = page;
		currentPage.gameObject.SetActive(true);
	}

	public void Next(string pageName) {
		PageController newPage = MakePage(pageName);
		SwitchTo(newPage);

		pageStack.Push(newPage);
	}

	public void Back() {
		pageStack.Pop();

		SwitchTo(pageStack.Peek());
	}

	public void Pop() {
		pageStack.Pop();
	}

	public void Start(string pageName) {
		pageStack.Clear();
		Next(pageName);
	}

	public void CreateGroup() {
		Next("CreateGroup Page");
	}
}
