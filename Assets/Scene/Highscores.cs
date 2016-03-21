﻿using UnityEngine;
using System.Collections;

public class Highscores : MonoBehaviour {
	
	const string privateCode = "4fcMXMcdw";
	const string publicCode = "548cdec";
	const string webURL = "";
	
	public Highscore[] highscoresList;
	
	void Awake() {
		
		AddNewHighscore("Sebastian", 50);
		AddNewHighscore("Mary", 85);
		AddNewHighscore("Swan", 9001);
		
		DownloadHighscores();
	}
	
	public void AddNewHighscore(string username, int score) {
		StartCoroutine(UploadNewHighscore(username,score));
	}
	
	IEnumerator UploadNewHighscore(string username, int score) {
		WWW www = new WWW(webURL + privateCode + "/add/" + WWW.EscapeURL(username) + "/" + score);
		yield return www;
		
		if (string.IsNullOrEmpty(www.error))
			print ("Upload Successful");
		else {
			print ("Error uploading: " + www.error);
		}
	}
	
	public void DownloadHighscores() {
		StartCoroutine("DownloadHighscoresFromDatabase");
	}// ..>
	
	IEnumerator DownloadHighscoresFromDatabase() {
		WWW www = new WWW(webURL + publicCode + "/pipe/");
		yield return www;
		
		if (string.IsNullOrEmpty(www.error))
			FormatHighscores(www.text);
		else {
			print ("Error Downloading: " + www.error);
		}
	}
	//    <.. ->
	void FormatHighscores(string textStream) {
		string[] entries = textStream.Split(new char[] {'\n'}, System.StringSplitOptions.RemoveEmptyEntries);
		highscoresList = new Highscore[entries.Length];
		
		for (int i = 0; i <entries.Length; i ++) {
			string[] entryInfo = entries[i].Split(new char[] {'|'});
			string username = entryInfo[0];
			int score = int.Parse(entryInfo[1]);
			highscoresList[i] = new Highscore(username,score);
			print (highscoresList[i].username + ": " + highscoresList[i].score);
		}// <- Special can go solo should probably be aswell.
	}
	
}
//
public struct Highscore {
	public string username;
	public int score;
	
	public Highscore(string _username, int _score) {
		username = _username;
		score = _score;
	}
}