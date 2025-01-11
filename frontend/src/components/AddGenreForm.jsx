import React, { useState } from 'react';
import { AddGenre } from '../services/genres_service';

export default function AddGenreForm() {
    const [name, setName] = useState('');
    const [error, setError] = useState(null);
    const [success, setSuccess] = useState(null);

    const handleSubmit = async (e) => {
        e.preventDefault();
        try {
            const newGenre = { name };
            await AddGenre(newGenre);
            setSuccess('Genre added successfully!');
            setName('');
        } catch (err) {
            setError(err.message);
        }
    };

    return (
        <div>
            <h2>Add New Genre</h2>
            <form onSubmit={handleSubmit}>
                <div>
                    <label htmlFor="name">Genre Name:</label>
                    <input
                        type="text"
                        id="name"
                        value={name}
                        onChange={(e) => setName(e.target.value)}
                        required
                    />
                </div>
                <button type="submit">Add Genre</button>
            </form>
            {error && <p style={{ color: 'red' }}>Error: {error}</p>}
            {success && <p style={{ color: 'green' }}>{success}</p>}
        </div>
    );
}