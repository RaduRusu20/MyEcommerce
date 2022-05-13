import * as React from "react";
import MaterialTable from "@material-table/core";
import SaveIcon from "@material-ui/icons/Save";
import axios from "axios";
import { useState, useEffect } from "react";

export default function DataTable({ columns, title, url }) {
  const [rows, setRows] = useState([]);
  const [updatedRows, setUpdatedRows] = useState([]);

  const getData = async () => {
    const response = await fetch(url);
    const result = await response.json();
    setRows(result);
  };

  useEffect(() => {
    getData();
  }, [updatedRows]);

  return (
    <div style={{ height: "auto", width: "100%" }}>
      <MaterialTable
        title={title}
        data={rows}
        columns={columns}
        options={{
          sorting: true,
          actionsColumnIndex: -1,
        }}
        actions={[
          {
            icon: SaveIcon,
            tooltip: "Save User",
            onClick: (event, rowData) => alert("You saved " + rowData.name),
          },
        ]}
        editable={{
          onRowDelete: (selectedRow) =>
            new Promise((resolve, reject) => {
              console.log(rows);

              setUpdatedRows(rows.filter((x) => selectedRow.id !== x.id));

              console.log(updatedRows);

              axios
                .delete(
                  `https://localhost:7090/api/Categories/${selectedRow.id}`,
                  {}
                )
                .then(function (response) {
                  console.log(response);
                })
                .catch(function (error) {
                  console.log(error);
                });
              setTimeout(() => resolve(), 1000);
            }),

          onRowAdd: (newRow) =>
            new Promise((resolve, reject) => {
              console.log(newRow);
              console.log(newRow.name);
              setRows([...rows, newRow]);
              setUpdatedRows([...rows, newRow]);

              axios
                .post("https://localhost:7090/api/Categories", {
                  name: newRow.name,
                })
                .then(function (response) {
                  console.log(response);
                })
                .catch(function (error) {
                  console.log(error);
                });
              setTimeout(() => resolve(), 1000);
            }),
        }}
      />
    </div>
  );
}
