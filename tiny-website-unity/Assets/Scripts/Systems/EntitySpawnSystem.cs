using Unity.Entities;
using Unity.Mathematics;
using Unity.Tiny;
using Unity.Transforms;

public class EntitySpawnSystem : SystemBase
{
    private float spawnTimer;
    private Random random;

    protected override void OnStartRunning()
    {
        base.OnStartRunning();
        var di = GetSingleton<DisplayInfo>();
        di.backgroundBorderColor = new Color(0.48309f, 0.8679245f, 0.546957f);
        SetSingleton(di);
    }

    protected override void OnCreate()
    {
        random = new Random(42);
    }

    protected override void OnUpdate()
    {
        spawnTimer -= Time.DeltaTime;

        if (spawnTimer <= 0f)
        {
            spawnTimer = 0.5f;

            Entities.ForEach((in SpawnePrefab spawned) =>
            {
                var explosionEntity = EntityManager.Instantiate(spawned.prefabEntity);
                var position = new float3(random.NextFloat(spawned.spawnRangeX.x, spawned.spawnRangeX.y), random.NextFloat(spawned.spawnRangeY.x, spawned.spawnRangeY.y), random.NextFloat(spawned.spawnRangeZ.x, spawned.spawnRangeZ.y));
                EntityManager.SetComponentData(explosionEntity, new Translation { Value = position });
            }).WithStructuralChanges().Run();
        }
    }
}