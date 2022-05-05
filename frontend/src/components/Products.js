import AllItems from "./AllItems";
import React from "react";

function Products() {
  const products_url = "https://localhost:7090/api/Products";
  const isProduct = true;

  return (
    <AllItems products_url={products_url} isProduct={isProduct}></AllItems>
  );
}

export default Products;
