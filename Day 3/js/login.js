// Login Form Validation
function validateForm() {
    const email = document.getElementById("email").value;
    const password = document.getElementById("password").value;
  
    let emailError = "";
    let passwordError = "";
    let isValid = true;
  
    const emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
    if (!email) {
      emailError = "Email is required.";
      isValid = false;
    } else if (!emailRegex.test(email)) {
      emailError = "Invalid email format.";
      isValid = false;
    }
  
    const minPasswordLength = 8;
    if (!password) {
      passwordError = "Password is required.";
      isValid = false;
    } else if (password.length < minPasswordLength) {
      passwordError = `Password must be at least ${minPasswordLength} characters long.`;
      isValid = false;
    }
  
    document.getElementById("emailError").innerText = emailError;
    document.getElementById("passwordError").innerText = passwordError;
  
    if (isValid) {
      document.getElementById("status").innerText = "Login successful!";
    } else {
      document.getElementById("status").innerText = "";
    }
  }
  