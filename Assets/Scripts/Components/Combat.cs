using UnityEngine;
using System.Collections;

public class Combat : MonoBehaviour {

    public virtual void Attack(float facing) { }
    public virtual void Attack(float facing, float delay) { }
}
