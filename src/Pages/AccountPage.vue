<template>
  <div>
    
    <!-- Main container -->
    <div class="main-container">
      
      <!-- Banner container -->
      <div class="banner">
        <h3>{{ userData.username }}</h3>
      </div>
      
      <!-- Content container -->
      <div class="content">
        
        <!-- Username -->
        <div class="section">
          <p style="display:inline-block; margin-right: 10px;">Username:</p>
          <p>{{ userData.username }}</p>
          <button @click="updateUsernamePopup">Update</button>
        </div>

        <!-- Email -->
        <div class="section">
          <p style="display:inline-block; margin-right: 10px;">Email:</p>
          <p>{{ userData.email }}</p>
          <button @click="updateEmailPopup">Update</button>
        </div>

        <!-- Password -->
        <div class="section">
          <p style="display:inline-block; margin-right: 10px;">Password:</p>
          <p>{{ maskedPassword }}</p>
          <button @click="updatePasswordPopup">Update</button>
        </div>

        <!-- Button -->
        <div class="section">
          <button @click="deleteAccount">Delete my account</button>
        </div>

      </div>
    </div>
    
  </div>
</template>

<script>
import axios from 'axios';

export default {
  name: "AccountPage",
  props: {
    userData: {
      type: Object,
      default: null
    }
  },
  computed: {
    maskedPassword() {
      // Masks the password except for the first and last characters
      if (this.userData && this.userData.password) {
        const password = this.userData.password;
        const length = password.length;
        const masked = password.charAt(0) + '*'.repeat(length - 2) + password.charAt(length - 1);
        return masked;
      }
      return '';
    }
  },
  methods: {
    updateUsernamePopup() {
      // Prompts user to enter a new username and calls updateUsername method if input is valid
      const newUsername = prompt("Enter new username:");
      if (newUsername) {
        this.updateUsername(newUsername);
      }
    },

    updateEmailPopup() {
      // Prompts user to enter a new email, validates the email, and calls updateEmail method if input is valid
      const newEmail = prompt("Enter new email:");
      if (newEmail) {
        if (!this.validateEmail(newEmail)) {
          alert("Email is not in the correct format.");
          return;
        }
        this.updateEmail(newEmail);
      }
    },

    updatePasswordPopup() {
      // Prompts user to enter a new password, validates the password, and calls updatePassword method if input is valid
      const newPassword = prompt("Enter new password:");
      if (newPassword) {
        if (!this.validatePassword(newPassword)) {
          alert("Password must contain at least 1 capital letter, 1 number, and be 8 characters in length.");
          return;
        }
        this.updatePassword(newPassword);
      }
    },

    async updateUsername(newUsername) {
      // Sends a PUT request to update the username
      try {
        await axios.put(`http://localhost:5118/api/User/${this.userData.id}/username`, null, {
          params: { newUsername }
        });
        alert("Username updated successfully.");
      } catch (error) {
        console.error("Error updating username:", error);
        alert("An error occurred while updating username. Please try again.");
      }
    },

    async updateEmail(newEmail) {
      // Sends a PUT request to update the email
      try {
        await axios.put(`http://localhost:5118/api/User/${this.userData.id}/email`, null, {
          params: { newEmail }
        });
        alert("Email updated successfully.");
      } catch (error) {
        console.error("Error updating email:", error);
        alert("An error occurred while updating email. Please try again.");
      }
    },

    async updatePassword(newPassword) {
      // Sends a PUT request to update the password
      try {
        await axios.put(`http://localhost:5118/api/User/${this.userData.id}/password`, null, {
          params: { newPassword }
        });
        alert("Password updated successfully.");
      } catch (error) {
        console.error("Error updating password:", error);
        alert("An error occurred while updating password. Please try again.");
      }
    },

    async deleteAccount() {
      // Sends a DELETE request to delete the user's account
      try {
        const response = await axios.delete(`http://localhost:5118/api/User/${this.userData.id}`);
        // Emit event to trigger logout
        this.$emit('logout');
        alert(response.data);
      } catch (error) {
        console.error("Error deleting account:", error);
        alert("An error occurred while deleting the account. Please try again.");
      }
    },

    validateEmail(email) {
      // Validates the email format using a regular expression
      const emailPattern = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
      return emailPattern.test(email);
    },

    validatePassword(password) {
      // Validates the password format using a regular expression
      const passwordPattern = /^(?=.*[A-Z])(?=.*\d).{8,}$/;
      return passwordPattern.test(password);
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

/* Styling for banner container */
.banner {
  border: 1px solid #ccc;
  padding: 10px;
  margin-bottom: 10px;
  background-color: #f9f9f9;
}

/* Styling for content container */
.content {
  border: 1px solid #ccc;
  padding: 10px;
}

/* Styling for section */
.section {
  display: flex;
  align-items: center;
  margin-bottom: 10px;
}

/* Styling for textbox */
input[type="text"] {
  width: 200px;
  margin-right: 10px;
}

/* Styling for button */
button {
  margin-left: 10px;
}
</style>