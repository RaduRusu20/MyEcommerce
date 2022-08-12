import AllItems from "../components/AllItems";
import React from "react";

function Products() {
  const url = "https://myecommercewebapi.azurewebsites.net/api/products";
  const isProduct = true;

  return <AllItems url={url} isProduct={isProduct}></AllItems>;
}

export default Products;
