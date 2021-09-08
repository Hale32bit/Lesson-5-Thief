
using UnityEngine;

[DisallowMultipleComponent]
public class Door : MonoBehaviour
{

    public Vector3 InsideDirection => this.transform.up;

}
