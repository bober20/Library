import React, { useEffect, useState } from 'react';
import { useNavigate } from 'react-router-dom';
import { GetAllGenres } from '../services/genres_service';
import { GetAllAuthors } from '../services/author_service';
import { GetAllBooks, GetBooksByGenre, GetBooksByAuthor } from '../services/books_service';
import Paginator from '../components/Paginator';

export default function Catalog() {
    const [books, setBooks] = useState([]);
    const [authors, setAuthors] = useState([]);
    const [genres, setGenres] = useState([]);
    const [error, setError] = useState(null);
    const [pageNo, setPageNo] = useState(1);
    const [totalPages, setTotalPages] = useState(1);
    const [currentFetchBooksFunction, setCurrentFetchBooksFunction] = useState(() => fetchBookList);
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

    async function fetchBooksByGenre(genreId, pageNo = 1) {
        try {
            if (genreId == "All") {
                setCurrentFetchBooksFunction(() => fetchBookList);
                fetchBookList();
                return;
            } else {
                setCurrentFetchBooksFunction(() => (pageNo) => fetchBooksByGenre(genreId, pageNo));
            }

            const response = await GetBooksByGenre(genreId, pageNo);
            setBooks(response.items || []);
            setPageNo(response.currentPage);
            setTotalPages(response.totalPages);
        } catch (error) {
            setError(error.message);
        }
    }

    async function fetchBooksByAuthor(authorId, pageNo = 1) {
        try {
            if (authorId == "All") {
                setCurrentFetchBooksFunction(() => fetchBookList);
                fetchBookList();
                return;
            } else {
                setCurrentFetchBooksFunction(() => (pageNo) => fetchBooksByAuthor(authorId, pageNo));
            }

            const response = await GetBooksByAuthor(authorId, pageNo);
            setBooks(response.items || []);
            setPageNo(response.currentPage);
            setTotalPages(response.totalPages);
        } catch (error) {
            setError(error.message);
        }
    }

    if (error) {
        return <p>Error: {error}</p>;
    }

    return (
        <div>
            <h1>Get books by author or genre</h1>
            <label>Genre:</label>
            <select onChange={(e) => fetchBooksByGenre(e.target.value)}>
                <option value={null}>All</option>
                {genres.map((genre) => (
                    <option key={genre.id} value={genre.id}>{genre.name}</option>
                ))}
            </select>

            <label>Author:</label>
            <select onChange={(e) => fetchBooksByAuthor(e.target.value)}>
                <option value={null}>All</option>
                {authors.map((author) => (
                    <option key={author.id} value={author.id}>{author.firstName} {author.lastName}</option>
                ))}
            </select>

            <h1>Books</h1>
            <ul>
                {books.map((book) => (
                    <li key={book.id} onClick={() => handleBookClick(book.id)} style={{ cursor: 'pointer' }}>
                        {book.title}
                    </li>
                ))}
            </ul>
            <Paginator pageNo={pageNo} totalPages={totalPages} onPageChange={currentFetchBooksFunction} />
            <h1>Authors</h1>
            <ul>
                {authors.map((author) => (
                    <li key={author.id}>{author.firstName}</li>
                ))}
            </ul>
        </div>
    );
}