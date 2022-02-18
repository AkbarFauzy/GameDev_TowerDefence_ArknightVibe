using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackRange : MonoBehaviour
{
    [SerializeField] private Character character;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Character target = other.gameObject.GetComponent<Character>();
            if (!character.Target.Contains(target))
            {
                character.Target.Add(target);
            }
            if (! character.IsAttacking) {
                character.IsAttacking = true;
                StartCoroutine(character.Attack());
            }

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Enemy") {
            Character target = other.gameObject.GetComponent<Character>();
            character.Target.Remove(target);
        }
    }

}
