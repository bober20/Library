import React from 'react';

const Paginator = ({ pageNo, totalPages, onPageChange }) => {
    const handlePrevious = () => {
        if (pageNo > 1) {
            onPageChange(pageNo - 1);
        }
    };

    const handleNext = () => {
        if (pageNo < totalPages) {
            onPageChange(pageNo + 1);
        }
    };

    return (
        <div className="paginator">
            <button onClick={handlePrevious} disabled={pageNo === 1}>
                Previous
            </button>
            <span>Page {pageNo} of {totalPages}</span>
            <button onClick={handleNext} disabled={pageNo === totalPages}>
                Next
            </button>
        </div>
    );
};

export default Paginator;