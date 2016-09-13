﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MusicController : MonoBehaviour {

    GameStateScript gameState;
    AudioSource gameMusic;
    string currentState;

    Dictionary<string, AudioClip> music;

	// Use this for initialization
	void Start () {
        gameState = GameObject.Find("GameState").GetComponent<GameStateScript>();
        gameMusic = GetComponent<AudioSource>();

        music = new Dictionary<string, AudioClip>();
        music.Add("FlushedTestSong1", Resources.Load("FlushedTestSong1") as AudioClip);
        music.Add("FlushedTestSong2", Resources.Load("FlushedTestSong2") as AudioClip);

        currentState = gameState.CurrentState();

        PlayMusic(currentState);
        
        //Debug.Log(Resources.Load("FlushedTestSong1"));

        
    }
	
	// Update is called once per frame
	void Update () {
        if(currentState != gameState.CurrentState()) {
            currentState = gameState.CurrentState();
            PlayMusic(currentState);
        }
    }

    void PlayMusic(string currentState) {
        switch (currentState)
        {
            case "Dialogue":
                gameMusic.clip = music["FlushedTestSong1"];
                break;
            case "Overworld":
                gameMusic.clip = music["FlushedTestSong2"];
                break;
        }
        //Debug.Log(gameMusic.clip);
        gameMusic.Play();
    }
}
