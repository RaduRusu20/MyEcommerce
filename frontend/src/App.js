import "./App.css";
import Products from "./components/Products";
import { BrowserRouter, Routes, Route } from "react-router-dom";
import Home from "./components/Home";
import Error from "./components/Error";
import Categories from "./components/Categories";
import Navbar from "./components/Navbar";

function App() {
  return (
    <BrowserRouter>
      <Navbar></Navbar>
      <br></br>
      <Routes>
        <Route path="/" element={<Home />} />
        <Route path="products" element={<Products />} />
        <Route path="categories" element={<Categories />} />
        <Route path="*" element={<Error />} />
      </Routes>
    </BrowserRouter>
  );
}

export default App;
