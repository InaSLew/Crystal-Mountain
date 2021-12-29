using System;
using UnityEngine.Events;

/// <summary>
/// An UnityEvent with GenericVoid as return type to be able to pass to BaseGameEventListener
/// </summary>
[Serializable]
public class UnityVoidEvent : UnityEvent<GenericVoid> {}
