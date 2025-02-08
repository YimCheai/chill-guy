using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class _SceneManager : MonoBehaviour
{
    public static _SceneManager instance;

	public bool isStage1 = true;
	public bool isStage2 = false;
	public bool isStage3 = false;

	private void Awake()
	{
		instance = this;
		DontDestroyOnLoad(gameObject);
	}
	public void SetStageAccess(int stageNumber, bool stageAccess)
	{
		switch (stageNumber)
		{
			case 1:
				isStage1 = stageAccess; break;
			case 2:
				isStage2 = stageAccess; break;
			case 3:
				isStage3 = stageAccess; break;
		}
	}
	public bool GetStageAccess(int stageNumber)
	{
		switch (stageNumber)
		{
			case 1:
				return isStage1;
			case 2:
				return isStage2;
			case 3:
				return isStage3;
		}
		return false;
	}
	public int GetCurrentStage()
	{
		string name = SceneManager.GetActiveScene().name;
		switch (name)
		{
			case "Stage1": return 1;
			case "Stage2": return 2;
			case "Stage3": return 3;
		}
		return 0;
	}
	public IEnumerator NextSceneChange(int Stage, PlayerMovement pm)
	{
		pm.GameDone = true;
		SceneManager.LoadScene("SceneTransition_FadeIn", LoadSceneMode.Additive);
		yield return new WaitForSeconds(1f);

		SceneManager.UnloadSceneAsync("Stage" + (Stage - 1));
		SceneManager.UnloadSceneAsync("SceneTransition_FadeIn");
		SceneManager.LoadScene("Stage" + Stage, LoadSceneMode.Additive);
		SceneManager.LoadScene("SceneTransition_FadeOut", LoadSceneMode.Additive);
		yield return new WaitForSeconds(1f);
		SceneManager.UnloadSceneAsync("SceneTransition_FadeOut");
	}
}
