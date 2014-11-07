/// <summary>
/// Not a Tinder function.  This finds something much less interesting, the file "date.txt".
/// </summary>

using UnityEngine;
using System.Collections;
using System.IO;
using System.Text;
using System.Security.Permissions;


public class DateFinder : MonoBehaviour {

	string line;
	string filePath = " ";
	string filePath1 = " ";
	
	void Start()
	{

		/*line = "Start";

		#if (UNITY_WEBPLAYER || UNITY_SAMSUNG)
			StartCoroutine("ReadFromWWW()");
		#endif
*/
	}

	void Update()
	{
	
		line = "Only iOS, Android, Webplayer, STV, BB10, Editor and Standalone supported.";
		
		#if (UNITY_BLACKBERRY || UNITY_STANDALONE)
			ReadFromStream();
		#endif

		#if (UNITY_ANDROID)
			ReadFromJAR();
		#endif

		#if UNITY_IPHONE
		//	ReadFromRaw();
		#endif

		#if (UNITY_WEBPLAYER || UNITY_SAMSUNG)
			StartCoroutine("ReadFromWWW");
		#endif

		
		
		/*public string result = "";

		IEnumerator Example() {
			if (filePath.Contains("://")) {
				WWW www = new WWW(filePath);
				yield return www;
				result = www.text;
			} else
				result = System.IO.File.ReadAllText(filePath);
		}
		*/

	}

	/// <summary>
	/// Reads from BB10, Standalone.
	/// </summary>
	void ReadFromStream()
	{
		string filePath = System.IO.Path.Combine(Application.dataPath, "date.txt");
		
		if (File.Exists(filePath))
		{
			StreamReader theReader = new StreamReader(filePath);
			line = theReader.ReadLine ();
		}
		else
		{
			line = "ERROR FILE NOT FOUND";
		}

	}

	/// <summary>
	/// Reads from Webplayer.
	/// </summary>
	public IEnumerator ReadFromWWW()
	{
		
		string filePath = "file://Users/Adam/CloudBuildAutomation/fgj/Raw/date.html";

		filePath1 = filePath;
						
		if (File.Exists(filePath))
		{
			WWW www = new WWW(filePath);

			yield return www;
			line = www.text;
			
		}
		else
		{
			yield return line = "ERROR FILE NOT FOUND";
		}
		
	}



	/// <summary>
	/// Reads from Android.
	/// </summary>
	void ReadFromJAR()
	{
		
		string filePath = "storage/sdcard0/Android/data/com.Company.Pro8ductName/files/date.txt";

		filePath1 = filePath;
		
		if (File.Exists(filePath))
		{
			StreamReader theReader = new StreamReader(filePath);
			line = theReader.ReadLine ();
		}
		else
		{
			line = "ERROR FILE NOT FOUND";
		}
		
	}


	/*

	/// <summary>
	/// Reads from iOS.
	/// </summary>
	void ReadFromRaw()
	{
		string filePath = System.IO.Path.Combine(Application.dataPath + "/Raw");
		
		if (File.Exists(filePath))
		{
			StreamReader theReader = new StreamReader(filePath);
			line = theReader.ReadLine ();
		}
		else
		{
			line = "ERROR FILE NOT FOUND";
		}
		
	}

	*/
		
	void OnGUI()
	{
		GUI.Label(new Rect(10,10,1200,20), filePath1);
		GUI.Label(new Rect(100,70,100,20),"Today's date is: ");
		GUI.Label(new Rect(100,100,500,20), line);
	}
}
