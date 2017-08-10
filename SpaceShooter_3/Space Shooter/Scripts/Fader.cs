using UnityEngine;
using UnityEngine.SceneManagement;

public class Fader : MonoBehaviour {

     public Texture2D fadeOutTexture;
     public float fadeSpeed = 1.0f;

     private int drawDepth = -1000;
     private float alpha = 1.0f;
     private float fadeDir = -1;
     
	void OnGUI () {
          alpha += fadeDir * fadeSpeed * Time.deltaTime;
          alpha = Mathf.Clamp01(alpha);
          GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, alpha);
          GUI.depth = drawDepth;
          GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), fadeOutTexture);
	}

     public float BeginFade(int direction) {
          fadeDir = direction;
          return (fadeSpeed);
     }

     void OnEnable() {
          SceneManager.sceneLoaded += OnSceneLoaded;
     }

     void OnDisable() {
          SceneManager.sceneLoaded -= OnSceneLoaded;
     }

     private void OnSceneLoaded(Scene scene, LoadSceneMode mode) {
          BeginFade(-1);
     }

}

/* CITATIONS:
[1] Fader script adpted from: https://www.youtube.com/watch?v=0HwZQt94uHQ
[2] Updated to v5.6.2 with http://answers.unity3d.com/questions/1174255/since-onlevelwasloaded-is-deprecated-in-540b15-wha.html
*/
