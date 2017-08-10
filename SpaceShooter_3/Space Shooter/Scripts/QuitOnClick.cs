using System.Collections;
using UnityEngine;

public class QuitOnClick : MonoBehaviour {

	public void Quit() {
          #if UNITY_EDITOR
               UnityEditor.EditorApplication.isPlaying = false;
          #else
               Application.Quit();
          #endif
     }
}

/* CITATION:
[1] Adapted from https://unity3d.com/learn/tutorials/topics/user-interface-ui/creating-main-menu
*/
