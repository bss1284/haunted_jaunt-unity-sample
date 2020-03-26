using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEnding : MonoBehaviour
{
    public float fadeDuration=1f;
    public float displayImageDuration = 1f;

    public CanvasGroup fadeWonImageCanvasGroup;
    public CanvasGroup fadeCaughtImageCanvasGroup;

    public void CaughtEnd() {
        StartCoroutine(EndGameAsync(fadeCaughtImageCanvasGroup, true));
    }

    private void OnTriggerEnter(Collider other) {
        if (other.tag=="Player") {
            StartCoroutine(EndGameAsync(fadeWonImageCanvasGroup,false));
        }
    }

    private IEnumerator EndGameAsync(CanvasGroup fadeImage,bool restart) {
        float t = 0f;
        while (true) {
            t += Time.deltaTime;
            var alpha = t / fadeDuration;
            fadeImage.alpha = alpha;
            if (Mathf.Approximately(alpha,1f) || alpha > 1f ) {
                break;
            }
            yield return null;
        }
        fadeImage.alpha = 1f;
        yield return new WaitForSeconds(displayImageDuration);

        if (restart) {
            SceneManager.LoadScene(0);
        }else {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        }

    }
}
