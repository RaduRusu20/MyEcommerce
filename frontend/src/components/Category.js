import React from "react";
import CategoryStyle from "../style/CategoryStyle.module.css";
import { Link } from "react-router-dom";

function Category({ name, id }) {
  return (
    <div className={CategoryStyle.category}>
      <h4>{name}</h4>
      <Link to={`/categories/${id}/products`}>see products</Link>
    </div>
  );
}

export default Category;
