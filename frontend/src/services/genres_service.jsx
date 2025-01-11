import axios from 'axios';

export const GetAllGenres = async () => {
    try {
        const response = await axios.get('http://localhost:5255/api/Genre');
        if (response.status === 200) {
            return response.data.data;
        } else {
            throw new Error(response.data.errorMessage);
        }
    } catch (error) {
        console.error("Error fetching all genres:", error);
        throw error;
    }
}

export const AddGenre = async (genre) => {
    
        const response = await axios.post('http://localhost:5255/api/Genre', genre);
        if (response.status === 200) {
            return response.data.data;
        } else {
            throw new Error(response.data.errorMessage);
        }
    
}