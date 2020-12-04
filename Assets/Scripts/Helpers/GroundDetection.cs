
using UnityEngine;

namespace Utils.Checker{
    public class GroundDetection : MonoBehaviour
    {
         //Components
         private Transform _position;
         private LayerMask _layerToDetect;
         private float _radius = 0.7f;
         public bool isGrounded { get; set; }

         public GroundDetection(Transform _position, LayerMask _layerToDetect, float _radius = 0.7f)
         {
              this._position = _position;
              this._layerToDetect = _layerToDetect;
              this._radius = _radius;
         }

          public bool CheckGround()
          {
               return Physics.CheckSphere(_position.position, _radius, _layerToDetect);
          }

    }
}

