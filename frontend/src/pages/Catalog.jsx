import React, { useEffect, useState } from 'react';
import { GetAllGenres } from '../services/genres_service';
import AddGenreForm from '../components/AddGenreForm';
import AddBookForm from '../components/AddBookForm';
import { GetAllAuthors } from '../services/author_service';
import Paginator from '../components/Paginator';

export default function Catalog() {
    const [genres, setGenres] = useState([]);
    const [authors, setAuthors] = useState([]);
    const [error, setError] = useState(null);
    const [pageNo, setPageNo] = useState(1);
    const [totalPages, setTotalPages] = useState(1);

    useEffect(() => {
        const fetchGenres = async () => {
            try {
                const data = await GetAllGenres();
                setGenres(data);
                setPageNo(data.pageNo);
                setTotalPages(data.totalPages);
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
        }

        fetchGenres();
        fetchAuthors();
    }, []);

    if (error) {
        return <p>Error: {error}</p>;
    }

    return (
        <div>
            <h1>Genres</h1>
            <ul>
                {genres.map((genre) => (
                    <li key={genre.id}>{genre.name}</li>
                ))}
            </ul>
            <Paginator pageNo={pageNo} totalPages={totalPages} setPageNo={setPageNo} />
            <h1>Authors</h1>
            <ul>
                {authors.map((author) => (
                    <li key={author.id}>{author.firstName}</li>
                ))}
            </ul>
        </div>
    );
}