using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioSource))]

public class ChooseCharacter : CharacterManager {

	public float characterInputTimer;
	public float characterInputDelay = 1f;

	private GameObject _characterPrefab;

	public int _characterSelectState;

	void Start () {
		
	}
	
	void Update () {
		
	}
}
