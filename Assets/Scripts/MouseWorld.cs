using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseWorld : MonoBehaviour
{

    private static MouseWorld instance;


    [SerializeField] private LayerMask mousePlaneLayerMask;

    private void Awake()
    {
        instance = this;
    }

     public static Vector3 GetPosition()
    {
         Ray ray;
         if(Input.touchCount > 0){

            Touch touch = Input.GetTouch(0);
            ray = Camera.main.ScreenPointToRay(touch.position);

        }else{
            
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        }

        
        Physics.Raycast(ray, out RaycastHit raycastHit, float.MaxValue, instance.mousePlaneLayerMask);
        return raycastHit.point;
    }

}