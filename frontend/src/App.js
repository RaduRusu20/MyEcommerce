import "./App.css";
import Products from "./components/Products";
import { BrowserRouter, Routes, Route } from "react-router-dom";
import Home from "./components/Home";
import Error from "./components/Error";
import Categories from "./components/Categories";
import Navbar from "./components/Navbar";
import SingleProduct from "./components/SingleProduct";
import ProductsByCategory from "./components/ProductsByCategory";

function App() {
  return (
    <BrowserRouter>
      <Navbar></Navbar>
      <br></br>
      <Routes>
        <Route path="/" element={<Home />} />
        <Route path="products" element={<Products />} />
        <Route path="products/:productId" element={<SingleProduct />} />
        <Route path="categories" element={<Categories />} />
        <Route
          path="categories/:categoryId/products"
          element={<ProductsByCategory />}
        />
        <Route path="*" element={<Error />} />
      </Routes>
    </BrowserRouter>
  );
}

export default App;
