using UnityEngine;

public enum SwipeDirection { 
    X,
    Z
}

public class InputController : MonoBehaviour {

    [SerializeField] Camera _camera;
    [SerializeField] Transform _dot;
    Vector3 _startPosition;
    [SerializeField] Player[] _allPlayers;

    private void Update() {

        Plane plane = new Plane(Vector3.up, new Vector3(0, 0, 0));
        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
        float distance;
        plane.Raycast(ray, out distance);
        Vector3 position = ray.GetPoint(distance);
        //
        _dot.position = position;

        if (Input.GetMouseButtonDown(0)) {
            _startPosition = position;
        }
        if (Input.GetMouseButtonUp(0)) {

            Vector3 delta = position - _startPosition;
            SwipeDirection swipeDirection;

            if (delta.magnitude > 1.2f) {
                if (Mathf.Abs(delta.x) > Mathf.Abs(delta.z)) {
                    swipeDirection = SwipeDirection.X;
                    foreach (Player p in _allPlayers) {
                        p.Swipe(swipeDirection, Mathf.Sign(delta.x));
                    }
                } else {
                    swipeDirection = SwipeDirection.Z;
                    foreach (Player p in _allPlayers) {
                        p.Swipe(swipeDirection, Mathf.Sign(delta.z));
                    }
                }
            }
            
        }


    }

}
