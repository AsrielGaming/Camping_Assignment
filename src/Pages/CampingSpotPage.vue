<template>
  <div>
    <!-- Main container -->
    <div class="main-container">
      
      <!-- Banner container -->
      <div class="banner">
        <h3>All camping spots</h3>
      </div>

      <!-- Filter container -->
      <div class="filter-container">
        <button @click="filterAll">All</button>
        <button @click="filterAvailable">Available</button>
        <button @click="filterAmenities">Amenities</button>
        <button @click="filterSmall">Small (≤ 50 m²)</button>
        <button @click="filterMedium">Medium (51-100 m²)</button>
        <button @click="filterLarge">Large (> 100 m²)</button>
        <button @click="filterCheap">Cheap (≤ 50 €)</button>
        <button @click="filterNormal">Normal (51-100 €)</button>
        <button @click="filterLuxury">Luxury (> 100 €)</button>
      </div>
      
      <!-- Content container -->
      <div class="content">
        <!-- Campingspots container -->
        <div class="campingspots-container">
          <div v-if="filteredCampingSpots.length">
            <div v-for="spot in filteredCampingSpots" :key="spot.id" class="camping-spot-container">
              <!-- Left side for spot details -->
              <div class="spot-details">
                <div class="camping-spot">
                  <h3>{{ spot.spotName }}</h3>
                  <!--<p>Camptype: {{ spot.campType }}</p>-->
                  <p>Description: {{ spot.description }}</p>
                  <p>Size: {{ spot.size }} m²</p>
                  <p>Price: {{ spot.price }} euro</p>
                  <p>Availability: {{ spot.isAvailable ? 'Available' : 'Not Available' }}</p>
                </div>
              </div>
              
              <!-- Middle section for booking -->
              <div class="booking-section">
                <h3>Book this spot</h3>
                <div class="date-picker-section">
                  <div class="date-picker-item">
                    <p>Date:</p>
                    <input type="date" v-model="spot.startingDate">
                  </div>
                  <div class="time-inputs">
                    <div class="time-input">
                      <label for="start-time">Start Time:</label>
                      <input type="time" id="start-time" v-model="spot.startTime">
                    </div>
                    <div class="time-input">
                      <label for="end-time">End Time:</label>
                      <input type="time" id="end-time" v-model="spot.endTime">
                    </div>
                  </div>
                </div>
                <!-- Book button -->
                <button @click="bookSpot(spot)">Book</button>
              </div>

              <!-- Right side for amenities -->
              <div class="amenities-section">
                <h3>Amenities</h3>
                <ul>
                  <li v-for="amenity in spot.amenities" :key="amenity.id">{{ amenity.name }}</li>
                </ul>
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
// Import the Axios functions
import { fetchCampingSpots, fetchAmenities, postBooking } from '../Root/Axios.js';

export default {
  name: "CampingspotsPage",
  data() {
    return {
      campingSpots: [], // Array to store all camping spots
      amenities: [], // Array to store all amenities
      filteredCampingSpots: [], // Array to store filtered camping spots
      userData: {} // Object to store user data
    };
  },
  mounted() {
    this.loadData(); // Load camping spots when the page is loaded
    this.loadAmenities(); // Load amenities when the page is loaded
  },
  methods: {
    async loadData() {
      try {
        // Fetch camping spots
        this.campingSpots = await fetchCampingSpots();
        this.filteredCampingSpots = [...this.campingSpots]; // Initially set filtered spots to all spots

        // Map amenityIds to their corresponding names
        this.filteredCampingSpots.forEach(spot => {
          if (spot.amenityIds && Array.isArray(spot.amenityIds)) {
            spot.amenities = spot.amenityIds.map(amenityId => this.amenities.find(amenity => amenity.id === amenityId));
          } else {
            spot.amenities = [];
          }
        });

        // Debug output no longer needed
        //console.log("Camping spots:", this.campingSpots);
        //console.log("Filtered camping spots:", this.filteredCampingSpots);
      } catch (error) {
        console.error("Error fetching data:", error);
      }
    },
    async loadAmenities() {
      try {
        // Fetch amenities
        this.amenities = await fetchAmenities();

        // Debug output no longer needed
        //console.log("Amenities:", this.amenities);
      } catch (error) {
        console.error("Error fetching amenities:", error);
      }
    },
    async bookSpot(spot) {
      // Validate booking date and time
      const currentDate = new Date();
      const selectedDate = new Date(spot.startingDate);
      const selectedStartTime = new Date(`1970-01-01T${spot.startTime}`);
      const selectedEndTime = new Date(`1970-01-01T${spot.endTime}`);

      if (selectedDate < currentDate || selectedStartTime >= selectedEndTime) {
        alert("Please select a valid date and time range.");
        return;
      }

      // Debug output no longer needed
      //console.log("Current date:", currentDate);
      //console.log("Selected date:", selectedDate);
      //console.log("Selected start time:", selectedStartTime);
      //console.log("Selected end time:", selectedEndTime);

      // Create booking data
      const bookingData = {
        userId: this.userData.id,
        spotId: spot.id,
        bookingDate: currentDate,
        checkInDate: selectedDate,
        checkOutDate: selectedDate,
        totalPrice: spot.price
      };

      // Debug output no longer needed
      //console.log("Booking data:", bookingData);

      // Send booking request
      try {
        await postBooking(bookingData);
        alert("Booking successful!");
      } catch (error) {
        console.error("Error booking spot:", error);
        alert("Booking failed. Please try again later.");
      }
    },
    // Show all camping spots
    filterAll() {
      this.filteredCampingSpots = [...this.campingSpots];
    },
    // Show only available spots
    filterAvailable() {
      this.filteredCampingSpots = this.campingSpots.filter(spot => spot.isAvailable);
    },
    // Show spots with amenities
    filterAmenities() {
      this.filteredCampingSpots = this.campingSpots.filter(spot => spot.amenities && spot.amenities.length > 0);
    },
    // Show small spots
    filterSmall() {
      this.filteredCampingSpots = this.campingSpots.filter(spot => spot.size <= 50);
    },
    // Show medium spots
    filterMedium() {
      this.filteredCampingSpots = this.campingSpots.filter(spot => spot.size > 50 && spot.size <= 100);
    },
    // Show large spots
    filterLarge() {
      this.filteredCampingSpots = this.campingSpots.filter(spot => spot.size > 100);
    },
    // Show cheap spots
    filterCheap() {
      this.filteredCampingSpots = this.campingSpots.filter(spot => spot.price <= 50);
    },
    // Show normal-priced spots
    filterNormal() {
      this.filteredCampingSpots = this.campingSpots.filter(spot => spot.price > 50 && spot.price <= 100);
    },
    // Show luxury spots
    filterLuxury() {
      this.filteredCampingSpots = this.campingSpots.filter(spot => spot.price > 100);
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

/* Styling for filter container */
.filter-container {
  display: flex;
  justify-content: center;
  margin-bottom: 10px;
  border: 1px solid #ccc;
  padding: 10px;
}

.filter-container button {
  margin-right: 10px;
}

/* Styling for content container */
.content {
  display: flex;
  border: 1px solid #ccc;
  padding: 10px;
}

/* Styling for campingspots container */
.campingspots-container {
  width: 100%;
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
  flex: 1; /* Take up remaining space */
}

/* Styling for booking section */
.booking-section {
  flex: 1;
  padding-left: 10px;
}

/* Styling for amenities section */
.amenities-section {
  flex: 0.3;
  padding-left: 10px;
}

/* Styling for date picker section */
.date-picker-section {
  display: flex;
  flex-direction: column;
}

/* Styling for date picker item */
.date-picker-item {
  display: flex;
  align-items: center;
  margin-bottom: 5px;
}

/* Styling for time inputs */
.time-inputs {
  display: flex;
  flex-direction: column;
}

/* Styling for time input */
.time-input {
  margin-bottom: 5px;
}

/* Styling for date picker and time input elements */
.date-picker-item input[type="date"],
.time-input input[type="time"] {
  margin-left: 10px;
}
</style>