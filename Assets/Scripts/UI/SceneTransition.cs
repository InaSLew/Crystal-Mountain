using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Transitions between scenes through playing fading-in and -out animations
/// </summary>
public class SceneTransition : MonoBehaviour
{
    private Animator animator;
    private static readonly int FadeOut = Animator.StringToHash("fadeOut");

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void OnHasWinCondition()
    {
        animator.SetTrigger(FadeOut);
    }

    public void OnPlayerWin()
    {
        animator.SetTrigger(FadeOut);
    }

    /// <summary>
    /// An animation event that fires when animation FadingOut completes. See the animation clip asset FadingOut
    /// </summary>
    public void OnFadeOutComplete()
    {
        var activeScene = SceneManager.GetActiveScene().buildIndex;
        if (activeScene == SceneManager.sceneCountInBuildSettings - 1) SceneManager.LoadScene(0);
        else SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
