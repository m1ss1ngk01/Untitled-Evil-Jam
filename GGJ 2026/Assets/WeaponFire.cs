using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class WeaponFirer : MonoBehaviour
{
    public UnityEvent OnFire;

    // Update is called once per frame
    void Update()
    {
        bool firing = InputSystem.GetDevice<Mouse>().leftButton.wasPressedThisFrame;
        Debug.Log(firing);
        if (firing)
            OnFire.Invoke();
    }
}
