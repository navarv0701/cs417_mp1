using UnityEngine;

public class VaultDoorClose : MonoBehaviour
{
    [SerializeField] private Animator myDoor;
    [SerializeField] private AudioSource soundSource;
    [SerializeField] private AudioClip sound;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player entered trigger!");
            myDoor.Play("DoorClose", 0, 0.0f);
            soundSource.PlayOneShot(sound);
        }
    }
}
