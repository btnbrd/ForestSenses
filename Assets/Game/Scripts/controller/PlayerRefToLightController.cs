using System;
using System.Collections;
using System.Collections.Generic;
using Controller;
using UnityEngine;

// Как юзать:
// 1. Повесить на геймобджект игрока.
// 2. Присвоить lightController = <лайт контроллер на сцене>
// 3. Черника и другие чуваки, найдя геймобджект игрока, могут найти у него этот компонент и по нему найти свет, и повлиять на свет.
public class PlayerRefToLightController : MonoBehaviour
{
    public LightController lightController;

    void Start()
    {
        if (lightController is null)
        {
            throw new InvalidOperationException("Light controller for PlayerRefToLightController not set!");
        }
    }
}
