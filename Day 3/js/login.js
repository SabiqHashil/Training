// Login Form Validation

function validateForm() {
  var email = document.getElementById("email");
  var password = document.getElementById("password");
  var emailError = document.getElementById("emailError");
  var passwordError = document.getElementById("passwordError");
  var status = document.getElementById("status");

  var isValid = true;

  // Validate Email
  if (!email.value) {
    emailError.textContent = "Email is required.";
    emailError.classList.add("error");
    emailError.classList.remove("success");
    isValid = false;
  } else if (!validateEmail(email.value)) {
    emailError.textContent = "Please enter a valid email address.";
    emailError.classList.add("error");
    emailError.classList.remove("success");
    isValid = false;
  } else {
    emailError.textContent = "Valid email!";
    emailError.classList.add("success");
    emailError.classList.remove("error");
  }

  // Validate Password
  if (!password.value) {
    passwordError.textContent = "Password is required.";
    passwordError.classList.add("error");
    passwordError.classList.remove("success");
    isValid = false;
  } else if (password.value.length < 6) {
    passwordError.textContent = "Password must be at least 6 characters.";
    passwordError.classList.add("error");
    passwordError.classList.remove("success");
    isValid = false;
  } else {
    passwordError.textContent = "Password is strong!";
    passwordError.classList.add("success");
    passwordError.classList.remove("error");
  }

  if (isValid) {
    status.textContent = "Login successful!";
    status.classList.add("success");
    status.classList.remove("error");
  } else {
    status.textContent = "Please enter email and password.";
    status.classList.add("error");
    status.classList.remove("success");
  }
}

function validateEmail(email) {
  var regex = /^[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,6}$/;
  return regex.test(email);
}

// Focus event
document.getElementById("email").addEventListener("focus", function () {
  var emailError = document.getElementById("emailError");
  emailError.textContent = "Please enter a valid email address.";
  emailError.classList.remove("success");
  emailError.classList.add("error");
});

document.getElementById("password").addEventListener("focus", function () {
  var passwordError = document.getElementById("passwordError");
  passwordError.textContent = "Password must be at least 6 characters long.";
  passwordError.classList.remove("success");
  passwordError.classList.add("error");
});

// Real-time validation while typing
document.getElementById("email").addEventListener("keyup", function () {
  var emailError = document.getElementById("emailError");
  if (!this.value) {
    emailError.textContent = "Email is required.";
    emailError.classList.add("error");
    emailError.classList.remove("success");
  } else if (!validateEmail(this.value)) {
    emailError.textContent = "Please enter a valid email address.";
    emailError.classList.add("error");
    emailError.classList.remove("success");
  } else {
    emailError.textContent = "Valid email!";
    emailError.classList.add("success");
    emailError.classList.remove("error");
  }
});

document.getElementById("password").addEventListener("keyup", function () {
  var passwordError = document.getElementById("passwordError");
  if (!this.value) {
    passwordError.textContent = "Password is required.";
    passwordError.classList.add("error");
    passwordError.classList.remove("success");
  } else if (this.value.length < 6) {
    passwordError.textContent = "Password must be at least 6 characters.";
    passwordError.classList.add("error");
    passwordError.classList.remove("success");
  } else {
    passwordError.textContent = "Password is strong!";
    passwordError.classList.add("success");
    passwordError.classList.remove("error");
  }
});
