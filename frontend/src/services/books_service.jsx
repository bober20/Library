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

export const GetBookById = async (bookId) => {
    try {
        const response = await axios.get('http://localhost:5255/api/Book/getById/' + bookId);

        if (response.status === 200) {
            console.log(response.data.data);
            return response.data.data;
        } else {
            throw new Error(response.data.errorMessage);
        }
    } catch (error) {
        console.error("Error fetching book by id:", error);
        throw error;
    }
}

export const UpdateBook = async (bookId, book) => {
    try {
        const response = await axios.put('http://localhost:5255/api/Book/' + bookId, book);

        if (response.status === 200) {
            return response.data.data;
        } else {
            throw new Error(response.data.errorMessage);
        }
    } catch (error) {
        console.error("Error updating book:", error);
        throw error;
    }
}