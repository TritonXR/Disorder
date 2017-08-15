using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audio_script : MonoBehaviour
{

  static bool AudioBegin = false;

  void Awake()
  {
    if (!AudioBegin)
    {
      gameObject.GetComponent<AudioSource>().Play();
      DontDestroyOnLoad(gameObject);
      AudioBegin = true;
    }
  }

}