using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PageController : MonoBehaviour
{

    public PageController leftPage;
    public PageController rightPage;

    public Animator animator;

	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	public virtual void Rebuild() { }

    public void Shift(string dir)
    {
        switch(dir.ToLower())
        {
            case "left":
                PlayAnim("ShiftLeft");
                rightPage?.PlayAnim("ShiftLeft");
				GameManager.Self.activePage = rightPage;
                break;
            case "right":
                PlayAnim("ShiftRight");
                leftPage?.PlayAnim("ShiftRight");
				GameManager.Self.activePage = leftPage;
				break;
        }

   //     print("oof");
     //   gameObject.SetActive(true);
       // animator.SetTrigger(anim);
    }

    public void PlayAnim(string anim)
    {
        Rebuild();
        animator.SetTrigger(anim);
    }
}
