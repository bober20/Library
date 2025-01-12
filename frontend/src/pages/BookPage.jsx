import React, { useEffect, useState } from 'react';
import { useParams } from 'react-router-dom';
import { GetBookById } from '../services/books_service';

export default function BookPage() {
    const [book, setBook] = useState(null);
    const [error, setError] = useState(null);
    const { bookId } = useParams();

    useEffect(() => {
        const fetchBook = async () => {
            try {
                const data = await GetBookById(bookId);
                setBook(data);
            } catch (err) {
                setError(err.message);
            }
        };

        fetchBook();
    }, [bookId]);

    if (error) {
        return <p>Error: {error}</p>;
    }

    if (!book) {
        return <p>Loading...</p>;
    }

    return (
        <div>
            <h1>Book</h1>
            <ul>
                <li>Title: {book.title}</li>
                <li>Author ID: {book.authorId}</li>
                <li>Genre ID: {book.genreId}</li>
            </ul>
        </div>
    );
}