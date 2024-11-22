// State by City select
const stateCities = {
  kerala: ["Thiruvananthapuram", "Kochi", "Kozhikode", "Thrissur"],
  tamilnadu: ["Chennai", "Salem", "Coimbatore", "Madurai"],
  karnataka: ["Bengaluru", "Mysuru", "Mangalore", "Hubli"],
  maharashtra: ["Mumbai", "Pune", "Nagpur", "Nashik"],
};

function updateCities() {
  const state = document.getElementById("state").value;
  const citySelect = document.getElementById("city");

  citySelect.innerHTML = '<option value="">Select a city</option>';

  if (state && stateCities[state]) {
    stateCities[state].forEach((city) => {
      const option = document.createElement("option");
      option.value = city.toLowerCase();
      option.textContent = city;
      citySelect.appendChild(option);
    });
  }
}

// Register Form Validation

function validateForm() {
  let isValid = true;

  const errorFields = document.querySelectorAll(".error");
  errorFields.forEach((field) => (field.innerText = ""));

  // Input field values
  const fname = document.getElementById("fname").value.trim();
  const lname = document.getElementById("lname").value.trim();
  const dob = document.getElementById("dob").value.trim();
  const age = document.getElementById("age").value.trim();
  const male = document.getElementById("male").checked;
  const female = document.getElementById("female").checked;
  const phonenumber = document.getElementById("phonenumber").value.trim();
  const email = document.getElementById("email").value.trim();
  const state = document.getElementById("state").value;
  const city = document.getElementById("city").value;
  const username = document.getElementById("username").value.trim();
  const pwd = document.getElementById("pwd").value;
  const cpwd = document.getElementById("cpwd").value;

  // Validate each field 
  if (fname === "") {
    document.getElementById("fname-err").innerText ="First Name is required.";
    isValid = false;
  }

  if (!lname) {
    document.getElementById("lname-err").innerText = "Last name is required.";
    isValid = false;
  }

  if (!dob) {
    document.getElementById("dob-err").innerText = "Date of birth is required.";
    isValid = false;
  }

  //issue have
  if (age <= 18) {
    document.getElementById("dob-err").innerText = "Enter a valid age (18+).";
    isValid = false;
  }

  if (!male && !female) {
    document.getElementById("gender-err").innerText = "Gender must be selected.";
    isValid = false;
  }

  const phoneRegex = /^[6-9]\d{9}$/;
  if (!phonenumber) {
    document.getElementById("phonenumber-err").innerText =
      "Phone number is required.";
    isValid = false;
  } else if (!phoneRegex.test(phonenumber)) {
    document.getElementById("phonenumber").innerText =
      "Enter a valid 10-digit phone number.";
    isValid = false;
  }

  const emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
  if (!email) {
    document.getElementById("email-err").innerText = "Email is required.";
    isValid = false;
  } else if (!emailRegex.test(email)) {
    document.getElementById("email-err").innerText = "Enter a valid email address.";
    isValid = false;
  }

  if (!state) {
    document.getElementById("state-err").innerText = "State must be selected.";
    isValid = false;
  }

  if (!city) {
    document.getElementById("city-err").innerText = "City must be selected.";
    isValid = false;
  }

  if (!username) {
    document.getElementById("username-err").innerText = "Username is required.";
    isValid = false;
  }

  if (!pwd) {
    document.getElementById("passwordError").innerText =
      "Password is required.";
    isValid = false;
  } else if (pwd !== cpwd) {
    document.getElementById("passwordError").innerText =
      "Passwords do not match.";
    isValid = false;
  }

  // Display status
  if (isValid) {
    document.getElementById("status").innerText = "Registration successful!";
  } else {
    document.getElementById("status").innerText =
      "Please fill out all required fields.";
  }

  return isValid;
}

const dobInput = document.getElementById('dob');
const ageInput = document.getElementById('age');
const errorDisplay = document.getElementById('dob-err');

dobInput.addEventListener('input', () => {
  const dob = new Date(dobInput.value);
  const today = new Date();

  // entered data is valid or not
  if (isNaN(dob.getTime())) {
      errorDisplay.textContent = "Please enter a valid date.";
      ageInput.value = '';
      return;
  }
  if (dob > today) {
      errorDisplay.textContent = "Date of birth cannot be in the future.";
      ageInput.value = '';
      return;
  }

  errorDisplay.textContent = ''; 

  // Calculate age
  let age = today.getFullYear() - dob.getFullYear();
  const monthDiff = today.getMonth() - dob.getMonth();
  const dayDiff = today.getDate() - dob.getDate();

  if (monthDiff < 0 || (monthDiff === 0 && dayDiff < 0)) {
      age--; 
  }

  if (age <= 18) {
    document.getElementById("dob-err").innerText = "Enter a valid age (18+).";
    isValid = false;
  }

  ageInput.value = age;
  ageInput.disabled = true;
});


document
  .querySelector("button[type='button']")
  .addEventListener("click", function () {
    validateForm();
  });
