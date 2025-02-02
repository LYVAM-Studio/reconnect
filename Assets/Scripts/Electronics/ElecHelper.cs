using System;
using JetBrains.Annotations;
using UnityEngine;

namespace Reconnect.Electronics
{
    public static class ElecHelper
    {
        private static Camera _cam;

        public static Camera MainCamera
        {
            get
            {
                if (_cam is null)
                {
                    _cam = Camera.main;
                    if (_cam is null)
                        throw new Exception("No main camera has been found.");
                }
                return _cam;
            }
        }

        // Gets the position of the cursor projected on the breadboard plane. This vector's z component is therefore always 0.
        public static Vector3 GetFlattedCursorPos(float distanceCamBreadboard = 8f)
        {
            var ray = MainCamera.ScreenPointToRay(Input.mousePosition);
            var rayDirection = ray.direction;
            return new Vector3(
                rayDirection.x / rayDirection.z * distanceCamBreadboard,
                rayDirection.y / rayDirection.z * distanceCamBreadboard,
                0);
        }
        
    }

}