import React from "react";
import AllItems from "../components/AllItems";

function Categories() {
  const url = "https://myecommercewebapi.azurewebsites.net/api/Categories";
  const isProduct = false;

  return (
    <>
      <AllItems url={url} isProduct={isProduct}></AllItems>
      <br />
      <br />
      <br />
      <br />
      <br />
      <br />
      <br />
      <br />
      <br />
      <br />
      <br />
      <br />
      <br />
      <br />
    </>
  );
}

export default Categories;
