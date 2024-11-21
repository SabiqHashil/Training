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

function validateForm() {
  let isValid = true;

  const errorFields = document.querySelectorAll(".error");
  errorFields.forEach((field) => (field.innerText = ""));

  const fname = document.getElementById("fname").value.trim();
  const lname = document.getElementById("lname").value.trim();
  const dob = document.getElementById("dob").value.trim();
  const age = document.getElementById("age").value.trim();
  const male = document.getElementById("male").checked;
  const female = document.getElementById("female").checked;
  const phonenumber = document.getElementById("phonenumber").value.trim();
  const email = document.getElementById("email").value.trim();
  const address = document.getElementById("address").value.trim();
  const state = document.getElementById("state").value;
  const city = document.getElementById("city").value;
  const username = document.getElementById("username").value.trim();
  const pwd = document.getElementById("pwd").value;
  const cpwd = document.getElementById("cpwd").value;

  if (!fname) {
      document.getElementById("fname").innerText = "First name is required.";
      isValid = false;
  }

  if (!lname) {
      document.getElementById("lname").innerText = "Last name is required.";
      isValid = false;
  }

  if (!dob) {
      document.getElementById("dob").innerText = "Date of birth is required.";
      isValid = false;
  }

  if (!age || age <= 18) {
      document.getElementById("age").innerText = "Enter a valid age.";
      isValid = false;
  }

  if (!male && !female) {
      document.getElementById("gender").innerText = "Gender must be selected.";
      isValid = false;
  }

  const phoneRegex = /^[6-9]\d{9}$/;
  if (!phonenumber) {
      document.getElementById("phonenumber").innerText = "Phone number is required.";
      isValid = false;
  } else if (!phoneRegex.test(phonenumber)) {
      document.getElementById("phonenumber").innerText = "Enter a valid 10-digit phone number.";
      isValid = false;
  }

  const emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
  if (!email) {
      document.getElementById("email").innerText = "Email is required.";
      isValid = false;
  } else if (!emailRegex.test(email)) {
      document.getElementById("email").innerText = "Enter a valid email address.";
      isValid = false;
  }

  if (!address) {
      document.getElementById("address").innerText = "Address is required.";
      isValid = false;
  }

  if (!state) {
      document.getElementById("state").innerText = "State must be selected.";
      isValid = false;
  }

  if (!city) {
      document.getElementById("city").innerText = "City must be selected.";
      isValid = false;
  }

  if (!username) {
      document.getElementById("username").innerText = "Username is required.";
      isValid = false;
  }

  if (!pwd) {
      document.getElementById("passwordError").innerText = "Password is required.";
      isValid = false;
  } else if (pwd !== cpwd) {
      document.getElementById("passwordError").innerText = "Passwords do not match.";
      isValid = false;
  }

  if (isValid) {
      document.getElementById("status").innerText = "Registration successful!";
  } else {
      document.getElementById("status").innerText = "Please fix the errors above.";
  }

  return isValid;
}

document.querySelector("button[type='button']").addEventListener("click", function () {
  validateForm();
});

