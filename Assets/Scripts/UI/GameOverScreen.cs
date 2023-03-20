using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameOverScreen : Screen
{
	[SerializeField] private CanvasGroup _canvasGroup;

	public event UnityAction RestartButtonClick;

	public override void Close()
	{
		CanvasGroup.alpha = 0;
		_canvasGroup.alpha = 0;
		Button.interactable = false;
	}

	public override void Open()
	{
		CanvasGroup.alpha = 1;
		StartCoroutine(FadeIn());
		Button.interactable = true;
	}

	protected override void OnButtonClick()
	{
		RestartButtonClick?.Invoke();
	}

	private IEnumerator FadeIn()
	{
		for (int i = 0; i < 100; i++)
		{
			_canvasGroup.alpha += 1 / 100f;
			yield return new WaitForSecondsRealtime(0.01f);
		}
	}
}
