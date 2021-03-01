using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Animals/Animal")]
public class AnimalSC : ScriptableObject
{
    public string animalName;
    public Sprite animalSprite;
    public string weight;
}
