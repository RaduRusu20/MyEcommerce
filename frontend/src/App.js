import "./App.css";
import Products from "./components/Products";
import { BrowserRouter, Routes, Route } from "react-router-dom";
import Home from "./components/Home";
import Error from "./components/Error";
import Category from "./components/Category";
import Categories from "./components/Categories";

function App() {
  return (
    <BrowserRouter>
      <div>Navbar</div>
      <br></br>
      <Routes>
        <Route path="/" element={<Home />} />
        <Route path="products" element={<Products />} />
        <Route path="category" element={<Category />} />
        <Route path="categories" element={<Categories />} />
        <Route path="*" element={<Error />} />
      </Routes>
    </BrowserRouter>
  );
}

export default App;
