using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace Maze_Game.Core
{
    public class LookXY : MonoBehaviour
    {
        [SerializeField] float cameraSmoothing = 1;
        [SerializeField] float lookXMax = 45;
        [SerializeField] float lookXMin = -45;

        float invertLookAxis = -1;

        private Quaternion canRotate;

        // Start is called before the first frame update
        void Start()
        {
            canRotate = transform.localRotation;
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            canRotate.x += Input.GetAxis("Mouse Y") * cameraSmoothing * (invertLookAxis);

            canRotate.x = Mathf.Clamp(canRotate.x, lookXMin, lookXMax);

            transform.localRotation = Quaternion.Euler(canRotate.x, canRotate.y, canRotate.z);
        }
    }
}
