using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollObject : MonoBehaviour
{
	public float speed = 1.0f;
	public float startPosition;
	public float endPosition;

	void Update ()
	{
		//毎フレームｘポジションを少しずつ移動させる
		transform.Translate(-1 * speed * Time.deltaTime, 0, 0);

		//スクロールが目標ポイントまで到達したかをチェック
		if (transform.position.x <= endPosition) ScrollEnd();
	}

	void ScrollEnd()
	{
		//スクロールする距離分を戻す
		transform.Translate(-1 * (endPosition - startPosition), 0, 0);

		//同じゲームオブジェクトにアタッチされているコンポート年とにメッセージを送る
		SendMessage("OnScrollEnd", SendMessageOptions.DontRequireReceiver);
	}
}
