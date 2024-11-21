using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[DefaultExecutionOrder(-10)]
public class SaveManager : SingletonMonoBehaviour<SaveManager>
{

	string filePath;
	SaveData save;
	MoveSceneManager moveSceneManager;

	public float Volume
	{
		set
		{
			save.volume = value;
		}
		get
		{
			return save.volume;
		}
	}

	public float BgmVolume
	{
		set
		{
			save.bgmVolume = value;
		}
		get
		{
			return save.bgmVolume;
		}
	}

	public float SeVolume
	{
		set
		{
			save.seVolume = value;
		}
		get
		{
			return save.seVolume;
		}
	}

	protected override void Awake()
	{
		base.Awake();

		string saveFileName = "saveData";

		if (Debug.isDebugBuild)
		{
			saveFileName += "_test";
		}

		filePath = Application.persistentDataPath + "/" + saveFileName + ".json";
		save = new SaveData();

		moveSceneManager = GetComponent<MoveSceneManager>();

		if (Debug.isDebugBuild)
		{
			CreateDebugData();
		}
		else
		{
			if (File.Exists(filePath))
			{
				Load();
			}
			else
			{
				Save();
			}
		}
	}

	public void Save()
	{
		string json = JsonUtility.ToJson(save);

		using (StreamWriter streamWriter = new StreamWriter(filePath))
		{
			streamWriter.Write(json);
			streamWriter.Flush();
			streamWriter.Close();
		}
	}

	public void Load()
	{
		if (File.Exists(filePath))
		{
			using (StreamReader streamReader = new StreamReader(filePath))
			{
				string data = streamReader.ReadToEnd();
				streamReader.Close();

				save = JsonUtility.FromJson<SaveData>(data);
			}
		}
	}

	public void InitSaveData()
	{
		save = new SaveData();
	}

	void CreateDebugData()
	{
		
	}

}