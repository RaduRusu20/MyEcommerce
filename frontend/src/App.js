import "./App.css";
import Products from "./Pages/Products";
import { BrowserRouter, Routes, Route } from "react-router-dom";
import Home from "./Pages/Home";
import Error from "./Pages/Error";
import Categories from "./Pages/Categories";
import Navbar from "./components/Navbar";
import SingleProduct from "./components/SingleProduct";
import ProductsByCategory from "./components/ProductsByCategory";
import ProductsAdmin from "./Admin/Products";
import CategoriesAdmin from "./Admin/Categories";
import Users from "./Admin/Users";
import Footer from "./components/Footer";
import RegistrationForm from "./components/RegistrationForm";

function App() {
  return (
    <BrowserRouter>
      <Navbar />
      <br></br>
      <Routes>
        <Route path="registration" element={<RegistrationForm />} />
        <Route path="/" element={<Home />} />
        <Route path="products" element={<Products />} />
        <Route path="products/:productId" element={<SingleProduct />} />
        <Route path="categories" element={<Categories />} />
        <Route
          path="categories/:categoryId/products"
          element={<ProductsByCategory />}
        />
        <Route path="admin/products" element={<ProductsAdmin />} />
        <Route path="admin/categories" element={<CategoriesAdmin />} />
        <Route path="admin/users" element={<Users />} />

        <Route path="*" element={<Error />} />
      </Routes>
      <br />
      <Footer />
    </BrowserRouter>
  );
}

export default App;
