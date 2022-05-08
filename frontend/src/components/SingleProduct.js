import React from "react";
import { Link, useParams } from "react-router-dom";
import { useFetch } from "../hooks/useFetch";

function SingleProduct() {
  const { productId } = useParams();

  const product = useFetch(`https://localhost:7090/api/Products/${productId}`);
  const { name, price, img, description, categoryId, availableQuantity } =
    product.data;

  return (
    <>
      <p>{name}</p>
      <p>{price}</p>
      <p>{img}</p>
      <p>{description}</p>
      <p>{categoryId}</p>
      <p>{availableQuantity}</p>
    </>
  );
}

export default SingleProduct;
