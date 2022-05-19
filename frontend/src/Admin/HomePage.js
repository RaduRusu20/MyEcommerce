import React from "react";
import Layout from "../Layouts/AdminLayout";
import { useContext } from "react";
import { UserContext } from "../Services/UserContext";

function HomePage() {
  const { user } = useContext(UserContext);
  return (
    <>
      <Layout>
        {user.auth && <div>Welcome, {user.name}!</div>}
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
        <br />
      </Layout>
    </>
  );
}

export default HomePage;
