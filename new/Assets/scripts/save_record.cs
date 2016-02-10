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
			str = sr.ReadToEnd();
			
			sr.Close();
			file.Close();
			
			return str;
		}
		else
		{
			writeStringToFile("0\n15\n25\n1\n0",filename);
			return "0\n15\n25\n1\n0";
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
	public static void Read()
	{
		string Str="";
		Str = readStringFromFile (fileName);
		char delimiter = '\n';
		string[] substrings = Str.Split(delimiter);
		int score = 0;
		int.TryParse( substrings[0],out score);
		scenes_intermediate.setScoreBest (score);
		float cs = 0;
		float.TryParse (substrings[1],out cs);
		scenes_intermediate.setConSens (cs);
		float.TryParse (substrings[2],out cs);
		scenes_intermediate.setConSensAngle (cs);
		float sound = 1f;
		float.TryParse (substrings[3],out sound);
		scenes_intermediate.setSound (sound);
		int lang = 0;
		int.TryParse (substrings [4], out lang);
		scenes_intermediate.setLang (lang);
	}

	public static void Save()
	{
			writeStringToFile (scenes_intermediate.getScoreBest().ToString()+
		                   		"\n"+scenes_intermediate.getConSens().ToString()+
		                  			 "\n"+scenes_intermediate.getConSensAngle().ToString()+
		                   				"\n"+scenes_intermediate.getSound().ToString()+
		                   					"\n"+scenes_intermediate.getLang().ToString(),
		                   						fileName);
	}
}

