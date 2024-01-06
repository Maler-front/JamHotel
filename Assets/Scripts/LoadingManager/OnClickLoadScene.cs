using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class OnClickLoadScene : MonoBehaviour
{
    [SerializeField][Tooltip("The button that allows you to exit the game")] private Button _exitButton;
    [SerializeField] [Tooltip("The button that enables the transition to another scene")] private Button _activateButton;
    [SerializeField] [Tooltip("The index of the scene to go to when you click on the button")] private int _sceneIndex;

    private void Awake()
    {
        if(_activateButton == null)
        {
            if(!TryGetComponent(out _activateButton))
            {
                Debug.LogWarning($"You dont have activate button on {name}");
                return;
            }
        }

        if (_exitButton == null)
        {
            if (!TryGetComponent(out _exitButton))
            {
                Debug.LogWarning($"You dont have warning button on {name}");
                return;
            }
        }

        if(_exitButton == null && _activateButton == null)
        {
            Debug.LogError($"You dont have warning and activate buttons on {name}");
        }

        if (_sceneIndex < 0 || _sceneIndex > SceneManager.sceneCountInBuildSettings - 1)
        {
            Debug.LogError($"You cannot load a scene with index {_sceneIndex}");
        }
    }
    private void Start()
    {
        if (_exitButton != null)
        {
            _exitButton.onClick.AddListener(LoadingManager.Instance.ExitGame);
        }

        if(_activateButton != null)
        {
            bool activeButtonEnabledState = _activateButton.enabled;
            _activateButton.enabled = true;
            _activateButton.onClick.AddListener(() => LoadingManager.Instance.LoadScene(_sceneIndex));
            _activateButton.enabled = activeButtonEnabledState;
        }
    }
}
