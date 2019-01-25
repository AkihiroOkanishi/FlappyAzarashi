﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class GameController : MonoBehaviour
{
	// ゲームステート
	enum State
	{
		Ready,
		Play,
		GameOver
	}

	State state;

	public AzarashiController azarashi;
	public GameObject blocks;

	void Start()
	{
		// 開始と同時にReadyステートに移行
		Ready();
	}

	void LateUpdate()
	{
		// ゲームのステート毎にイベントを監視
		switch (state)
		{
			case State.Ready:
				// タッチしたらゲームスタート
				if (Input.GetButtonDown("Fire1")) GameStart();
				break;

			case State.Play:
				// キャラクターが死亡したらゲームオーバー
				if (azarashi.IsDead()) GameOver();
				break;

			case State.GameOver:
				// タッチしたらシーンをリロード
				if (Input.GetButtonDown("Fire1")) Reload();
				break;
		}
	}

	void Ready()
	{
		state = State.Ready;
		// 各オブジェクトを無効状態にする
		azarashi.SetStreerActive(false);
		blocks.SetActive(false);
	}

	void GameStart()
	{
		state = State.Play;
		// 各オブジェクトを有効にする
		azarashi.SetStreerActive(true);
		blocks.SetActive(true);
		// 最初の入力だけが、ゲームコントローラーから渡す
		azarashi.flap();
	}

	void GameOver()
	{
		state = State.GameOver;
		// シーン中の全てのScrollObjectコンポーネントを探し出す
		ScrollObject[] scrollObjects = GameObject.FindObjectsOfType<ScrollObject>();
		// 全ScrollObjectのスクロール処理を無効にする
		foreach (ScrollObject so in scrollObjects) so.enabled = false;
	}

	void Reload()
	{
		// 現在読み込んでいるシーンを再読み込み
		// SceneManager.GetActiveScene().name
		//SceneManager.LoadScene("Main");
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}
}
