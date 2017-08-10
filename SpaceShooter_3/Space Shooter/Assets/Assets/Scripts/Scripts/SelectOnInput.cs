using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class SelectOnInput : MonoBehaviour {

     public EventSystem eventSsytem;
     public GameObject selectedObject;

     private bool buttonSelected;

	// Update is called once per frame
	void Update () {
		if(Input.GetAxisRaw("Vertical") != 0 && buttonSelected == false) {
               eventSsytem.SetSelectedGameObject(selectedObject); // First menu item to be selected on load.
               buttonSelected = true;
          }
	}

     private void OnDisable() {
          buttonSelected = false;
     }

}

/* CITATIONS:
[1] Adapted from: https://unity3d.com/learn/tutorials/topics/user-interface-ui/creating-main-menu
*/
