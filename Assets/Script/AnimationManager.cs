using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimationManager : MonoBehaviour
{
    [Header("Animator")]
    [SerializeField] private Animator tear_Animator;
    [SerializeField] private Animator resize_Animator;

    #region Private
    private IEnumerator PlayAndWait(System.Action onFinish)
    {
        resize_Animator.SetBool("isResize", false);
        tear_Animator.SetTrigger("IsTear");

        yield return new WaitForSeconds(1f); 
        onFinish?.Invoke(); // ฉีกเสร็จแล้ว
    }

    public IEnumerator ResizeDone()
    {
        resize_Animator.SetBool("isResize", true);
        yield return new WaitForSeconds(1f);
    }
    #endregion



    #region Public
    public void PlayTear_Animator(System.Action onFinish)
    {
        StartCoroutine(PlayAndWait(onFinish));
    }

    #endregion
}
