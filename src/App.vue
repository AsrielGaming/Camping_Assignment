<template>
  <div id="app">
    <!-- Navigation -->
    <nav>
      <ul>
        <!--
        <li @click="changeActivePage('home')">
          Home
        </li>

        <li @click="changeActivePage('artist')">
          Artist
        </li>

        <li @click="changeActivePage('voting')">
          Voting
        </li>
        -->

        <!-- Dynamische werkwijze -->
        <li 
        v-for = " (page, index) in pages" 
        :key = "index"
        @click = "changeActivePage(page)"
        :style="getActiveStyling(page)">
          {{ page }}
        </li>

      </ul>
    </nav>

    <!-- Pages -->
    <!--{{ activePage }} hebben we nu niet meer nodig maar moet er in het begin wel staan-->
    <HomePage v-if = "activePage == 'home'"/>

    <CampingSpotPage v-if = "activePage == 'camping'"/>
    
    <BookingPage v-if = "activePage == 'booking'"/>

    <AccountPage v-if = "activePage == 'account'"/>

  </div>
</template>

<script>
// imports
import HomePage from './Pages/HomePage.vue';
import CampingSpotPage from './Pages/CampingSpotPage.vue';
import BookingPage from './Pages/BookingPage.vue';
import AccountPage from './Pages/AccountPage.vue';

export default {
  name: 'App',

  components: {
    HomePage, 
    CampingSpotPage,
    BookingPage,
    AccountPage
  },

  data() {
    return {
      activePage: "home",
      pages: [
        "home",
        "camping",
        "booking",
        "account"
      ]
    }
  },

  methods: {
    changeActivePage(page) {
      this.activePage = page;
    },
    getActiveStyling(page) {
      if (page == this.activePage) {
        return "text-decoration: underline; font-weight:bold";
      }

      return "";
    }
  }

}
</script>
