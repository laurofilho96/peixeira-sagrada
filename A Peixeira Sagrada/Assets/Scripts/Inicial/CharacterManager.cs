using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour {

	public static bool _manhoso;
	public static bool _compadre;

	void Awake() {

		_manhoso = false;
		_compadre = false;

	}

	void Start () {
		DontDestroyOnLoad (this);
	}
	
	void Update () {
		
	}
}
