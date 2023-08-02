using System;

[Serializable]
public class FruitSpawnInfo 
{
     public SpawnedObejectsInfo ObjectType;
     public string ObjectName;
     public string SlicedTime;
     public bool isSlied;
     public string velocityOfSword;
     public float swordAngle;
}
public enum SpawnedObejectsInfo
{
     Fruit,
     Cakes,
     Bomb,
     Missed,
     Default
}