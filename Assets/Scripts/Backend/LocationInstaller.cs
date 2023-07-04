using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class LocationInstaller : MonoInstaller
{
    public Transform StartPoint;
    public Transform HeroPrefab;
    public Camera PlayerCamera;

    public override void InstallBindings()
    {
        BindCamera();
        BindPlayer();
    }
    private void BindCamera()
    {
        Container
            .Bind<Camera>()
            .FromInstance(PlayerCamera)
            .AsSingle();
    }
    private void BindPlayer()
    {
        PlayerController playerController = 
            Container.InstantiatePrefabForComponent<PlayerController>(HeroPrefab, StartPoint.position, Quaternion.identity, null);

        Container
            .Bind<PlayerController>()
            .FromInstance(playerController)
            .AsSingle();        
    }
}
