import React from "react";
import Table from "./Table";

function Categories() {
  const categoriesUrl = "https://localhost:7090/api/Categories";

  const columns = [
    { field: "id", title: "Id", editable: "never" },
    {
      field: "name",
      title: "Name",
      validate: (rowData) => {
        if (rowData.name === "" || rowData.name === undefined) {
          return "Name cannot be empty";
        }
      },
    },
  ];

  return <Table columns={columns} title={"Categories"} url={categoriesUrl} />;
}

export default Categories;
