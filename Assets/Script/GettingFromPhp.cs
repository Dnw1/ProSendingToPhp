using UnityEngine;
using System.Collections;

public class GettingFromPhp : MonoBehaviour {
	void Start() {
		//Debug.Log ("test");
		string url = "http://localhost:8080/DHF/Display.php";
		/*WWWForm form = new WWWForm ();
		form.AddField ("Dylan ", " d_way@live.nl");*/ 
		WWW www = new WWW (url);
		StartCoroutine (WaitForRequest (www));
	}
	IEnumerator WaitForRequest(WWW www)
	{
		yield return www;
		//check for errors
		if(www.error == null)
		{
			Debug.Log ("WWW Ok!: " + www.text);
		} else {
			Debug.Log("WWW Error: "+ www.error);
		}
	}
}