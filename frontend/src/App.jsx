import { useState } from 'react'
import './App.css'
import { BrowserRouter as Router, Route, Routes } from "react-router-dom";
import Catalog from "./pages/Catalog"
import NavBar from './components/NavBar';
import Admin from './pages/Admin';
import BookPage from './pages/BookPage';
import EditBookPage from './pages/EditBookPage';

function App() {
  const [count, setCount] = useState(0)

  return (
    <>
    

    <Router>
    <NavBar />
      <Routes>
        <Route path="/catalog" element={<Catalog />}></Route>
        <Route path="/admin" element={<Admin />}></Route>
        <Route path="/bookPage/:bookId" element={<BookPage />} />
        <Route path="/editBook/:bookId" element={<EditBookPage />} />
      </Routes>
    </Router>
    </>
  )
}

export default App
