using UnityEngine;
using System.Collections;
using System.IO;

public class save_record : MonoBehaviour {

		
	public  static string fileName="save.file";


	static void writeStringToFile( string str, string filename )
	{
		#if !WEB_BUILD
		string path = pathForDocumentsFile( filename );
		FileStream file = new FileStream (path, FileMode.Create, FileAccess.Write);
		
		StreamWriter sw = new StreamWriter( file );
		sw.WriteLine( str );
		
		sw.Close();
		file.Close();
		#endif	
	}

	static string readStringFromFile( string filename)//, int lineIndex )
	{
		#if !WEB_BUILD
		string path = pathForDocumentsFile( filename );
		
		if (File.Exists(path))
		{
			FileStream file = new FileStream (path, FileMode.Open, FileAccess.Read);
			StreamReader sr = new StreamReader( file );
			
			string str = null;
			str = sr.ReadLine ();
			
			sr.Close();
			file.Close();
			
			return str;
		}
		else
		{
			return null;
		}
		#else
		return null;
		#endif 
	}

	static string pathForDocumentsFile( string filename ) 
	{ 
		if (Application.platform == RuntimePlatform.IPhonePlayer)
		{
			string path = Application.dataPath.Substring( 0, Application.dataPath.Length - 5 );
			path = path.Substring( 0, path.LastIndexOf( '/' ) );
			return Path.Combine( Path.Combine( path, "Documents" ), filename );
		}
		
		else if(Application.platform == RuntimePlatform.Android)
		{
			string path = Application.persistentDataPath;	
			path = path.Substring(0, path.LastIndexOf( '/' ) );	
			return Path.Combine (path, filename);
		}	
		
		else 
		{
			string path = Application.dataPath;	
			path = path.Substring(0, path.LastIndexOf( '/' ) );
			return Path.Combine (path, filename);
		}
	}


	void Start ()
	{
		//Save (23f);
		//Debug.Log ("we are here!");
		//Create data instance
		/*data = new SaveData (fileName);
		try{
			data = SaveData.Load(Application.streamingAssetsPath+"\\"+fileName+".uml");
		}
		catch
		{
			data["Player"] = "Player";
			data ["BestScore"] = 23;
			data.Save ();
		}*/
	}
	public static int Save(int Score)
	{
		string Record="";
		Record= readStringFromFile (fileName);
		int Recordint = 0;
		int.TryParse (Record, out Recordint);
		if (Recordint < Score) {
			writeStringToFile (Mathf.RoundToInt (Score).ToString (), fileName);
			Recordint=Score;
		}
			//Record = SaveScore (Score);
		return Recordint;
	}
	/*static float SaveScore(float ScoreCurr)
	{
		//Add keys with significant names and values
		//data["Player"] = "Player";
		//data ["BestScore"] = 23;
		//data.Save ();
		data = SaveData.Load(Application.streamingAssetsPath+"\\"+fileName+".uml");

		float ScoreRecord=0f; //variable for out value
		data.TryGetValue<float> ("BestScore", out ScoreRecord);
		if (ScoreRecord < ScoreCurr) {
			data["BestScore"]=ScoreCurr;
			data.Save ();
			ScoreRecord=ScoreCurr;
		}
		return ScoreRecord;
	}*/

}

