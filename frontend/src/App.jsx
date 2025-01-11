import { useState } from 'react'
import './App.css'
import { BrowserRouter as Router, Route, Routes } from "react-router-dom";
import Catalog from "./pages/Catalog"
import NavBar from './components/NavBar';
import Admin from './pages/Admin';

function App() {
  const [count, setCount] = useState(0)

  return (
    <>
    

    <Router>
    <NavBar />
      <Routes>
        <Route path="/catalog" element={<Catalog />}></Route>
        <Route path="/admin" element={<Admin />}></Route>
      </Routes>
    </Router>
    </>
  )
}

export default App
