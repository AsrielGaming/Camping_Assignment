<template>
  <div id="app">
    <!-- Navigation -->
    <nav>
      <ul>
        <li v-for="(page, index) in filteredPages" :key="index" @click="changeActivePage(page)" :style="getActiveStyling(page)">
          {{ page }}
        </li>
      </ul>
    </nav>

    <!-- Logout button -->
    <button v-if="activePage !== 'Login' && activePage !== 'Sign Up'" @click="logout" style="position: absolute; top: 10px; right: 10px;">Logout</button>

    <!-- Pages -->
    <div>
      <LoginPage v-if="activePage === 'Login'" @login-success="handleLoginSuccess" />
      <SignUpPage v-if="activePage === 'Sign Up'" @signup-success="changeActivePage('Login')" />
      <HomePage v-if="activePage === 'Homepage'" :user-data="userData" :is-owner="isOwner" />
      <CampingSpotPage v-if="activePage === 'Camping spots'" />
      <AccountPage v-if="activePage === 'Account'" :user-data="userData" :is-owner="isOwner" />
      <ListingPage v-if="isOwner && activePage === 'Listings'" />
      <BookingPage v-if="!isOwner && activePage === 'Bookings'" />
    </div>
  </div>
</template>

<script>
// imports
import LoginPage from './Pages/LoginPage.vue';
import SignUpPage from './Pages/SignUpPage.vue';
import HomePage from './Pages/HomePage.vue';
import CampingSpotPage from './Pages/CampingSpotPage.vue';
import AccountPage from './Pages/AccountPage.vue';
import ListingPage from './Pages/ListingPage.vue';
import BookingPage from './Pages/BookingPage.vue';

export default {
  name: 'App',

  components: {
    LoginPage,
    SignUpPage,
    HomePage, 
    CampingSpotPage,
    AccountPage,
    ListingPage,
    BookingPage
  },

  data() {
    return {
      activePage: 'Login',
      userData: null, // To store user data upon successful login
      isOwner: false,  // Variable to indicate if the user is an owner
      ownerName: '', // Variable to store owner's name
      userName: '' // Variable to store regular user's name
    }
  },

  computed: {
    filteredPages() {
      // Filter pages based on isOwner variable
      if (this.isOwner) {
        return [
          "Login",
          "Sign Up",
          "Homepage",
          "Camping spots",
          "Listings",
          "Account"
        ];
      } else {
        return [
          "Login",
          "Sign Up",
          "Homepage",
          "Camping spots",
          "Bookings",
          "Account"
        ];
      }
    }
  },

  methods: {
    changeActivePage(page) {
      this.activePage = page;
    },
    
    getActiveStyling(page) {
      if (page === this.activePage) {
        return "text-decoration: underline; font-weight:bold; display: inline-block; margin-right: 10px;";
      } 
      else if ((this.activePage === 'Login' && (page !== 'Login' && page !== 'Sign Up')) ||
              (this.activePage === 'Sign Up' && (page !== 'Login' && page !== 'Sign Up'))) {
        // Disable other links when on login or signup page
        return "pointer-events: none; color: #ccc; display: none; margin-right: 10px;";
      }
      else if ((this.activePage !== 'Login' && this.activePage !== 'Sign Up') && (page === 'Login' || page === 'Sign Up')) {
        // Disable login and signup links when not on login or signup page
        return "pointer-events: none; color: #ccc; display: none; margin-right: 10px;";
      }

      return "display: inline-block; margin-right: 10px;";
    },

    handleLoginSuccess(userData) {
      console.log("Received userData:", userData);
      this.userData = userData;
      if (userData.isOwner) {
        this.isOwner = true;
        // Use OwnerName for owners
        this.ownerName = userData.OwnerName;
      } else {
        this.isOwner = false;
        // Use username for regular users
        this.userName = userData.username;
      }
      this.changeActivePage('Homepage');
    },

    logout() {
      // Clear user data and set active page to Login when logout button is clicked
      this.userData = null;
      this.isOwner = false; // Reset isOwner to false on logout
      this.activePage = 'Login';
    }
  }
}
</script>