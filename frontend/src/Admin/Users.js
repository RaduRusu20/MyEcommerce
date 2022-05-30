import React from "react";
import Table from "./Table";

function Users() {
  const usersUrl = "https://localhost:7090/api/Users";

  const columns = [
    {
      field: "id",
      title: "Id",
      width: 300,
      editable: "never",
      filtering: false,
      width: "15%",
    },
    {
      field: "firstName",
      title: "First Name",
      width: "10%",
      filtering: false,
      validate: (rowData) => {
        const regex = new RegExp("^[A-Z][a-z]+$");
        if (rowData.firstName === "" || rowData.firstName === undefined) {
          return "Required";
        } else if (!regex.test(rowData.firstName)) {
          return "Invalid first name!";
        }

        return true;
      },
    },
    {
      field: "lastName",
      title: "Last Name",
      width: "10%",
      filtering: false,
      validate: (rowData) => {
        const regex = new RegExp("^[A-Z][a-z]+$");
        if (rowData.lastName === "" || rowData.lastName === undefined) {
          return "Required";
        } else if (!regex.test(rowData.lastName)) {
          return "Invalid last name!";
        }

        return true;
      },
    },
    {
      field: "email",
      title: "Email",
      width: "20%",
      filtering: false,
      validate: (rowData) => {
        const regex = new RegExp(
          "^[a-zA-Z0-9.!#$%&’*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:.[a-zA-Z0-9-]+)*$"
        );
        if (rowData.email === "" || rowData.email === undefined) {
          return "Required";
        } else if (!regex.test(rowData.email)) {
          return "Invalid email!";
        }

        return true;
      },
    },
    {
      field: "password",
      title: "Password",
      width: "20%",
      filtering: false,
      validate: (rowData) => {
        const regex = new RegExp(
          "(?=.*?[a-z])(?=.*?[A-Z])(?=.*?[0-9])[a-zA-Z0-9]{8,}"
        );
        if (rowData.password === "" || rowData.password === undefined) {
          return "Required";
        } else if (!regex.test(rowData.password)) {
          return "Password: minimum 8 chars, one capital letter and one digit!";
        }

        return true;
      },
    },
    {
      field: "phone",
      title: "Phone",
      filtering: false,
      validate: (rowData) => {
        const regex = new RegExp("^[0-9]{10}$");
        if (rowData.phone === "" || rowData.phone === undefined) {
          return "Required";
        } else if (!regex.test(rowData.phone)) {
          return "Invalid phone number!";
        }

        return true;
      },
    },
    {
      field: "adress",
      title: "Adress",
      filtering: false,
      validate: (rowData) => {
        if (rowData.adress === "" || rowData.adress === undefined) {
          return "Required";
        }
        return true;
      },
    },
    {
      field: "role",
      title: "Role",
      lookup: { 0: "Admin", 1: "Customer" },
      filterPlaceholder: "Role",
      validate: (rowData) => {
        if (rowData.role === undefined) {
          return "Required";
        }
        return true;
      },
    },
  ];

  return <Table columns={columns} title={"Users"} url={usersUrl} />;
}

export default Users;
