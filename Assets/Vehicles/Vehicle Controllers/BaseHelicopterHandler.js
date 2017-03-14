#pragma strict

// We use the Editor to assign the two rotor game objects to these variables
var mainRotor : GameObject;
var tailRotor : GameObject;

var maxRotorForce : float = 24000;
var maxRotorVelocity : float =  7200;
static var rotorVelocity : float = 0;
private var rotorRotation : float = 0;

var maxTailRotorForce : float = 25000;
var maxTailRotorVelocity : float = 2200;
private var tailRotorVelocity : float = 0;
private var tailRotorRotation : float = 0;

var forwardRotorTorqueMultiplier : float = 0.5;
var sidewaysRotorTorqueMultiplier : float = 0.5;

var mainRotorActive : boolean = true;
var tailRotorActive : boolean = true;

private var rb : Rigidbody;

function Start(){
	rb = GetComponent(Rigidbody);
}

function FixedUpdate(){

	var torqueValue : Vector3;
	var controlTorque : Vector3 = new Vector3(Input.GetAxis("Vertical") * forwardRotorTorqueMultiplier, 1.0, -Input.GetAxis("Horizontal2") * sidewaysRotorTorqueMultiplier);
	if(mainRotorActive == true){
		torqueValue += (controlTorque * maxRotorForce * rotorVelocity);
		rb.AddRelativeForce(Vector3.up * maxRotorForce * rotorVelocity);
	}
	if(Vector3.Angle(Vector3.up,transform.up) <80 ){
		transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0,transform.rotation.eulerAngles.y,0), Time.deltaTime * rotorVelocity * 2);
	}
	if(tailRotorActive == true){
		torqueValue -= (Vector3.up * maxTailRotorForce * tailRotorVelocity);
		rb.AddRelativeTorque(torqueValue);
	}
}

function Update(){
	rb = GetComponent(Rigidbody);
	
	if(mainRotorActive == true){
		mainRotor.transform.rotation = transform.rotation * Quaternion.Euler(270,rotorRotation,0);
	}
	if(tailRotorActive == true){
		tailRotor.transform.rotation = transform.rotation * Quaternion.Euler(0,270,tailRotorRotation);
	}
	rotorRotation += maxRotorVelocity * rotorVelocity * Time.deltaTime;
	tailRotorRotation += maxTailRotorVelocity * rotorVelocity * Time.deltaTime;		
	
	var hoverRotorVelocity = (rb.mass * Mathf.Abs( Physics.gravity.y ) / maxRotorForce);
	var hoverTailRotorVelocity = (maxRotorForce * rotorVelocity) / maxTailRotorForce; 
	
	if (Input.GetAxis( "Vertical2" ) != 0.0 ) { 
		rotorVelocity += Input.GetAxis( "Vertical2" ) * 0.005; 
	}
	else{
		rotorVelocity = Mathf.Lerp( rotorVelocity, hoverRotorVelocity, Time.deltaTime * Time.deltaTime * 5 ); 
	} 
	tailRotorVelocity = hoverTailRotorVelocity - Input.GetAxis( "Horizontal" ) * 0.01; 
	if ( rotorVelocity > 1.0 ) { 
		rotorVelocity = 1.0; 
	}
	else if ( rotorVelocity < 0.0 ) { 
		rotorVelocity = 0.0; 
	}
}




	