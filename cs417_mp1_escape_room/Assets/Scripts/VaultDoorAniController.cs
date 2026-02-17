using System.Runtime.CompilerServices;
using UnityEngine;

public class VaultDoorAniController : MonoBehaviour
{
    [SerializeField] private Animator myDoor = null;
    
    private void open()
    {
        myDoor.Play("DoorOpen", 0, 0.0f);
    }

    private void close()
    {
        myDoor.Play("DoorClose", 0, 0.0f);
    }
}
