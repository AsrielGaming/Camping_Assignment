<template>
  <div>
    <h1>Sign up here</h1>
    
    <!-- Main container -->
    <div class="main-container">
      
      <!-- Content container -->
      <div class="content">
        
        <!-- Username -->
        <div class="section">
          <p style="display:inline-block; margin-right: 10px;">Username:</p>
          <input type="text" v-model="username" placeholder="Enter your username here" />
          <!-- Information button with id -->
          <span class="info-button" id="info-username" data-info="Username must be unique and contain only letters, numbers, or underscores." @mouseover="showInfo">?</span>
        </div>

        <!-- Email -->
        <div class="section">
          <p style="display:inline-block; margin-right: 10px;">Email:</p>
          <input type="text" v-model="email" placeholder="Enter your email here" />
          <!-- Information button with id -->
          <span class="info-button" id="info-email" data-info="Email must be in the correct email address format." @mouseover="showInfo">?</span>
        </div>

        <!-- Password -->
        <div class="section">
          <p style="display:inline-block; margin-right: 10px;">Password:</p>
          <input type="password" v-model="password" placeholder="Enter your password" />
          <!-- Information button with id -->
          <span class="info-button" id="info-password" data-info="Password must contain at least 1 capital letter, 1 number, and be 8 characters in length." @mouseover="showInfo">?</span>
        </div>

        <!-- Re Password -->
        <div class="section">
          <p style="display:inline-block; margin-right: 10px;">Re Password:</p>
          <input type="password" v-model="rePassword" placeholder="Re-enter your password" />
          <!-- Information button with id -->
          <span class="info-button" id="info-repassword" data-info="Re-enter your password to confirm." @mouseover="showInfo">?</span>
        </div>

        <!-- Owner Checkbox -->
        <div class="section">
          <input type="checkbox" v-model="isOwner" />
          <p style="display:inline-block; margin-left: 10px;">I want to also list my own camping spot.</p>
        </div>

        <!-- Button -->
        <div class="section">
          <button @click="signup">Signup</button>
        </div>

      </div>
    </div>
    
    <!-- Temporary button -->
    <!--
    <button @click="changeActivePage('Login')">Simulate Signup</button>
    -->
    
  </div>
</template>

<script>
import axios from 'axios';

export default {
  name: "SignupPage",
  data() {
    return {
      //Initialize properties
      username: '',
      email: '',
      password: '',
      rePassword: '',
      users: [], //Userlist
      owners: [], //Ownerlist
      isOwner: false
    };
  },
  mounted() {
    this.loadUsersAndOwners(); // Load users and owners data when the page is loaded
  },
  methods: {
    changeActivePage(page) {
      this.$emit('signup-success');
      this.$emit('change-active-page', page);
    },
    async loadUsersAndOwners() {
      try {
        const usersResponse = await axios.get('http://localhost:5118/api/User'); // Fetch users data
        const ownersResponse = await axios.get('http://localhost:5118/api/Owner'); // Fetch owners data

        this.users = usersResponse.data; // Set users data
        this.owners = ownersResponse.data; // Set owners data
      } catch (error) {
        console.error("Error fetching users and owners:", error);
      }
    },
    //Check if all fields are filled in
    async signup() {
      if (!this.username || !this.email || !this.password || !this.rePassword) {
        alert("Please fill in all fields.");
        return;
      }
      //Check if email is in correct format
      if (!this.validateEmail(this.email)) {
        alert("Email is not in the correct format.");
        return;
      }
      //Check if password is in correct format
      if (!this.validatePassword(this.password)) {
        alert("Password must contain at least 1 capital letter, 1 number, and be 8 characters in length.");
        return;
      }
      //Check if passwords are the same
      if (this.password !== this.rePassword) {
        alert("Passwords do not match.");
        return;
      }

      try {
        // Try signup for owner
        if (this.isOwner) {
          const existingOwner = this.owners.find(owner => owner.ownerName === this.username || owner.email === this.email);
          if (existingOwner) {
            alert("An owner with the same username or email already exists.");
            return;
          }

          const newOwner = { ownerName: this.username, email: this.email, password: this.password, phoneNumber: '1234567890' };
          await axios.post('http://localhost:5118/api/Owner', newOwner); // Post new owner data
          alert("Owner created successfully.");
        } // Try signup for user
        else { 
          const existingUser = this.users.find(user => user.username === this.username || user.email === this.email);
          if (existingUser) {
            alert("A user with the same username or email already exists.");
            return;
          }

          const newUser = { username: this.username, email: this.email, password: this.password };
          await axios.post('http://localhost:5118/api/User', newUser); // Post new user data
          alert("User created successfully.");
        }
        this.changeActivePage('Login'); // Change active page to Login
      } catch (error) {
        console.error("Error creating user or owner:", error);
        alert("An error occurred during signup. Please try again.");
      }
    },
    validateEmail(email) {
      const emailPattern = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
      return emailPattern.test(email);
    },
    validatePassword(password) {
      const passwordPattern = /^(?=.*[A-Z])(?=.*\d).{8,}$/;
      return passwordPattern.test(password);
    },
    showInfo(event) {
      const infoText = event.target.getAttribute('data-info'); // Get info text from data-info attribute
      alert(infoText); // Show info alert
    }
  }
}
</script>

<style scoped>
/* Styling for main container */
.main-container {
  display: flex;
  flex-direction: column;
  justify-content: space-between;
}

/* Styling for content */
.content {
  border: 1px solid #ccc;
  padding: 10px;
  margin-top: 10px;
}

/* Styling for section */
.section {
  display: flex;
  align-items: center;
  margin-bottom: 10px;
}

/* Styling for textbox */
input[type="text"], input[type="password"] {
  width: 200px;
}

/* Styling for information button */
.info-button {
  margin-left: 5px;
  cursor: pointer;
  display: inline-block;
  width: 20px;
  height: 20px;
  border-radius: 50%;
  text-align: center;
  background-color: #ccc;
  color: #fff;
  line-height: 20px;
  position: relative;
}

/* Styling for circle around information button */
.info-button::before {
  content: "";
  display: inline-block;
  width: 20px;
  height: 20px;
  border-radius: 50%;
  position: absolute;
  left: -5px;
}

/* Styling for information button hover effect */
.info-button:hover::after {
  content: attr(data-info);
  position: absolute;
  background-color: #000;
  color: #fff;
  padding: 5px;
  border-radius: 5px;
  font-size: 12px;
  white-space: nowrap;
}
</style>