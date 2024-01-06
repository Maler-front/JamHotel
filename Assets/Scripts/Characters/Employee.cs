using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Employee : DragObject
{
    public float Efficiency => _efficiency;

    private enum EmployeeType
    {
        Manager,
        Cleaning,
        Concierge,
        Maintenance,
        Cook
    }

    [Header("Employee Type")]
    [Space]
    [SerializeField] private EmployeeType _type;
    
    [Header("Stats")]
    [Space]
    [SerializeField] private float _movementSpeed; 
    [SerializeField] private float _efficiency;

}
