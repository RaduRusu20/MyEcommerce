import "./App.css";
import AllProducts from "./components/AllProducts";
import { BrowserRouter, Routes, Route } from "react-router-dom";
import Home from "./components/Home";

function App() {
  return (
    <BrowserRouter>
      <div>Navbar</div>
      <br></br>
      <Routes>
        <Route path="/" element={<Home />} />
        <Route path="products" element={<AllProducts />} />
      </Routes>
    </BrowserRouter>
  );
}

export default App;
