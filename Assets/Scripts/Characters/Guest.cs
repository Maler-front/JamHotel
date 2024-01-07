using UnityEngine;
using UnityEngine.UI;

public class Guest : DragObject
{
   public TaskSheet TaskSheet => _taskSheet;

   [Header("Tasks")]
   [Space]
   [SerializeField] private byte _tasksCount;
   private TaskSheet _taskSheet;
  
   [Header("UI")]
   [Space]
   [SerializeField] private TaskUI _taskPrefab;
   [SerializeField] private GameObject _holder;

    [Header("Body parts")]
    [Space]
    [SerializeField] private Image _headImage;
    [SerializeField] private Image _bodyImage;

    private void Start() 
   {
      _taskSheet = new TaskSheet(_tasksCount);  
   }

   private void ActivateSpeech()
   {
      TaskSheet.TaskInfo[] tasksInfo = _taskSheet.GetInfoForBubble();
      for(byte i = 0; i < tasksInfo.Length; i++)
      {
         Instantiate(_taskPrefab, _holder.transform).UpdateUI(tasksInfo[i].sprite, tasksInfo[i].count);
      }
   }

   private void DeativateSpeech()
   {
      foreach(Transform child in _holder.transform)
      {
         Destroy(child.gameObject);
      }
   }

    public void SetBodyParts(Sprite _headSprite, Sprite _bodySprite)
    {
        _headImage.sprite = _headSprite;
        _bodyImage.sprite = _bodySprite;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Reception>(out Reception reception)) 
        {
            _defaultPosition = collision.gameObject.transform.position;
            ActivateSpeech();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Reception>(out Reception reception))
        {
            DeativateSpeech();
        }
    }
}
