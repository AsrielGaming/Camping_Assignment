<template>
  <div>
    <!-- Main container -->
    <div class="main-container">
      <!-- Banner container -->
      <div class="banner">
        <h3>Welcome to Wandercamp{{ userData ? ', ' + (isOwner ? userData.OwnerName : userData.username) + '!' : '!' }}</h3>
      </div>

      <!-- Content container -->
      <div class="content">
        <!-- Text container -->
        <div class="text-container">
          <!-- about us -->
          <h3>About us</h3>
          <p>Welcome to Wandercamp, where adventure meets comfort. What started as a website has grown into a full company with over a dozen employees. <br> <br>"Not all who wander are lost" - This quote, which has become our slogan, perfectly captures the essence of our mission. We believe in the spirit of exploration and the joy of discovering new places, all while feeling at home in the wilderness.</p>

          <h3>Our Services</h3>
          <p>At Wandercamp, we provide a diverse range of camping options to suit every adventurer's needs. Whether you're looking for a cozy tent under the stars, a rustic cabin by the lake, or a luxurious glamping experience, we've got you covered. Our platform makes it easy to search, compare, and book the perfect spot for your next getaway.</p>

          <h3>List Your Own Camping Spot</h3>
          <p>Just like Airbnb allows homeowners to share their homes, Wandercamp empowers you to list your own camping spot. If you have a piece of land that you think others would enjoy, you can easily create a listing, set your own rates, and welcome fellow nature lovers to your space. It's a great way to share the beauty of your surroundings and earn some extra income.</p>

          <h3>Respect your fellow campers and nature</h3>
          <p>We here at Wandercamp care greatly for mother nature and therefore ask that you keep camping spots clean during and at the end of your stay. Be sure to keep in mind your surroundings and neighbours at all times and to be respectful towards others. We have a zero tolerance policy on any disrespectful behaviour like littering or noise complaints.</p>
        </div>

        <!-- Image container -->
        <div class="image-container">
          <img src="@/assets/CampingSpotPic.jpg" alt="Camping Image" class="camping-image"/>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: "HomePage",
  props: {
    //Userdata property
    userData: {
      type: Object,
      default: null
    },
    //IsOwner property
    isOwner: {
      type: Boolean,
      default: false
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
  display: flex;
  border: 1px solid #ccc;
  padding: 10px;
}

/* Styling for text container */
.text-container {
  width: 60%;
  padding-right: 10px;
}

/* Styling for image container */
.image-container {
  width: 40%;
  display: flex;
  justify-content: center;
  align-items: center;
}

.image-container img {
  max-width: 100%;
  height: auto;
  border-radius: 5px;
}

.camping-image {
  max-width: 300px; 
  max-height: 500px;
  height: auto; 
}
</style>