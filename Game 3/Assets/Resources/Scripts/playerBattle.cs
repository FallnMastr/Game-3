using UnityEngine;
using System.Collections;

public class playerBattle : MonoBehaviour {

    public Animator anim;

    public int bat;

	// Use this for initialization
	void Start () {
        bat = 0;

        anim = this.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
	    anim.SetInteger("Battle", bat);
	}
}
