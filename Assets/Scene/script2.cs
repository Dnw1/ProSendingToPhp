using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class script2 : MonoBehaviour {
	//public string[] stringArray;
	public Text fileText;
	public Text fileText1;
	public Text fileText2;
	public Text fileText3;
	public Text fileText4;
	public Text fileText5;
	public Text fileText6;
	public Text fileText7;
	public Text fileText8;
	public Text fileText9;
	public Text fileText10;
    // Use this for initialization
    void Start () {
		
		string url = "http://localhost:8080/DHF/Display.php";
		
		WWW www = new WWW (url);
		
		StartCoroutine (WaitForRequest (www));

		}
	
	IEnumerator WaitForRequest(WWW www)
	{
		yield return www;
		
		if (www.error == null)
        {
  
  
            ReadIncomingData(www.text);

			Debug.Log ("www ok!: " + www.text);

		} else {
			
			Debug.Log("www error: " + www.error);
		}
		
	}
	
    public void ReadIncomingData(string incomingString)
    {
        string[] splitData = incomingString.Trim().Split('\n');

        if (incomingString == string.Empty)return;


        int count = 0;
        foreach (string entry in splitData)
        {
            if (!entry.Contains("\t"))
            {
				string[] temp = entry.Split('\n');
				temp = entry.Split('t');
            }
			if(count == 0){
            fileText.text = splitData[count];
			count++;
			}if(count == 1){
				fileText1.text = splitData[count];
				count++;
			}if(count == 2){
				fileText2.text = splitData[count];
				count++;
			}if(count == 3){
				fileText3.text = splitData[count];
				count++;
			}if(count == 4){
				fileText4.text = splitData[count];
				count++;
			}if(count == 5){
				fileText5.text = splitData[count];
				count++;
			}if(count == 6){
				fileText6.text = splitData[count];
				count++;
			}if(count == 7){
				fileText7.text = splitData[count];
				count++;
			}if(count == 8){
				fileText8.text = splitData[count];
				count++;
			}if(count == 9){
				fileText9.text = splitData[count];
				count++;
			}if(count == 10){
				fileText10.text = splitData[count];
				count++;
			}
        }
    }
}