using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

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

   private void OnCollisionEnter2D(Collision2D other) 
   {
      if(other.collider.tag == "Reception")
      {
         ActivateSpeech();
      }
   }

   private void OnCollisionExit2D(Collision2D other) 
   {
      if(other.collider.tag == "Reception")
      {
         DeativateSpeech();
      }
   }
}
