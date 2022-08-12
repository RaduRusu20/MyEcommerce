import React from "react";
import AllItems from "./AllItems";
import { useParams } from "react-router-dom";

function ProductsByCategory() {
  const { categoryId } = useParams();

  const url = `https://myecommercewebapi.azurewebsites.net/api/Categories/${categoryId}/Products`;
  const isProduct = true;

  return <AllItems url={url} isProduct={isProduct}></AllItems>;
}

export default ProductsByCategory;
