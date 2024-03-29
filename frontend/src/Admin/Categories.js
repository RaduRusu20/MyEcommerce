import React from "react";
import Table from "./Table";

function Categories() {
  const categoriesUrl =
    "https://myecommercewebapi.azurewebsites.net/api/Categories";

  const columns = [
    { field: "id", title: "Id", filtering: false, editable: "never" },
    {
      field: "name",
      title: "Name",
      filtering: false,
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
