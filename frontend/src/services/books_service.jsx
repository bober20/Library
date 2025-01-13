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
        } else if (!response.data.successful) {
            throw new Error(response.data.errorMessage);
        } else {
            throw new Error("Error fetching all books");
        }
    } catch (error) {
        console.error( error);
        throw error;
    }
}

export const GetBookById = async (bookId) => {
    try {
        const response = await axios.get('http://localhost:5255/api/Book/getById/' + bookId);

        if (response.status === 200) {
            return response.data.data;
        } else if (!response.data.successful) {
            throw new Error(response.data.errorMessage);
        } else {
            throw new Error("Error fetching book by id");
        }
    } catch (error) {
        console.error(error);
        throw error;
    }
}

export const UpdateBook = async (bookId, book) => {
    try {
        const response = await axios.put('http://localhost:5255/api/Book/' + bookId, book);

        if (response.status === 200) {
            return response.data.data;
        } else if (!response.data.successful) {
            throw new Error(response.data.errorMessage);
        } else {
            throw new Error("Error updating book");
        }
    } catch (error) {
        console.error(error);
        throw error;
    }
}

export const DeleteBook = async (bookId) => {
    try {
        const response = await axios.delete('http://localhost:5255/api/Book/' + bookId);

        if (response.status === 200) {
            return response.data.data;
        } else if (!response.data.successful) {
            throw new Error(response.data.errorMessage);
        } else {
            throw new Error("Error deleting book");
        }
    } catch (error) {
        console.error(error);
        throw error;
    }
}

export const GetBooksByGenre = async (genreId, pageNo = 1) => {
    try {
        console.log(`http://localhost:5255/api/Book/getByGenre/${genreId}/${pageNo}`);
        const response = await axios.get(`http://localhost:5255/api/Book/getByGenre/${genreId}/${pageNo}`);
        if (response.status === 200) {
            return response.data.data;
        } else if (!response.data.successful) {
            throw new Error(response.data.errorMessage);
        } else {
            throw new Error("Error fetching books by genre");
        }
    } catch (error) {
        console.error(error);
        throw error;
    }
};

export const GetBooksByAuthor = async (authorId, pageNo = 1) => {
    try {
        console.log(`http://localhost:5255/api/Book/getByAuthor/${authorId}/${pageNo}`);
        const response = await axios.get(`http://localhost:5255/api/Book/getByAuthor/${authorId}/${pageNo}`);
        
        if (response.status === 200) {
            return response.data.data;
        } else if (!response.data.successful) {
            console.log("aaaaaaaa");
            throw new Error(response.data.errorMessage);
        } else {
            console.log("bbbbbbbb");
            throw new Error("Error fetching books by author");
        }
    } catch(error) {
        console.error(error);
        throw error;
    }
}