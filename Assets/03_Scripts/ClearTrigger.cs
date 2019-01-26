using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearTrigger : MonoBehaviour
{
	GameObject gameController;

	private void Start()
	{
		//ゲーム開始時にGameControllerをFindしておく
		gameController = GameObject.FindWithTag("GameController");
	}

	//トリガーからExitしたらクリアしたとみなす
	private void OnTriggerExit2D(Collider2D collision)
	{
		gameController.SendMessage("IncreaseScore");
	}
}
