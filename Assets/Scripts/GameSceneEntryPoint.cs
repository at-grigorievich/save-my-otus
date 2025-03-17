using GameEngine;
using SaveSystem;
using UnityEngine;
using VContainer.Unity;

public sealed class GameSceneEntryPoint : IStartable, ITickable
{
    private readonly UnitManager _unitManager;
    private readonly ResourceService _resourceService;
    
    private readonly ISaveLoaderFacade _saveLoaderFacade;

    public GameSceneEntryPoint(UnitManager unitManager, ResourceService resourceService,
        ISaveLoaderFacade saveLoaderFacade)
    {
        _unitManager = unitManager;
        _resourceService = resourceService;
        
        _saveLoaderFacade = saveLoaderFacade;
    }
    
    public void Start()
    {
        _unitManager.SetupUnits(GameObject.FindObjectsOfType<Unit>());
        _resourceService.SetResources(GameObject.FindObjectsOfType<Resource>());
        
        _saveLoaderFacade.Load();
    }

    public void Tick()
    {
        //for perfect future...
    }
    
}