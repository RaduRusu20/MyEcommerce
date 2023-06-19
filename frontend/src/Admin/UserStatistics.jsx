import React from "react";
import Layout from "../Layouts/AdminLayout";
import UserCharts from "./UsersCharts";

function UserStatistics() {
  return (
    <Layout>
      <UserCharts />
    </Layout>
  );
}

export default UserStatistics;
