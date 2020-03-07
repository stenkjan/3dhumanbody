public class VrRig : MonoBehaviour
    

{
    //Tracking Funktion
    public VrMap head;
    public VrMap leftHand;
    public VrMap rightHand;
    public Transform HeadConstraint;
public Vector3 headBodyOffest;
   
    void Start()
    {
        headBodyOffest = transform.position - HeadConstraint.position;
    }

   
    void Update()
    {
        //Transformiert die Position zu den jeweiligen Teilen
        transform.position = HeadConstraint.position + headBodyOffest;
        transform.forward = Vector3.ProjectOnPlane(HeadConstraint.up,Vector3.up).normalized;
        head.Map();
        leftHand.Map();
        rightHand.Map();

    }
}
