using UnityEngine;

public static class MouseUtility
{ 
  
    //
    // Summary :
    //     Return Mouse World Position.
    public static Vector3 GetMouseWorldPosition()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Physics.Raycast(ray, out RaycastHit raycastHit, float.MaxValue, 1 << 6);
        return raycastHit.point;
    }
}
