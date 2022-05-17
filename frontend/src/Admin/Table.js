import * as React from "react";
import MaterialTable from "@material-table/core";
import axios from "axios";
import { useState, useEffect } from "react";
import { ExportCsv, ExportPdf } from "@material-table/exporters";
import Layout from "../Layouts/AdminLayout";

export default function DataTable({ columns, title, url }) {
  const [rows, setRows] = useState([]);
  const [updatedRows, setUpdatedRows] = useState(true);

  const getData = async () => {
    const response = await fetch(url);
    const result = await response.json();
    setRows(result);
  };

  useEffect(() => {
    getData();
  }, [updatedRows]);

  let obj = {};

  const makeObject = (newRow) => {
    if (url.endsWith("Users")) {
      obj = {
        firstName: newRow.firstName,
        lastName: newRow.lastName,
        email: newRow.email,
        password: newRow.password,
        phone: newRow.phone,
        adress: newRow.adress,
        role: parseInt(newRow.role),
      };
    } else if (url.endsWith("Categories")) {
      obj = {
        name: newRow.name,
      };
    } else if (url.endsWith("Products")) {
      obj = {
        name: newRow.name,
        description: newRow.description,
        price: newRow.price,
        availableQuantity: newRow.availableQuantity,
        categoryId: newRow.categoryId,
        img: newRow.img,
      };
    }
  };

  return (
    <Layout>
      <div style={{ height: "auto", width: "100%" }}>
        <MaterialTable
          title={title}
          data={rows}
          columns={columns}
          options={{
            sorting: true,
            actionsColumnIndex: -1,
            exportMenu: [
              {
                label: "Export PDF",
                exportFunc: (cols, datas) => ExportPdf(cols, datas, `${title}`),
              },
              {
                label: "Export CSV",
                exportFunc: (cols, datas) => ExportCsv(cols, datas, `${title}`),
              },
            ],
            // tableLayout: "fixed",
          }}
          editable={{
            onRowUpdate: (newRow, oldRow) =>
              new Promise((resolve, reject) => {
                makeObject(newRow);
                setUpdatedRows(!updatedRows);
                axios
                  .patch(`${url}/${oldRow.id}`, obj)
                  .then(function (response) {
                    console.log(response);
                  })
                  .catch(function (error) {
                    console.log(error);
                  });
                setTimeout(() => resolve(), 2000);
              }),

            onRowDelete: (selectedRow) =>
              new Promise((resolve, reject) => {
                setUpdatedRows(!updatedRows);
                axios
                  .delete(`${url}/${selectedRow.id}`, {})
                  .then(function (response) {
                    console.log(response);
                  })
                  .catch(function (error) {
                    console.log(error);
                  });
                setTimeout(() => resolve(), 2000);
              }),

            onRowAdd: (newRow) =>
              new Promise((resolve, reject) => {
                setUpdatedRows(!updatedRows);
                makeObject(newRow);
                axios
                  .post(`${url}`, obj)
                  .then(function (response) {
                    console.log(response);
                  })
                  .catch(function (error) {
                    console.log(error);
                  });
                setTimeout(() => resolve(), 2000);
              }),
          }}
        />
      </div>
    </Layout>
  );
}
