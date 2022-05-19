import "./App.css";
import Products from "./Pages/Products";
import { BrowserRouter, Routes, Route } from "react-router-dom";
import Home from "./Pages/Home";
import Error from "./Pages/Error";
import Categories from "./Pages/Categories";
import SingleProduct from "./components/SingleProduct";
import ProductsByCategory from "./components/ProductsByCategory";
import ProductsAdmin from "./Admin/Products";
import CategoriesAdmin from "./Admin/Categories";
import Users from "./Admin/Users";
import RegistrationForm from "./Pages/RegistrationForm";
import AdminHomePage from "./Admin/HomePage";
import LoginForm from "./Pages/LoginForm";

function App() {
  return (
    <BrowserRouter>
      <Routes>
        <Route path="SignIn" element={<LoginForm />} />
        <Route path="SignUp" element={<RegistrationForm />} />
        <Route path="/" element={<Home />} />
        <Route path="products" element={<Products />} />
        <Route path="products/:productId" element={<SingleProduct />} />
        <Route path="categories" element={<Categories />} />
        <Route
          path="categories/:categoryId/products"
          element={<ProductsByCategory />}
        />
        <Route path="admin" element={<AdminHomePage />} />
        <Route path="admin/products" element={<ProductsAdmin />} />
        <Route path="admin/categories" element={<CategoriesAdmin />} />
        <Route path="admin/users" element={<Users />} />
        <Route path="*" element={<Error />} />
      </Routes>
    </BrowserRouter>
  );
}

export default App;
