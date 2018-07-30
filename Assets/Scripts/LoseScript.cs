using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//stil under development but needed in order for the checkpoints to work
public class LoseScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnTriggerEnter2D(Collider2D Coli)
    {
        if (Coli.tag.ToLower().Contains("enemy"))
        {
            gameObject.GetComponent<Checkpoints>().OnLoose(this.gameObject);
        }
        if (Coli.name.ToLower().Contains("death"))
        {
            gameObject.GetComponent<Checkpoints>().OnLoose(this.gameObject);
        }
    }
}
