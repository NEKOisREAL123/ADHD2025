using System;
using UnityEngine;

[Serializable]
public class User
{
    [SerializeField] private string name;
    public string Name { get => name; set => name = value; }
    [SerializeField] private string gender;
    public string Gender { get => gender; set => gender = value; }
    [SerializeField] private int age;
    public int Age { get => age; set => age = value; }
}