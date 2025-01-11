import React, { useState } from 'react';
import { AddAuthor } from "../services/author_service";

const AddAuthorForm = () => {
    const [firstName, setFirstName] = useState("");
    const [lastName, setLastName] = useState("");
    const [country, setCountry] = useState("");
    const [birthDate, setBirthDate] = useState("");
    const [error, setError] = useState(null);
    const [success, setSuccess] = useState(null);

    const handleSubmit = async (e) => {
        e.preventDefault();

        try {
            const newAuthor = {
                firstName,
                lastName,
                country,
                birthDate: new Date(birthDate).toISOString()
            };
            await AddAuthor(newAuthor);
            setSuccess("Author added successfully!");
            setFirstName("");
            setLastName("");
            setCountry("");
            setBirthDate("");
        } catch (error) {
            setError(error.message);
        }
    };

    return (
        <div>
            <h2>Add New Author</h2>
            <form onSubmit={handleSubmit}>
                <div>
                    <label htmlFor="firstname">Author's firstname:</label>
                    <input
                        type="text"
                        id="firstname"
                        value={firstName}
                        onChange={(e) => setFirstName(e.target.value)}
                        required
                    />
                </div>
                <div>
                    <label htmlFor="lastname">Author's lastname:</label>
                    <input
                        type="text"
                        id="lastname"
                        value={lastName}
                        onChange={(e) => setLastName(e.target.value)}
                        required
                    />
                </div>
                <div>
                    <label htmlFor="country">Author's country:</label>
                    <input
                        type="text"
                        id="country"
                        value={country}
                        onChange={(e) => setCountry(e.target.value)}
                        required
                    />
                </div>
                <div>
                    <label htmlFor="birthDate">Date of author's birth:</label>
                    <input
                        type="date"
                        id="birthDate"
                        value={birthDate}
                        onChange={(e) => setBirthDate(e.target.value)}
                        required
                    />
                </div>
                <button type="submit">Add Author</button>
            </form>
            {error && <p style={{ color: 'red' }}>Error: {error}</p>}
            {success && <p style={{ color: 'green' }}>{success}</p>}
        </div>
    );
};

export default AddAuthorForm;