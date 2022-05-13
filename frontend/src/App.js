import "./App.css";
import Products from "./components/Products";
import { BrowserRouter, Routes, Route } from "react-router-dom";
import Home from "./components/Home";
import Error from "./components/Error";
import Categories from "./components/Categories";
import Navbar from "./components/Navbar";
import SingleProduct from "./components/SingleProduct";
import ProductsByCategory from "./components/ProductsByCategory";
import ProductsAdmin from "./Admin/Products";
import CategoriesAdmin from "./Admin/Categories";
import Users from "./Admin/Users";
import Footer from "./components/Footer";
import Post from "./Admin/Post";

function App() {
  return (
    <BrowserRouter>
      <Navbar />
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
        <Route path="admin/products" element={<ProductsAdmin />} />
        <Route path="admin/categories" element={<CategoriesAdmin />} />
        <Route path="admin/users" element={<Users />} />
        <Route path="admin/post" element={<Post />} />
      </Routes>
      <br />
      <Footer />
    </BrowserRouter>
  );
}

export default App;
