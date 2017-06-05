using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class PlayerHit : MonoBehaviour {

	public Image BloodBlur;
	public Camera GameCamera;
	public float CameraShakeDuration = 0.3f;
	public float CameraShakeStrenth = 0.5f;

	// Use this for initialization
	void Start () {
		GameCamera = GameObject.Find ("FirstPersonCharacter").GetComponent<Camera>();	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Hit(float speed){
		print ("player hit");
		PlayHitAnimation ();

		float shakeStrenth = CameraShakeStrenth * speed;
		GameCamera.transform.DOShakePosition (CameraShakeDuration, shakeStrenth);
	}

	Tweener tweenAnimation;
	private void PlayHitAnimation()
	{
		if (tweenAnimation != null)
			tweenAnimation.Kill ();

		BloodBlur.color = Color.white;
		tweenAnimation = DOTween.To (() => BloodBlur.color, (x) => BloodBlur.color = x, new Color (1, 1, 1, 0), 0.5f);
	}
}
