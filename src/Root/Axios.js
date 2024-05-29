import axios from 'axios';

// Function to fetch camping spots data
export const fetchCampingSpots = async () => {
    try {
        const response = await axios.get('http://localhost:5118/api/CampingSpot'); // Send GET request to fetch camping spots
        return response.data; // Return data from the response
    } catch (error) {
        console.error('Error fetching camping spots:', error); // Log error if fetching fails
        throw error; // Throw error to handle it in the calling code
    }
};

// Function to fetch amenities data
export const fetchAmenities = async () => {
    try {
        const response = await axios.get('http://localhost:5118/api/Amenity'); // Send GET request to fetch amenities
        return response.data; // Return data from the response
    } catch (error) {
        console.error('Error fetching amenities:', error); // Log error if fetching fails
        throw error; // Throw error to handle it in the calling code
    }
};

// Function to fetch camp types data
export const fetchCampTypes = async () => {
    try {
        const response = await axios.get('http://localhost:5118/api/CampType'); // Send GET request to fetch camp types
        return response.data; // Return data from the response
    } catch (error) {
        console.error('Error fetching camp types:', error); // Log error if fetching fails
        throw error; // Throw error to handle it in the calling code
    }
};