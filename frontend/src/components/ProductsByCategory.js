import React from "react";
import AllItems from "./AllItems";
import { useParams } from "react-router-dom";

function ProductsByCategory() {
  const { categoryId } = useParams();

  const url = `https://localhost:7090/api/Categories/${categoryId}/Products`;
  const isProduct = true;

  return <AllItems url={url} isProduct={isProduct}></AllItems>;
}

export default ProductsByCategory;
