using UnityEngine;
using System.Collections;

public class MainController : MonoBehaviour {
	
	void Start () 
	{
		ControllerInstantiator (new string[] {"AudioController"});
	}

	void ControllerInstantiator(string[] controllers)
	{
		foreach(string controller in controllers)
		{
			Debug.Log (controller);
			/* Instantiate the controllers */
			GameObject iController = (GameObject)Instantiate (Resources.Load ("Prefabs/Controllers/" + controller));

			/* Name the object properly */
			iController.name = controller;

			/* Set them as child of the "Controller" game object */ 
			iController.transform.parent = this.gameObject.transform;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
