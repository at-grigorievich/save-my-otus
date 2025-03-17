using GameEngine;
using UnityEngine;
using VContainer.Unity;

public sealed class GameSceneEntryPoint : IStartable, ITickable
{
    private readonly UnitManager _unitManager;
    private readonly ResourceService _resourceService;

    public GameSceneEntryPoint(UnitManager unitManager, ResourceService resourceService)
    {
        _unitManager = unitManager;
        _resourceService = resourceService;
    }
    
    public void Start()
    {
        _unitManager.SetupUnits(GameObject.FindObjectsOfType<Unit>());
        _resourceService.SetResources(GameObject.FindObjectsOfType<Resource>());
    }

    public void Tick()
    {
        //for perfect future...
    }
}