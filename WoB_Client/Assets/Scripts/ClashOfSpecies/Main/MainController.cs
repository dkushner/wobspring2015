﻿using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class PlayerElement {
	public string name;
	public string terrain;
	public bool isSelected;
}

public class MainController : MonoBehaviour {
	public GameObject sampleToggle;
	public List<PlayerElement> playerList;
	public Transform contentPanel;
	string selectedPlayer = "";
	string defendingTerrain = "";
    ToggleGroup toggleGroup = null;

	void Awake() {
	//	playerList = PopulatePlayerList ();
	}

	void Start () {
        toggleGroup = GameObject.FindGameObjectWithTag("ContentPanel").GetComponent<ToggleGroup>();
		PopulateScrollView ();
	}

	void Update() {
		if (defendingTerrain == "") {

		}
	}

	//protocol does this
	//gets only the player name and terrain name from the valid defense table
	List<PlayerElement> PopulatePlayerList() {
		return new List<PlayerElement>();
	}

	void PopulateScrollView() {
		foreach (var playerElement in playerList) {
			GameObject newToggle = Instantiate(sampleToggle) as GameObject;
			SampleToggle toggle = newToggle.GetComponent<SampleToggle>();
			toggle.label.text = playerElement.name;
			toggle.name = playerElement.name;
			toggle.terrain = playerElement.terrain;
			toggle.toggle.isOn = playerElement.isSelected;
			toggle.toggle.onValueChanged.AddListener((value) => ToggleAction(toggle, value));
			toggle.toggle.group = toggleGroup;
			newToggle.transform.SetParent(contentPanel);
		}
	}

	public void ToggleAction(SampleToggle toggle, bool state) {
		selectedPlayer = state ? toggle.name : "";
		defendingTerrain = state ? toggle.terrain : "";
		//Debug.Log (selectedPlayer);
		//Debug.Log (defendingTerrain);
	}

	public void EditDefense() {

	}

	public void AttackPlayer() {
		if (selectedPlayer != "") {
			PersistentData atkData = GameObject.Find("Attack Data").GetComponent<PersistentData>();
			atkData.SetDefenderData(selectedPlayer, defendingTerrain);
			Debug.Log(atkData.getDefenderName());
			Debug.Log(atkData.getDefenderTerrain());
		}
	}

	public void ReturnToLobby() {
		GameObject go = GameObject.Find ("Attack Data");

		if (go != null) {
			Destroy(go);
		}

		//Game.LoadScene ("Lobby");
	}
}
