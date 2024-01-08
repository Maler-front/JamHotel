using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Employee : DragObject
{
    public float Efficiency => _efficiency;

    public enum EmployeeType
    {
        Cleaning = 0,
        Cook = 1,
        Maintenance = 2,
        Manager = -1
    }

    [Header("Employee Type")]
    [Space]
    [SerializeField] private EmployeeType _type;

    public EmployeeType Type
    {
        get { return _type;  }
        set { }
    }
    
    [Header("Stats")]
    [Space]
    [SerializeField] private float _movementSpeed; 
    [SerializeField] private float _efficiency;

}
