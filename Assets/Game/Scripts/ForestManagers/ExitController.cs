using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ForestManagers
{
    public class ExitController : MonoBehaviour
    {
        private void Update()
        {
            if (Input.anyKeyDown)
            {
                SceneManager.LoadScene(0);
            }
        }
    }
}