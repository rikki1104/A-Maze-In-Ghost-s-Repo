using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Maze_Game.Core
{
    public class ObjectRotate : MonoBehaviour
    {
        [SerializeField] float xRotation = 0f;
        [SerializeField] float yRotation = 0f;
        [SerializeField] float zRotation = 0f;

        void Update()
        {
            transform.Rotate(new Vector3(xRotation, yRotation, zRotation) * Time.deltaTime);
        }
    }
}
