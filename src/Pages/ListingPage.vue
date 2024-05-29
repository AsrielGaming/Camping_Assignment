<template>
  <div>
    <!-- Main container -->
    <div class="main-container">
      
      <!-- Banner container -->
      <div class="banner">
        <h3>Your listings</h3>
      </div>
      
      <!-- Content container -->
      <div class="content">
        <!-- Listing container -->
        <div class="listing-container">
          <div v-if="filteredCampingSpots.length">
            <div v-for="spot in filteredCampingSpots" :key="spot.id" class="camping-spot-container">
              <!-- Left side for spot details -->
              <div class="spot-details">
                <div class="camping-spot">
                  <h3>{{ spot.spotName }}</h3>
                  <p>Description: {{ spot.description }}</p>
                  <p>Size: {{ spot.size }} m²</p>
                  <p>Price: {{ spot.price }} euro</p>
                  <p>Availability: {{ spot.isAvailable ? 'Available' : 'Not Available' }}</p>
                </div>
              </div>
            </div>
          </div>
          <div v-else>
            <p>No available camping spots.</p>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
// Import the Axios function
import { fetchCampingSpots } from '../Root/Axios.js';

export default {
  name: "ListingPage",
  props: {
    userData: {
      type: Object,
      required: true
    }
  },
  data() {
    return {
      campingSpots: [], // Array to store all camping spots
      filteredCampingSpots: [] // Array to store filtered camping spots
    };
  },
  mounted() {
    this.loadCampingSpots(); // Load camping spots when the page is loaded
  },
  methods: {
    async loadCampingSpots() {
      try {
        // Fetch camping spots
        this.campingSpots = await fetchCampingSpots();

        // Debug output for user data id
        //console.log('UserDataId:', this.userData.id);

        // Filter camping spots by ownerId
        this.filteredCampingSpots = this.campingSpots.filter(spot => {
          // Debug output for each camping spot owner id
          //console.log('ListingOwnerId:', spot.ownerId);
          return spot.ownerId === this.userData.id;
        });
      } catch (error) {
        console.error("Error fetching camping spots:", error);
      }
    }
  }
};
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
  display: flex;
  border: 1px solid #ccc;
  padding: 10px;
}

/* Styling for listing container */
.listing-container {
  width: 100%;
  padding: 10px;
}

/* Styling for individual camping spot container */
.camping-spot-container {
  border: 1px solid #ccc;
  margin-bottom: 10px;
  padding: 10px;
  display: flex;
}

/* Styling for spot details */
.spot-details {
  flex: 1;
}
</style>