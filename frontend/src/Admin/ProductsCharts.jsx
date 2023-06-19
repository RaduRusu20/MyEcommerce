import React from "react";
import { Doughnut } from "react-chartjs-2";
import { Bar } from "react-chartjs-2";
import { PolarArea } from "react-chartjs-2";
import {
  Chart as ChartJS,
  ArcElement,
  Tooltip,
  Legend,
  CategoryScale,
  LinearScale,
  BarElement,
  Title,
  RadialLinearScale,
} from "chart.js";
import { useState, useEffect } from "react";

ChartJS.register(
  RadialLinearScale,
  ArcElement,
  Tooltip,
  Legend,
  CategoryScale,
  LinearScale,
  BarElement,
  Title
);

const ProductsCharts = () => {
  const pUrl = "https://myecommercewebapi.azurewebsites.net/api/Products";
  const cUrl = "https://myecommercewebapi.azurewebsites.net/api/Categories";

  const [data, setData] = useState([]);
  const [categories, setCategories] = useState([]);

  const getData = async (url) => {
    const response = await fetch(url);
    const result = await response.json();
    setData(result);
  };

  const getCategories = async (url) => {
    const response = await fetch(url);
    const result = await response.json();
    setCategories(result);
  };

  useEffect(() => {
    getData(pUrl);
    getCategories(cUrl);
  }, []);

  const labels = data.map((p) => {
    return p.categoryId;
  });

  var uniqueLabels = [...new Set(labels)];

  var ct = 0;
  var values = [];

  uniqueLabels.forEach((category) => {
    ct = 0;
    data.forEach((product) => {
      if (category === product.categoryId) {
        ct++;
      }
    });
    values.push(ct);
  });

  var colors = [];
  uniqueLabels.map((x) => {
    var randomColor = "#" + Math.floor(Math.random() * 16777215).toString(16);
    colors.push(randomColor);
  });

  console.log(categories);

  uniqueLabels.map((id) => {
    categories.map((cat) => {
      if (id === cat.id) {
        uniqueLabels[uniqueLabels.indexOf(id)] = cat.name;
      }
    });
  });

  console.log(colors);

  console.log(uniqueLabels);
  console.log(values);

  var content = {
    labels: uniqueLabels,
    datasets: [
      {
        label: "Products",
        data: values,
        backgroundColor: colors,
        borderWidth: 1,
      },
    ],
  };

  return (
    <>
      <div
        style={{
          height: "60vh",
          position: "relative",
          marginBottom: "1%",
          padding: "1%",
        }}
      >
        <Doughnut
          title="Products / Category"
          options={{
            maintainAspectRatio: false,
            plugins: {
              title: {
                display: true,
                text: "Products statistics",
                font: { size: 16 },
              },
            },
          }}
          data={content}
        />
      </div>
      <div
        style={{
          height: "60vh",
          position: "relative",
          marginBottom: "1%",
          padding: "1%",
        }}
      >
        <PolarArea
          title="Products / Category"
          options={{
            maintainAspectRatio: false,
            plugins: {
              title: {
                display: true,
                text: "Products / Category distribution",
                font: { size: 16 },
              },
            },
          }}
          data={content}
        />
      </div>
      <div
        style={{
          height: "60vh",
          position: "relative",
          marginBottom: "1%",
          padding: "1%",
        }}
      >
        <Bar
          title="Products / Category"
          options={{
            maintainAspectRatio: false,
            plugins: {
              title: {
                display: true,
                text: "How many products are in a category?",
                font: { size: 16 },
              },
            },
          }}
          data={content}
        />
      </div>
      <div
        style={{
          height: "60vh",
          position: "relative",
          marginBottom: "1%",
          padding: "1%",
        }}
      >
        <Bar
          title="Products / Category"
          options={{
            indexAxis: "y",
            maintainAspectRatio: false,
            plugins: {
              title: {
                display: true,
                text: "How many products are in a category?",
                font: { size: 16 },
              },
            },
          }}
          data={content}
        />
      </div>
    </>
  );
};

export default ProductsCharts;
