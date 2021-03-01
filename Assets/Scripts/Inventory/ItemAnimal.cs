using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemAnimal
{
   public enum Type
    {
        Pig,
        Mouse,
        Bird
    }

    public AnimalSC animal;
    public int amount;

    public Sprite GetSprite() {
        return animal.animalSprite;
    }

    public bool IsStackable() {
        return true;
    }

    public override string ToString() {
        return animal.animalName;
    }
}
