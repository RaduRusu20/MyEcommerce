import React from "react";
import Table from "./Table";
import { useFetch } from "../hooks/useFetch";
import { useEffect, useState } from "react";

function Products() {
  const productsUrl = "https://localhost:7090/api/Products";
  // const categories = useFetch("https://localhost:7090/api/Categories");

  const [categories, setCategories] = useState([]);

  const getData = async () => {
    const response = await fetch("https://localhost:7090/api/Categories");
    const result = await response.json();
    setCategories(result);
  };

  useEffect(() => {
    getData();
  }, []);

  const [mapper, setMapper] = useState({});

  //mapping categoryId : categoryName
  useEffect(() => {
    const mapper = {};
    categories.map((x) => (mapper[x.id] = x.name));
    setMapper(mapper);
  }, [categories]);

  const columns = [
    { field: "id", title: "Id", editable: "never" },
    { field: "name", title: "Name" },
    { field: "description", title: "Description" },
    { field: "price", title: "Price", type: "currency" },
    {
      field: "availableQuantity",
      title: "Available quantity",
      type: "numeric",
    },
    { field: "img", title: "Image URL" },
    { field: "categoryId", title: "Category", lookup: mapper },
  ];

  return <Table columns={columns} title={"Products"} url={productsUrl} />;
}

export default Products;
