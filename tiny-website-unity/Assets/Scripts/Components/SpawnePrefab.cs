using Unity.Entities;
using Unity.Mathematics;

[GenerateAuthoringComponent]
public class SpawnePrefab : IComponentData
{
    public Entity prefabEntity;

    public float2 spawnRangeX;
    public float2 spawnRangeY;
    public float2 spawnRangeZ;
}