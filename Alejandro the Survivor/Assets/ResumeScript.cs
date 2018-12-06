using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResumeScript : MonoBehaviour {
    private Canvas canvas;
    private bool isFading = false;
    private CanvasGroup group;

    // Use this for initialization
    void Start()
    {
        canvas = GetComponentInParent<Canvas>();
        group = GetComponentInParent<CanvasGroup>();

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void resumeGame() {
        StartCoroutine(FadeFromTo(group.alpha, 0f));
        Time.timeScale = 1f;
    }

    IEnumerator FadeFromTo(float from, float to)
    {
        isFading = true;
        var curve = new AnimationCurve(new Keyframe[] {
            new Keyframe(0f, from),
            new Keyframe(1f, to)
        });

        float time = 0f;
        while (time < 1f)
        {
            group.alpha = curve.Evaluate(time);
            time += Time.deltaTime;

            yield return null;
        }

        group.alpha = curve.Evaluate(1f);
        isFading = false;
    }
}
