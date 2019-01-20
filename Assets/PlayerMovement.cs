using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;
    public Camera Cam;
	
    private float x, y;
	private bool jump, trigger;
    // Start is called before the first frame update
    void Start() {
        // Set up the Editor before calling into the realtime database.
        FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://vr-hack-1547913415542.firebaseio.com");

        // Get the root reference location of the database.
        DatabaseReference reference = FirebaseDatabase.DefaultInstance.RootReference;
	
	FirebaseDatabase.DefaultInstance
        .GetReference("controllers/controller1")
        .ValueChanged += HandleValueChanged;
    }

    void HandleValueChanged(object sender, ValueChangedEventArgs args) {
      if (args.DatabaseError != null) {
        Debug.LogError(args.DatabaseError.Message);
        return;
      }
      Dictionary<string, object> value = (Dictionary<string, object>) args.Snapshot.Value;
      x = float.Parse((string) value["x"]);
      y = float.Parse((string) value["y"]);
	  jump = (bool) value["jump"];
     }

    // Update is called once per frame
    void FixedUpdate()
    {
		float DistanceToTheGround = GetComponent<Collider>().bounds.extents.y;
		float force = 0.025f;
		float inAir = 1;
		
		if ((jump || Input.GetKey("j")) && !trigger) {
			rb.AddForce(0, 1200 * Time.deltaTime, 0);
			trigger = true;
			inAir = 0.5f;
		} else if ((!jump || !Input.GetKey("j")) && trigger && isGrounded()) {
			trigger = false;
			inAir = 1;
		}
            
		if (x > 0 || Input.GetKey("s")) {
			rb.MovePosition(rb.position + new Vector3(0,0,-force*inAir));
		} else if (y > 0 || Input.GetKey("d")){
			rb.MovePosition(rb.position + new Vector3(force*inAir,0,0));
		} if (x < 0 || Input.GetKey("w")) {
			rb.MovePosition(rb.position + new Vector3(0,0,force*inAir));
		} else if (y < 0 || Input.GetKey("a")) {
			rb.MovePosition(rb.position + new Vector3(-force*inAir,0,0));
		}
    }
	
 
	 bool isGrounded() {
		 return Physics.Raycast(rb.position, new Vector3(0, -1, 0), 1);
	 }
	}
