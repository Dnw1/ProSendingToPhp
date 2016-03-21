using UnityEngine;
using System.Collections;

public class script1 : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
		string url = "http://localhost:8080/DHF/Display.php";

		WWWForm form = new WWWForm ();

		WWW www = new WWW (url, form);

		StartCoroutine (WaitForRequest (www));
	}

	IEnumerator WaitForRequest(WWW www)
	{
		yield return www;

		if (www.error == null) {
		
			Debug.Log ("www ok!: " + www.text);
		} else {
		
			Debug.Log("www error: " + www.error);
		}

	}

}