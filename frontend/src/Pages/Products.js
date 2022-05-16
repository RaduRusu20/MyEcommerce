import AllItems from "../components/AllItems";
import React from "react";

function Products() {
  const url = "https://localhost:7090/api/Products";
  const isProduct = true;

  return <AllItems url={url} isProduct={isProduct}></AllItems>;
}

export default Products;
