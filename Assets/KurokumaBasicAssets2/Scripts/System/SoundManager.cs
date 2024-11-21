using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SaveManager))]
[DefaultExecutionOrder(-5)]
public class SoundManager : SingletonMonoBehaviour<SoundManager>
{

	[SerializeField]
	AudioClip defaultBgm = null;
	
	[Range(0, 1), Tooltip("マスタ音量")]
	float volume = 1;
	[Range(0, 1), Tooltip("BGM音量")]
	float bgmVolume = 1;
	[Range(0, 1), Tooltip("SE音量")]
	float seVolume = 1;

	AudioSource bgmAudioSource;
	AudioSource seAudioSource;

	SaveManager saveManager;

	public float Volume
	{
		set
		{
			volume = Mathf.Clamp01(value);
			bgmAudioSource.volume = bgmVolume * volume;
			seAudioSource.volume = seVolume * volume;
			saveManager.Volume = volume;
		}
		get
		{
			return volume;
		}
	}

	public float BgmVolume
	{
		set
		{
			bgmVolume = Mathf.Clamp01(value);
			bgmAudioSource.volume = bgmVolume * volume;
			saveManager.BgmVolume = bgmVolume;
		}
		get
		{
			return bgmVolume;
		}
	}

	public float SeVolume
	{
		set
		{
			seVolume = Mathf.Clamp01(value);
			seAudioSource.volume = seVolume * volume;
			saveManager.SeVolume = seVolume;
		}
		get
		{
			return seVolume;
		}
	}

	protected override void Awake()
	{
		base.Awake();

		bgmAudioSource = gameObject.AddComponent<AudioSource>();
		seAudioSource = gameObject.AddComponent<AudioSource>();
	}

	void Start()
	{
		saveManager = GetComponent<SaveManager>();
		Volume = saveManager.Volume;
		BgmVolume = saveManager.BgmVolume;
		SeVolume = saveManager.SeVolume;

		if(defaultBgm != null)
		{
			PlayBgm(defaultBgm);
		}
	}

	//BGM再生
	public void PlayBgm(AudioClip bgm)
	{
		bgmAudioSource.clip = bgm;
		bgmAudioSource.loop = true;
		bgmAudioSource.volume = BgmVolume * Volume;
		bgmAudioSource.Play();
	}

	public void StopBgm()
	{
		bgmAudioSource.Stop();
		bgmAudioSource.clip = null;
	}

	//SE再生
	public void PlaySe(AudioClip se)
	{
		seAudioSource.PlayOneShot(se, SeVolume * Volume);
	}

	public void StopSe()
	{
		seAudioSource.Stop();
		seAudioSource.clip = null;
	}

}
