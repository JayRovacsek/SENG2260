
Ray ray = new Ray (transform.psotion, transform.forward);
RaycastHit hitInfo;

Physics.Raycast (ray, out hitInfo, 100)

Button button = hitInfo.collider.GetComponent<Button>();
if(button){
	button.click();
}