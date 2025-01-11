import React, { useState, useEffect } from 'react';
import { AddBook } from '../services/books_service';
import { GetAllAuthors } from '../services/author_service';
import { GetAllGenres } from '../services/genres_service';

export default function AddBookForm() {
    const [isbn, setIsbn] = useState('');
    const [title, setTitle] = useState('');
    const [imageUrl, setImageUrl] = useState('');
    const [genreId, setGenreId] = useState('');
    const [authorId, setAuthorId] = useState('');
    const [description, setDescription] = useState('');
    const [borrowDate, setBorrowDate] = useState('');
    const [dueDate, setDueDate] = useState('');
    const [authors, setAuthors] = useState([]);
    const [genres, setGenres] = useState([]);
    const [error, setError] = useState(null);
    const [success, setSuccess] = useState(null);

    useEffect(() => {
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

        fetchAuthorsAndGenres();
    }, []);

    const handleSubmit = async (e) => {
        e.preventDefault();
        try {
            const newBook = {
                isbn,
                title,
                imageUrl,
                genreId,
                description,
                authorId,
                borrowDate: new Date(borrowDate).toISOString(),
                dueDate: new Date(dueDate).toISOString()
            };
            await AddBook(newBook);
            setSuccess('Book added successfully!');
            setIsbn('');
            setTitle('');
            setImageUrl('');
            setGenreId('');
            setAuthorId('');
            setDescription('');
            setBorrowDate('');
            setDueDate('');
        } catch (err) {
            setError(err.message);
        }
    };

    return (
        <div>
            <h2>Add New Book</h2>
            <form onSubmit={handleSubmit}>
                <div>
                    <label htmlFor="isbn">ISBN:</label>
                    <input
                        type="text"
                        id="isbn"
                        value={isbn}
                        onChange={(e) => setIsbn(e.target.value)}
                        required
                    />
                </div>
                <div>
                    <label htmlFor="title">Title:</label>
                    <input
                        type="text"
                        id="title"
                        value={title}
                        onChange={(e) => setTitle(e.target.value)}
                        required
                    />
                </div>
                <div>
                    <label htmlFor="imageUrl">Image URL:</label>
                    <input
                        type="text"
                        id="imageUrl"
                        value={imageUrl}
                        onChange={(e) => setImageUrl(e.target.value)}
                        required
                    />
                </div>
                <div>
                    <label htmlFor="genre">Genre:</label>
                    <select
                        id="genre"
                        value={genreId}
                        onChange={(e) => setGenreId(e.target.value)}
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
                    <label htmlFor="author">Author:</label>
                    <select
                        id="author"
                        value={authorId}
                        onChange={(e) => setAuthorId(e.target.value)}
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
                    <label htmlFor="description">Description:</label>
                    <textarea
                        id="description"
                        value={description}
                        onChange={(e) => setDescription(e.target.value)}
                        required
                    />
                </div>
                <div>
                    <label htmlFor="borrowDate">Borrow Date:</label>
                    <input
                        type="date"
                        id="borrowDate"
                        value={borrowDate}
                        onChange={(e) => setBorrowDate(e.target.value)}
                        required
                    />
                </div>
                <div>
                    <label htmlFor="dueDate">Due Date:</label>
                    <input
                        type="date"
                        id="dueDate"
                        value={dueDate}
                        onChange={(e) => setDueDate(e.target.value)}
                        required
                    />
                </div>
                <button type="submit">Add Book</button>
            </form>
            {error && <p style={{ color: 'red' }}>Error: {error}</p>}
            {success && <p style={{ color: 'green' }}>{success}</p>}
        </div>
    );
}