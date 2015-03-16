using UnityEngine;
using System.Collections;
using System;

public static class PlayerPrefsX {


	#region String Array
	/// <summary>
	/// Stores a String Array or Multiple Parameters into a Key w/ specific char seperator
	/// </summary>
	public static bool SetStringArray(string key, char separator, params string[] stringArray)
	{
		if (stringArray.Length == 0) return false;
		try
		{ PlayerPrefs.SetString(key, String.Join(separator.ToString(), stringArray)); }
		catch (Exception e)
		{ return false; }
		return true;
	}

	/// <summary>
	/// Returns a String Array from a key & char seperator
	/// </summary>
	public static string[] GetStringArray(string key, char separator)
	{
		if (PlayerPrefs.HasKey(key))
			return PlayerPrefs.GetString(key).Split(separator);
		return new string[0];
	}

	public static string[] GetStringArray(string key)
	{
		if (PlayerPrefs.HasKey(key))
			return PlayerPrefs.GetString(key).Split("\n"[0]);
		return new string[0];
	}
	
	public static string[] GetStringArray(string key, char separator, string defaultValue, int defaultSize)
	{
		if (PlayerPrefs.HasKey(key))
			return PlayerPrefs.GetString(key).Split(separator);
		string[] stringArray = new string[defaultSize];
		for (int i = 0; i < defaultSize; i++)
			stringArray[i] = defaultValue;
		return stringArray;
	}

	public static String[] GetStringArray(string key, string defaultValue, int defaultSize)
	{
		return GetStringArray(key, "\n"[0], defaultValue, defaultSize);
	}
	#endregion

	#region Int Array
	
	/// <summary>
	/// Stores a Int Array or Multiple Parameters into a Key
	/// </summary>
	public static bool SetIntArray(string key, params int[] intArray)
	{
		if (intArray.Length == 0) return false;
		
		System.Text.StringBuilder sb = new System.Text.StringBuilder();
		for (int i = 0; i < intArray.Length - 1; i++)
			sb.Append(intArray[i]).Append("|");
		sb.Append(intArray[intArray.Length - 1]);
		
		try { PlayerPrefs.SetString(key, sb.ToString()); }
		catch (Exception e) { return false; }
		return true;
	}
	
	/// <summary>
	/// Returns a Int Array from a Key
	/// </summary>
	public static int[] GetIntArray(string key)
	{
		if (PlayerPrefs.HasKey(key))
			{
//			Debug.Log("1");
				string[] stringArray = PlayerPrefs.GetString(key,"0").Split("|"[0]);
				int[] intArray = new int[stringArray.Length];
				for (int i = 0; i < stringArray.Length; i++)
					intArray[i] = Convert.ToInt32(stringArray[i]);
				return intArray;
		}else{
			PlayerPrefs.SetInt (key, 0);
		}

		return new int[0];
	}
	
	/// <summary>
	/// Returns a Int Array from a Key
	/// Note: Uses default values to initialize if no key was found
	/// </summary>
	public static int[] GetIntArray(string key, int defaultValue, int defaultSize)
	{
		if (PlayerPrefs.HasKey(key))
			return GetIntArray(key);
		int[] intArray = new int[defaultSize];
		for (int i = 0; i < defaultSize; i++)
			intArray[i] = defaultValue;
		return intArray;
	}
	
	#endregion
}
