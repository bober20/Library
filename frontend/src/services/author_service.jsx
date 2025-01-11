import axios from 'axios';


export const GetAllAuthors = async () => {
    try {
        const response = await axios.get('http://localhost:5255/api/Author');
        if (response.status === 200) {
            return response.data.data;
        } else {
            throw new Error(response.data.errorMessage);
        }
    } catch (error) {
        console.error("Error fetching all authors:", error);
        throw error;
    }
}

export const AddAuthor = async (author) => {
    try {
        const response = await axios.post('http://localhost:5255/api/Author', author);

        if (response.status === 200) {
            return response.data.data;
        } else {
            throw new Error(response.data.errorMessage);
        }
    } catch (error) {
        console.error("Error adding author:", error);
        throw error;
    }
}