import axios from 'axios';

export const AddBook = async (book) => {
    try {
        const response = await axios.post('http://localhost:5255/api/Book', book);
    
        if (response.status === 200) {
            return response.data.data;
        } else {
            throw new Error(response.data.errorMessage);
        }
    } catch (error) {
        console.error("Error adding book:", error);
        throw error;
    }
}

export const GetAllBooks = async (pageNo = 1) => {
    try {
        const response = await axios.get('http://localhost:5255/api/Book/' + pageNo);

        if (response.status === 200) {
            return response.data.data;
        } else {
            throw new Error(response.data.errorMessage);
        }
    } catch (error) {
        console.error("Error fetching all books:", error);
        throw error;
    }
}