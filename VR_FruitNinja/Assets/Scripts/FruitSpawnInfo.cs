using System;
using System.ComponentModel;

[Serializable]
public class FruitSpawnInfo
{
    public SpawnedObejectsInfo ObjectType;
    public string ObjectTypes;
    public string ObjectName;
    public string SlicedTime;
    public bool isSlied;
    public string velocityOfSword;
    public float swordAngle;
}
public enum SpawnedObejectsInfo
{
    [Description("Fruit")]
    Fruit,
    [Description("Cake")]
    Cakes,
    [Description("Bomb")]
    Bomb,
    [Description("Missed")]
    Missed,
    [Description("Default")]
    Default
}