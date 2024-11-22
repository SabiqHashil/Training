// Contact Form Validation

function validateForm(event) {
  event.preventDefault();

  console.log("sduhdghgd")

  let isValid = true;

  // Clear previous error messages
  var errorFields = document.querySelectorAll(".error");
  errorFields.forEach((field) => (field.innerText = ""));

  // Get form field values
  var name = document.getElementById("name").value.trim();
  var email = document.getElementById("businessEmail").value.trim();
  var company = document.getElementById("companyName").value.trim();
  var code = document.getElementById("countryCode").value.trim();
  var phone = document.getElementById("phone").value.trim();
  var service = document.getElementById("service").value;

  // Name
  if (!name) {
    document.getElementById("nameError").innerText = "Name is required.";
    isValid = false;
  }

  // Company Name
  if (!company) {
    document.getElementById("companyError").innerText =
      "Company name is required.";
    isValid = false;
  }

  // Phone
  var phoneRegex = /^[6-9]\d{9}$/;
  if (!phone) {
    document.getElementById("phoneError").innerText =
      "Phone number is required.";
    isValid = false;
  } else if (!phoneRegex.test(phone)) {
    document.getElementById("phoneError").innerText =
      "Enter a valid 10-digit phone number.";
    isValid = false;
  }

  // Email
  var emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
  if (!email) {
    document.getElementById("emailError").innerText = "Email is required.";
    isValid = false;
  } else if (!emailRegex.test(email)) {
    document.getElementById("emailError").innerText =
      "Enter a valid email address.";
    isValid = false;
  }

  // Country Code
  if (!code) {
    document.getElementById("codeError").innerText =
      "Country code is required.";
    isValid = false;
  }

  // Service Selection
  if (!service) {
    document.getElementById("serviceError").innerText =
      "Please select a service.";
    isValid = false;
  }

  // Display message
  var statusMessage = document.getElementById("statusMessage");
  if (isValid) {
    statusMessage.innerText = "Form submitted successfully!";
    statusMessage.style.color = "green";

    // clear the form fields
    document.getElementById("contactForm").reset();
  } else {
    statusMessage.innerText = "Please fill all required fields correctly.";
    statusMessage.style.color = "red";
  }

  return isValid;
}

document.getElementById("contactForm").addEventListener("submit", validateForm);
