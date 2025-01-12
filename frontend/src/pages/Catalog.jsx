import React, { useEffect, useState } from 'react';
import { useNavigate } from 'react-router-dom';
import { GetAllGenres } from '../services/genres_service';
import { GetAllAuthors } from '../services/author_service';
import { GetAllBooks } from '../services/books_service';
import Paginator from '../components/Paginator';

export default function Catalog() {
    const [books, setBooks] = useState([]);
    const [authors, setAuthors] = useState([]);
    const [genres, setGenres] = useState([]);
    const [error, setError] = useState(null);
    const [pageNo, setPageNo] = useState(1);
    const [totalPages, setTotalPages] = useState(1);
    const navigate = useNavigate();

    useEffect(() => {
        const fetchGenres = async () => {
            try {
                const data = await GetAllGenres();
                setGenres(data);
            } catch (err) {
                setError(err.message);
            }
        };

        const fetchAuthors = async () => {
            try {
                const data = await GetAllAuthors();
                setAuthors(data);
            } catch (err) {
                setError(err.message);
            }
        };

        const fetchBooks = async () => {
            try {
                const data = await GetAllBooks();
                setBooks(data.items);
            } catch (err) {
                setError(err.message);
            }
        };

        fetchGenres();
        fetchAuthors();
        fetchBooks();
    }, []);

    const handleBookClick = (bookId) => {
        navigate(`/bookPage/${bookId}`);
    };

    async function fetchBookList(pageNo = 1) {
            try {
                const data = await GetAllBooks(pageNo);
                setBooks(data.items);
                setPageNo(data.currentPage);
                setTotalPages(data.totalPages);
            } catch (err) {
                setError(err.message);
            }
        }

    if (error) {
        return <p>Error: {error}</p>;
    }

    return (
        <div>
            <h1>Books</h1>
            <ul>
                {books.map((book) => (
                    <li key={book.id} onClick={() => handleBookClick(book.id)} style={{ cursor: 'pointer' }}>
                        {book.title}
                    </li>
                ))}
            </ul>
            <Paginator pageNo={pageNo} totalPages={totalPages} onPageChange={fetchBookList} />
            <h1>Authors</h1>
            <ul>
                {authors.map((author) => (
                    <li key={author.id}>{author.firstName}</li>
                ))}
            </ul>
        </div>
    );
}