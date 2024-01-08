using UnityEngine.SceneManagement;
using UnityEngine;
using System.Collections;


public class LoadingManager : MonoBehaviour 
{
    [SerializeField] private bool _haveAnimations = false;

    public static LoadingManager Instance { get; private set; }

    private Animator _animator;

    private static float _minTimeLoading = 1f;
    private AsyncOperation _loadingOperation;
    private float _loadingTime = 0f;

    private void Awake()
    {
        Instance = this;

        if(_haveAnimations)
        {
            _animator = GetComponent<Animator>();
        }

        Time.timeScale = 1f;
    }

    private void Start()
    {
        if (_haveAnimations)
        {
            _animator.SetTrigger("OpenScene");
        }
    }

    public void ExitGame()
    {
        if (_haveAnimations)
        {
            _animator.SetTrigger("CloseScene");
        }
        Application.Quit();
    }

    public void LoadScene(int sceneIndex)
    {
        if (_haveAnimations)
        {
            _animator.SetTrigger("CloseScene");
        }

        StartCoroutine(ClosingAnimationEnd(sceneIndex));

    }

    private IEnumerator ClosingAnimationEnd(int sceneIndex)
    {
        if (_haveAnimations)
        {
            while (!_animator.GetBool("CloseScene"))
                yield return null;
        }

        if (sceneIndex < 0 || sceneIndex > SceneManager.sceneCountInBuildSettings - 1)
        {
            Debug.LogError($"You cannot load a scene with index {sceneIndex}");
        }
        else
        {
            _loadingOperation = SceneManager.LoadSceneAsync(sceneIndex);
            _loadingOperation.allowSceneActivation = false;

            StartCoroutine(ChangeSceneAfterMinLoadingTime());
        }
    }

    private IEnumerator ChangeSceneAfterMinLoadingTime()
    {
        while (_loadingTime < _minTimeLoading)
        {
            _loadingTime += Time.unscaledDeltaTime;
            yield return null;
        }

        _loadingOperation.allowSceneActivation = true;
    }
}
