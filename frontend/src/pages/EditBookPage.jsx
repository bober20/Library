import React, { useEffect, useState } from 'react';
import { useParams, useNavigate } from 'react-router-dom';
import { GetBookById, UpdateBook } from '../services/books_service';
import { GetAllAuthors } from '../services/author_service';
import { GetAllGenres } from '../services/genres_service';

export default function EditBookPage() {
    const [book, setBook] = useState(null);
    const [authors, setAuthors] = useState([]);
    const [genres, setGenres] = useState([]);
    const [error, setError] = useState(null);
    const [success, setSuccess] = useState(null);
    const { bookId } = useParams();
    const navigate = useNavigate();

    useEffect(() => {
        const fetchBook = async () => {
            try {
                const data = await GetBookById(bookId);
                setBook(data);
            } catch (err) {
                setError(err.message);
            }
        };

        const fetchAuthorsAndGenres = async () => {
            try {
                const authorsData = await GetAllAuthors();
                const genresData = await GetAllGenres();
                setAuthors(authorsData);
                setGenres(genresData);
            } catch (err) {
                setError(err.message);
            }
        };

        fetchBook();
        fetchAuthorsAndGenres();
    }, [bookId]);

    const handleSubmit = async (e) => {
        e.preventDefault();
        try {
            await UpdateBook(bookId, book);
            setSuccess('Book updated successfully!');
            setTimeout(() => navigate(`/bookPage/${bookId}`), 2000);
        } catch (err) {
            setError(err.message);
        }
    };

    const handleChange = (e) => {
        const { name, value } = e.target;
        setBook((prevBook) => ({
            ...prevBook,
            [name]: value,
        }));
    };

    if (error) {
        return <p>Error: {error}</p>;
    }

    if (!book) {
        return <p>Loading...</p>;
    }

    return (
        <div>
            <h1>Edit Book</h1>
            <form onSubmit={handleSubmit}>
                <div>
                    <label htmlFor="title">Title:</label>
                    <input
                        type="text"
                        id="title"
                        name="title"
                        value={book.title}
                        onChange={handleChange}
                        required
                    />
                </div>
                <div>
                    <label htmlFor="authorId">Author:</label>
                    <select
                        id="authorId"
                        name="authorId"
                        value={book.authorId}
                        onChange={handleChange}
                        required
                    >
                        <option value="">Select Author</option>
                        {authors.map((author) => (
                            <option key={author.id} value={author.id}>
                                {author.firstName} {author.lastName}
                            </option>
                        ))}
                    </select>
                </div>
                <div>
                    <label htmlFor="genreId">Genre:</label>
                    <select
                        id="genreId"
                        name="genreId"
                        value={book.genreId}
                        onChange={handleChange}
                        required
                    >
                        <option value="">Select Genre</option>
                        {genres.map((genre) => (
                            <option key={genre.id} value={genre.id}>
                                {genre.name}
                            </option>
                        ))}
                    </select>
                </div>
                <div>
                    <label htmlFor="description">Description:</label>
                    <textarea
                        id="description"
                        name="description"
                        value={book.description}
                        onChange={handleChange}
                        required
                    />
                </div>
                <div>
                    <label htmlFor="borrowDate">Borrow Date:</label>
                    <input
                        type="date"
                        id="borrowDate"
                        name="borrowDate"
                        value={book.borrowDate.split('T')[0]}
                        onChange={handleChange}
                        required
                    />
                </div>
                <div>
                    <label htmlFor="dueDate">Due Date:</label>
                    <input
                        type="date"
                        id="dueDate"
                        name="dueDate"
                        value={book.dueDate.split('T')[0]}
                        onChange={handleChange}
                        required
                    />
                </div>
                <button type="submit">Update Book</button>
            </form>
            {error && <p style={{ color: 'red' }}>Error: {error}</p>}
            {success && <p style={{ color: 'green' }}>{success}</p>}
        </div>
    );
}