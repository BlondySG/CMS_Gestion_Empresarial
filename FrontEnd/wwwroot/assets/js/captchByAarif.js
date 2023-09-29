myFunction();
var val = [];
val.push("VQ7W3");     /** push value in this array  */
val.push("A1234");     /** To maintain image order here   */
val.push("A32BD");   /** if first image 0_capt.jpeg contains value VQ7W3 so push this value into zero(0) index of array   */
val.push("LD673");
val.push("PQ78V");
val.push("MX81W");
var x;
/**This below method generate random number from 0-5
 * name of image starts with that number will set on 
 * captcha location 
 */
function myFunction() {
	x = Math.floor(Math.random() * 6);     // here 6 stand for how many images you are using return 0-6 number.
	$("#imgCaptchaPlace").html("<img id='abc' src='/assets/images/captcha_images/" + x + "_cpt.jpg'/>");
}

/**
 * This below method will call on change of input fields where user enter
 * captcha code value
 */
function chaeckCpatch(id) {
	if ($("#" + id).val() == val[x]) {
		$("#acceder").html("<input type='submit' value='Acceder' class='btn btn-primary radius-30'/>");
	}
	else {
		alert("Error!!! Verifique el captcha ingresado");
	}

}