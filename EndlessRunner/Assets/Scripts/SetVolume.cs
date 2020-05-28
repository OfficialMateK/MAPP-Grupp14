﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SetVolume : MonoBehaviour
{

	public AudioMixer mixer;
	public void SetLevel(float SlideValue)
	{

		mixer.SetFloat("MusicVolume", Mathf.Log10(SlideValue) * 20);

	}


}
