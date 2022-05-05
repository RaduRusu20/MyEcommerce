import React from "react";
import CategoryStyle from "../style/CategoryStyle.module.css";

function Category({ name }) {
  return (
    <div className={CategoryStyle.category}>
      <h4>{name}</h4>
    </div>
  );
}

export default Category;
