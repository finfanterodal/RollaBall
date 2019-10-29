using UnityEngine;
using UnityEngine.UI;
using System.Collections;
public class PlayerController : MonoBehaviour {
 
    public Text countText;
    public Text winText;
    private int count;
    public float speed = 4f;
	//Variable qu epermite a los GameObjects 
	//actuar bajo la física(que le apliquemos fuerzas)
    private Rigidbody rb;
	//Primer Frame que está activo	
    void Start ()
    {
		//Reconoce el componente del GameObject.
        rb = GetComponent<Rigidbody>();  
        SetCountText ();    
        count = 0;
        winText.text = "";   
    }
	//FixedUpdate se llama antes de realizar un cálculo de física
    void FixedUpdate ()
    {
		//Variables movimiento de ejes.
        float moveHorizontal = Input.GetAxis ("Horizontal");
        float moveVertical = Input.GetAxis ("Vertical");
		//Vector relativo al (0,0,0)
        Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		//Aplica una fuerza en función de una aceleración en dirección al vector.
        rb.AddForce (movement * speed);
    }

    
     void OnTriggerEnter(Collider other)
    {
              if (other.gameObject.CompareTag ( "Pick Up"))
        {
            other.gameObject.SetActive (false);
            count = count + 10;
            SetCountText ();
        } 

             if (other.gameObject.tag == "Enemy")
        {
            count = count - 3;
            SetCountText();
            // vuelve al centro del tablero
            rb.transform.position = Vector3.zero;     
                          
            ;
}
    }
      void SetCountText ()
    {
        countText.text = "Count: " + count.ToString ();
        if (count >= 80)
        {
            winText.text = "You Win!";
            
        }
    }
   
}