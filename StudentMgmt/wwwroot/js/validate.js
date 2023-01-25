const fname = document.getElementById("name");

fname.addEventListener("keyup", function (event) {
  isValidName = fname.checkValidity();

  if (isValidName) {
    document.querySelector("[data-valmsg-for='Student.Name']").innerHTML = "";
  } else {
    document.querySelector("[data-valmsg-for='Student.Name']").innerHTML =
      "Name must be atleast 3 character";
  }
  enableSubmit();
});

const contact = document.getElementById("contact");

contact.addEventListener("keyup", function (event) {
  isValidName = contact.checkValidity();

  if (isValidName) {
    document.querySelector("[data-valmsg-for='Student.Contact']").innerHTML =
      "";
  } else {
    document.querySelector("[data-valmsg-for='Student.Contact']").innerHTML =
      "Contact must be greater than 10 and less than 15";
  }
  enableSubmit();
});

const email = document.getElementById("email");

email.addEventListener("keyup", function (event) {
  isValidName = emailValidator(email.value);

  if (isValidName) {
    document.querySelector("[data-valmsg-for='Student.Email']").innerHTML = "";
  } else {
    document.querySelector("[data-valmsg-for='Student.Email']").innerHTML =
      "Invalid email";
  }
  enableSubmit();
});

function emailValidator(email) {
  if (
    /^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$/.test(
      email
    )
  ) {
    return true;
  } else {
    return false;
  }
}

/* function genderValidator() { */
/*   var checkRadio = document.querySelector( */
/*     'input[name="Student.Gender"]:checked' */
/*   ); */
/**/
/*   if (checkRadio != null) { */
/*     document.querySelector("[data-valmsg-for='Student.Email']").innerHTML = ""; */
/*   } else { */
/*     document.querySelector("[data-valmsg-for='Student.Email']").innerHTML = "Please Select the Radio Button"; */
/*   } */
/* } */

function enableSubmit() {
  const submit = document.getElementById("submit");
  if (
    contact.checkValidity() &&
    fname.checkValidity() &&
    emailValidator(email.value)  ) {
    submit.disabled = false;
  } else {
    submit.disabled = true;
  }
}
