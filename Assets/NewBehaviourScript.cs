using UnityEngine;
using System.Collections;
using System.IO;
using System.Text;

public class NewBehaviourScript : MonoBehaviour {

	string line;	
	
	void Start()
	{
		
		StreamReader theReader = new StreamReader("date.txt");
		line = theReader.ReadLine ();

	}
		
	void OnGUI()
	{
		GUI.Label(new Rect(100,70,100,20),"Today's date is: ");
		GUI.Label(new Rect(100,100,100,20), line);
	}
}
