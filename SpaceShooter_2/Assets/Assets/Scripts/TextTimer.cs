using UnityEngine;

public class TextTimer : MonoBehaviour {

     public float time;

     void Start() {
          Destroy(gameObject, time);
     }
}

// http://answers.unity3d.com/questions/970467/how-to-make-disappear-a-gui-text-after-an-amount-o.html