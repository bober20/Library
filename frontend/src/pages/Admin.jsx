import React, { useEffect, useState } from 'react';
import AddBookForm from '../components/AddBookForm';
import { GetAllAuthors } from '../services/author_service';
import { GetAllBooks, DeleteBook } from '../services/books_service';
import '../styles/Admin.css';
import AddAuthorForm from '../components/AddAuthorForm';
import Paginator from '../components/Paginator';
import { Link } from 'react-router-dom';

export default function Admin() {
    const [books, setBooks] = useState([]);
    const [authors, setAuthors] = useState([]);
    const [error, setError] = useState(null);
    const [pageNo, setPageNo] = useState(1);
    const [totalPages, setTotalPages] = useState(1);

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

    async function deleteBook(bookId) {
        try {
            await DeleteBook(bookId);
            fetchBookList(pageNo);
        } catch (err) {
            setError(err.message);
        }
    }

    useEffect(() => {
        fetchBookList(pageNo);
        const fetchAuthors = async () => {
            try {
                const data = await GetAllAuthors();
                setAuthors(data);
            } catch (err) {
                setError(err.message);
            }
        };

        fetchAuthors();
    }, [pageNo]);

    if (error) {
        return <p>Error: {error}</p>;
    }

    return (
        <div className="admin-panel">
            <h1>Admin Panel</h1>
            <div className="inline-section">
                <AddBookForm />
                <h2>Books</h2>
                <ul>
                    {books.map((book) => {
                        var author = authors.find(a => a.id === book.authorId);
                        return (
                            <li key={book.id}>
                                {book.title} by {author ? `${author.firstName} ${author.lastName}` : 'Unknown Author'}
                                <Link to={`/editBook/${book.id}`}>Edit</Link>
                                <button onClick={() => deleteBook(book.id)}>Delete</button>
                            </li>
                        );
                    })}
                </ul>
                <Paginator pageNo={pageNo} totalPages={totalPages} onPageChange={fetchBookList} />
            </div>

            <div className="inline-section">
                <AddAuthorForm />
                <h2>Authors</h2>
                <ul>
                    {authors.map((author) => (
                        <li key={author.id}>{author.firstName} {author.lastName}</li>
                    ))}
                </ul>
            </div>
        </div>
    );
}