using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    public bool isCollected = false;
    [SerializeField] private Transform characterTransform;
}
