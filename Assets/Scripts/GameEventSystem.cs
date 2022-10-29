using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEventSystem : MonoBehaviour
{
    public static GameEventSystem current;

    private void Awake() {
        current = this;
    }
    
    // вот это образец описания ивента
    /*
    public event Action onRoomTriggerEvent;

    public void RoomTriggerEnter() {
        if (onRoomTriggerEvent != null) {
            onRoomTriggerEvent();
        }
    }*/
}
