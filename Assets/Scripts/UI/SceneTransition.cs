using UnityEngine;
using UnityEngine.SceneManagement;

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

    /// <summary>
    /// An animation event that fires when animation FadingOut completes. See the animation clip asset FadingOut
    /// </summary>
    public void OnFadeOutComplete()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
