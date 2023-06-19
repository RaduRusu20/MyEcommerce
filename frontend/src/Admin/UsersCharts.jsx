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

const UserCharts = () => {
  const url = "https://myecommercewebapi.azurewebsites.net/api/Users";
  const [data, setData] = useState([]);

  const getData = async () => {
    const response = await fetch(url);
    const result = await response.json();
    setData(result);
  };

  useEffect(() => {
    getData();
  }, []);

  const labels = data.map((user) => {
    return user.adress;
  });

  var uniqueLabels = [...new Set(labels)];

  var ct = 0;
  var values = [];

  uniqueLabels.forEach((city) => {
    ct = 0;
    data.forEach((user) => {
      if (city === user.adress) {
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

  console.log(colors);

  console.log(uniqueLabels);
  console.log(values);

  var content = {
    labels: uniqueLabels,
    datasets: [
      {
        label: "Users",
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
          title="Users / Cities"
          options={{
            maintainAspectRatio: false,
            plugins: {
              title: {
                display: true,
                text: "Users statistics",
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
          title="Users / Cities"
          options={{
            maintainAspectRatio: false,
            plugins: {
              title: {
                display: true,
                text: "Users / City distribution",
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
          title="Users / Cities"
          options={{
            maintainAspectRatio: false,
            plugins: {
              title: {
                display: true,
                text: "Where are our users from?",
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
          title="Users / Cities"
          options={{
            indexAxis: "y",
            maintainAspectRatio: false,
            plugins: {
              title: {
                display: true,
                text: "Where are our users from?",
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

export default UserCharts;
