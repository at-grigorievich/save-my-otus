using System;
using GameEngine;
using GameEngine.Save;
using SaveSystem;
using UnityEngine;
using VContainer;
using VContainer.Unity;

[Serializable]
public sealed class UnitManagerFactory
{
    [SerializeField] private Transform unitContainer;

    public void Create(IContainerBuilder builder)
    {
        builder.Register<UnitManager>(Lifetime.Singleton)
            .WithParameter<Transform>(unitContainer);
    }
}

[Serializable]
public sealed class ResourceServiceFactory
{
    public void Create(IContainerBuilder builder)
    {
        builder.Register<ResourceService>(Lifetime.Singleton);
    }
}

public sealed class GameSceneScope: LifetimeScope
{
    [SerializeField] private UnitManagerFactory unitManagerFactory;
    [SerializeField] private ResourceServiceFactory resourceServiceFactory;

    protected override void Configure(IContainerBuilder builder)
    {
        unitManagerFactory.Create(builder);
        resourceServiceFactory.Create(builder);

        builder.Register<SerializableRepository>(Lifetime.Singleton).AsImplementedInterfaces();

        builder.Register<UnitsSaveLoader>(Lifetime.Singleton).As<ISaveLoader>();
        
        builder.Register<ISaveLoaderFacade, SaveLoadersFacade>(Lifetime.Singleton);
        
        builder.RegisterEntryPoint<GameSceneEntryPoint>();
    }
}