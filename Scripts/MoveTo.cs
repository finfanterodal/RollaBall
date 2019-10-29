 using UnityEngine;
 using UnityEngine.AI;

public class MoveTo : MonoBehaviour {

   public Transform goal;
   private NavMeshAgent agent;
   public float proximidad;
   public Animator animat;  
       void Start () {
          agent = GetComponent<NavMeshAgent>();
        animat = goal.GetComponent<Animator>();
       }

       void Update()
       {
        agent.SetDestination(goal.position);


         if (!agent.pathPending && agent.remainingDistance < proximidad)
        {
            Debug.Log("Peligro");
            animat.SetBool("Estar_en_Peligro", true);
        }
        else
        {
            Debug.Log("Tranqui");
            animat.SetBool("Estar_en_Peligro", false);
}
       }


}
