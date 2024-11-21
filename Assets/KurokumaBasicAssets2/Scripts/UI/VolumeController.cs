using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeController : MonoBehaviour
{
	public enum VolumeType { MASTER, BGM, SE }

	[SerializeField]
	VolumeType volumeType = 0;

	Slider slider;
	SoundManager soundManager;

	void Start()
	{
		slider = GetComponent<Slider>();
		soundManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<SoundManager>();

		InitSlider();
	}

	void InitSlider()
	{
		switch (volumeType)
		{
			case VolumeType.MASTER:
				slider.value = soundManager.Volume;
				break;
			case VolumeType.BGM:
				slider.value = soundManager.BgmVolume;
				break;
			case VolumeType.SE:
				slider.value = soundManager.SeVolume;
				break;
		}
	}

	public void OnValueChanged()
	{
		switch (volumeType)
		{
			case VolumeType.MASTER:
				soundManager.Volume = slider.value;
				break;
			case VolumeType.BGM:
				soundManager.BgmVolume = slider.value;
				break;
			case VolumeType.SE:
				soundManager.SeVolume = slider.value;
				break;
		}
	}
}
