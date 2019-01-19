using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 50;
    private float x, y;

    // Start is called before the first frame update
    void Start()
    {
        // Set up the Editor before calling into the realtime database.
        FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://vr-hack-1547913415542.firebaseio.com");

        // Get the root reference location of the database.
        DatabaseReference reference = FirebaseDatabase.DefaultInstance.RootReference;
	
	FirebaseDatabase.DefaultInstance
        .GetReference("controllers/controller1")
        .ValueChanged += HandleValueChanged;

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(x*Time.deltaTime*speed,0f, -y*Time.deltaTime*speed);
    }
    void HandleValueChanged(object sender, ValueChangedEventArgs args) {
      if (args.DatabaseError != null) {
        Debug.LogError(args.DatabaseError.Message);
        return;
      }
      Dictionary<string, object> value = (Dictionary<string, object>) args.Snapshot.Value;
      x = float.Parse((string) value["x"]);
      y = float.Parse((string) value["y"]);
     }
}
