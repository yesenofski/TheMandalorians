using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PageController : MonoBehaviour
{
	public abstract HeaderInfo HeaderInfo { get; set; }

    public PageController leftPage;
    public PageController rightPage;

    public Animator animator;
    /*
	public enum ShiftType
    {
        FromLeft,
        FromRight,
        ToLeft,
        ToRight
    };
    */
    void Awake() {

		
		BuildHeaderInfo();

        //animator.runtimeAnimatorController = new AnimatorOverrideController(animator.runtimeAnimatorController);
	}

	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	protected virtual void Rebuild() { }
	protected abstract void BuildHeaderInfo();

    public void SetEnabled(int enabled)
    {
        print("woof");
        gameObject.SetActive(enabled != 0);
    }

    public void Shift(string dir)
    {
        switch(dir.ToLower())
        {
            case "left":
                PlayAnim("ShiftLeft");
                rightPage?.PlayAnim("ShiftLeft");
                break;
            case "right":
                PlayAnim("ShiftRight");
                leftPage?.PlayAnim("ShiftRight");
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

    /*

    public virtual void ShiftLeft(ShiftType shiftType)
    {
        switch(shiftType)
        {
            case ShiftType.FromLeft: break;
        }

        animator.SetTrigger("ShiftLeft");
    }

    public virtual void ShiftRight()
    {
        animator.SetTrigger("ShiftRight");
    }
    */
}
