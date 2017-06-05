using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class PlayerHit : MonoBehaviour {

	public Image BloodBlur;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Hit(){
		print ("player hit");
		PlayHitAnimation ();
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
