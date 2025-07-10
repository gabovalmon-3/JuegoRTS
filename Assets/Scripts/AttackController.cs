using UnityEngine;

public class AttackController : MonoBehaviour
{
    public Transform targetToAttack;

    public Material idelStateMaterial;
    public Material followStateMaterial;
    public Material attackStateMaterial;
    public int UnitDamage; 

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy") && targetToAttack == null)
        {
            targetToAttack = other.transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Enemy") && targetToAttack != other.transform)
        {
            targetToAttack = null;
        }
    }

    public void SetIdleMaterial()
    {
        GetComponent<Renderer>().material = idelStateMaterial;
    }
    public void SetFollowMaterial()
    {
        GetComponent<Renderer>().material = followStateMaterial;
    }
    public void SetAttackMaterial()
    {
        GetComponent<Renderer>().material = attackStateMaterial;
    }

    private void OnDrawGizmos()
    {
        //Follow distance / Area
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, 10f*0.2f); // Example radius for follow distance

        //Attack distance / Area
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, 1f); // Example radius for attack distance

        //Stop Attack distance / Area
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, 1.2f); // Example radius for stop attack distance
    }
}
